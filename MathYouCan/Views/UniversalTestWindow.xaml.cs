using MathYouCan.Converters;
using MathYouCan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace MathYouCan.Views
{
    public partial class UniversalTestWindow : Window
    {
        //возьмем из коллекшина тот который совпадает с кнопкой на которую нажали по номеру вопроса, 
        // (по дэфолту он 1 ) выбираем вопрос из этого коллекшина API и фулл показывем с помощью UpdateWindow(int questionNumber)
        //а сам коллекшн и его длинную используем для создание динамч. платформы вопросов внизу
        //сам коллекшн передадим через конструкктор
        //пока пусть это будет коллекшн 'нецензурное слово' текста но потом поменяем на коллекш класса в котором уже
        //и текст и картинки и варианты ответов
        //IEnumerable<Question> questions
        List<Button> buttons = new List<Button>();
        List<StackPanel> navPanels = new List<StackPanel>();

        private UniversalTestViewModel _universalTestViewModel;
 
        public UniversalTestWindow()
        {
            string testType = "English";
            InitializeComponent();
            _universalTestViewModel = new UniversalTestViewModel(testType);
            CreateButtons();
            CreateNavButtons();
            ChangeBtnToActive(infoButton);
            LoadInfo(testType);
        }

        #region Methods To UPDATE WINDOW

        /// <summary>
        ///     -- Enables/Disables (nextButton), (prevButton)  depending on current question number (_universalTestViewModel.CurrentQuestionIndex)
        ///     -- Fills instruction content
        ///     -- Sets title for question
        /// </summary>
        /// 
        private void UpdateWindowContent()
        {
            /* Enabling/Disabling next and prev buttons */

            // First question loaded
            if (_universalTestViewModel.CurrentQuestionIndex == 0)
            {
                prevButton.IsEnabled = false;
                nextButton.IsEnabled = true;
            }
            // Last question loaded
            else if (_universalTestViewModel.CurrentQuestionIndex == _universalTestViewModel.Questions.Count - 1)
            {
                prevButton.IsEnabled = true;
                nextButton.IsEnabled = false;
            }
            else
            {
                prevButton.IsEnabled = true;
                nextButton.IsEnabled = true;
            }
            
            FillQuestion();
            questionTitleLabel.Content = _universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].QuestionTitle;
        }
        
        private void FillQuestion()
        {
            FillQuestionPassage();
        }

        /// <summary>
        /// Sets question text to questionContent(Stack Panel) according to current Question index(CurrentQuestionIndex) from view model
        /// </summary>
        private void FillQuestionPassage()
        {
            //StackPanelConverter converter = new StackPanelConverter("#00FFFF");
            //converter.FillStackPanel(questionPassageStackPanel, _universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].QuestionContent, true);

            TextToFlowDocumentConverter textTo = new TextToFlowDocumentConverter(Brushes.Yellow, Brushes.GreenYellow);
            textTo.ConvertToParagraph(questionPassageParagraph, _universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].QuestionContent, 16);
        }

        //этот метод вызывается вначале 1 раз и еще каждый раз когда пользователь меняет вопрос кликая на кнопки changeQuestionButton_Click
        private void UpdateWindow()
        {
            if (_universalTestViewModel.PrevQuestionIndex >= 0 )
            {
                ChangeBtnToPassive(buttons[_universalTestViewModel.PrevQuestionIndex]);
                ChangeNavQuestToPassive(navPanels.Where(x => x.Name.ToString() == $"questionNavStackPanel{_universalTestViewModel.PrevQuestionIndex}").First());
            }
            UpdateWindowContent();

            ChangeNavQuestToActive(navPanels.Where(x => x.Name.ToString() == $"questionNavStackPanel{_universalTestViewModel.CurrentQuestionIndex}").First());
            ChangeBtnToActive(buttons[_universalTestViewModel.CurrentQuestionIndex]);
        }

        #endregion

        #region Methods To OPERATE BUTTONS (Click, Active Passive)

        private void changeQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            _universalTestViewModel.PrevQuestionIndex = _universalTestViewModel.CurrentQuestionIndex;

            int num;
            if (int.TryParse((sender as Button).Content.ToString(),out num))
            {
                _universalTestViewModel.CurrentQuestionIndex = num;
            }
            else
            {
                _universalTestViewModel.CurrentQuestionIndex = 0;
            }
            UpdateWindow();
            //Save chosen answer
        }
        private void ChangeBtnToActive(Button btn)
        {
            //changes color to red
            btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e42a22"));
            btn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f2f2f2"));
            btn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f2f2f2"));
            btn.FontWeight = FontWeights.Bold;
            btn.BorderThickness = new Thickness(2);
        }
        private void ChangeBtnToPassive(Button btn)
        {
            //changes color to white
            btn.Background = new SolidColorBrush(Colors.White);
            btn.Foreground = new SolidColorBrush((Colors.Black));
            btn.BorderBrush = new SolidColorBrush((Colors.Black));
            btn.FontWeight = FontWeights.Normal;
            btn.BorderThickness = new Thickness(1);
        }
        private void ChangeNavQuestToActive(StackPanel stack)
        {
            stack.Background = new SolidColorBrush(Colors.SkyBlue);
        }
        private void ChangeNavQuestToPassive(StackPanel stack)
        {
            stack.Background = new SolidColorBrush(Colors.LightGray);
        }

        #endregion

        #region prevButton and nextButton Clicks

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            _universalTestViewModel.PrevQuestionIndex = _universalTestViewModel.CurrentQuestionIndex;
            _universalTestViewModel.CurrentQuestionIndex--;
            UpdateWindow();
        }
        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (infoButton.IsEnabled)
            {
                ChangeBtnToPassive(infoButton);
                _universalTestViewModel.EnableButtons(buttons);
                navButton.IsEnabled = true;
                infoButton.IsEnabled = false;
                endSectionButton.IsEnabled = true;
                if (_universalTestViewModel.TestIsTimed())
                {
                    _universalTestViewModel.SetTimer(timerTextBlock,this,timerProgressBar);
                }
            }
            else
            {
                _universalTestViewModel.PrevQuestionIndex = _universalTestViewModel.CurrentQuestionIndex ;
                _universalTestViewModel.CurrentQuestionIndex++;
            }
            UpdateWindow();
        }

        #endregion
        
        #region Methods which are called only at the beginning once

        private void LoadInfo(string testType)
        {
            TextToFlowDocumentConverter converter = new TextToFlowDocumentConverter(Brushes.Yellow, Brushes.GreenYellow);
            converter.ConvertToParagraph(questionPassageParagraph, _universalTestViewModel.GetInfo(testType),17);
        }
        
        private void CreateButtons()
        {
            buttons = _universalTestViewModel.CreateButtons();
            foreach (var button in buttons)
            {
                button.Click += changeQuestionButton_Click;
                questionsStackPanel.Children.Add(button);
            }
        }
        private void CreateNavButtons()
        {
            List<Border> borders=new List<Border>();
            navPanels = _universalTestViewModel.CreateNavButtons(borders);
            for (int i = 0; i < navPanels.Count; i++)
            {
                navPanels[i].MouseDown += navQuestion_MouseDown;
                navPanels[i].MouseEnter += navQuestion_MouseEnter;
                navPanels[i].MouseLeave += navQuestion_MouseLeave;
                navBody.Children.Add(borders[i]);
            }

        }

        #endregion

        #region Methods for NAVIGATION PANEL
        private void navQuestion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _universalTestViewModel.PrevQuestionIndex = _universalTestViewModel.CurrentQuestionIndex;
            int num;
            if (int.TryParse((((sender as StackPanel).Children[0] as StackPanel).Children[0] as Label).Content.ToString(), out num))
            {
                _universalTestViewModel.CurrentQuestionIndex = num;
            }
            else
            {
                _universalTestViewModel.CurrentQuestionIndex = 0;
            }
           
            NavPanel.Visibility = Visibility.Collapsed; //no animation
            UpdateWindow();
        }

        private void navButton_Click(object sender, RoutedEventArgs e)
        {
            NavPanel.Visibility = Visibility.Visible;
        }
        private void navPanelClosing_Completed(object sender, EventArgs e)
        {
            NavPanel.Visibility = Visibility.Collapsed;
        }
        private void navQuestion_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as StackPanel).Background = new SolidColorBrush(Colors.AliceBlue);
        }
        private void navQuestion_MouseLeave(object sender, MouseEventArgs e)
        {
            if((sender as StackPanel).Name == $"questionNavStackPanel{_universalTestViewModel.CurrentQuestionIndex}")
                (sender as StackPanel).Background = new SolidColorBrush(Colors.SkyBlue);
            else
                (sender as StackPanel).Background = new SolidColorBrush(Colors.LightGray);
        }

        #endregion

        #region Methods for TOOLS PANEL AND ENDSECTION

        private void toolsButton_Click(object sender, RoutedEventArgs e)
        {
            toolsPopUpPanel.IsOpen = !toolsPopUpPanel.IsOpen;
        }

        private void popUpOptionStackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel sp =  sender as StackPanel;
            Label l = (sp.Children[0] as Label);
            if (l.Visibility == Visibility.Visible) 
            { 
                l.Visibility = Visibility.Collapsed;
                ClearHighlight();
            }
            else l.Visibility = Visibility.Visible;

            toolsPopUpPanel.IsOpen = !toolsPopUpPanel.IsOpen;
        }

        private void popUpOptionStackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            sp.Background = new SolidColorBrush(Color.FromRgb(218, 37, 29));

            for (int i = 0; i < sp.Children.Count; i++)
            {
                (sp.Children[i] as Label).Foreground = Brushes.White;
            }
        }
        private void popUpOptionStackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            sp.Background = Brushes.Transparent;

            for (int i = 0; i < sp.Children.Count; i++)
            {
                (sp.Children[i] as Label).Foreground = Brushes.Black;
            }
        }
        private void endSectionButton_Click(object sender, RoutedEventArgs e)
        {
            _universalTestViewModel.SendResultAndExitWindow(this);
        }
        #endregion
       
        private void ClearHighlight() { }
    }
}

