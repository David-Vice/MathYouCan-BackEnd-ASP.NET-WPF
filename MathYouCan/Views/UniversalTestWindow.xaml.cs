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

namespace MathYouCan.Views
{
    public partial class UniversalTestWindow : Window
    {
        //возьмем из коллекшина тот который совпадает с кнопкой на которую нажали по номеру вопроса, 
        // (по дэфолту он 1 ) выбираем вопрос из этого коллекшина API и фулл показывем с помощью UpdateWindow(int questionNumber)
        //а сам коллекшн и его длинную используем для создание динамч. платформы вопросов внизу
        //сам коллекшн передадим через конструкктор
        //пока пусть это будет коллекшн гавно текста но потом поменяем на коллекш класса в котором уже
        //и текст и картинки и варианты ответов
        //IEnumerable<Question> questions
        List<Button> buttons = new List<Button>();
        List<StackPanel> navPanels = new List<StackPanel>();
        int prevQuestion = 1;
        int currentQuestion=1;
        //int currentQuestion=1;

        private UniversalTestViewModel _universalTestViewModel;
 
        public UniversalTestWindow()
        {
            InitializeComponent();
            
            _universalTestViewModel = new UniversalTestViewModel();

            CreateButtons();
            CreateNavButtons();
            UpdateWindow();
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AssignImageSources();
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
            StackPanelConverter converter = new StackPanelConverter("#00FFFF");
            converter.FillStackPanel(questionPassageStackPanel, _universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].QuestionContent, true);
        }


            prevQuestion = currentQuestion;
            currentQuestion = int.Parse((sender as Button).Content.ToString());
            //Save chosen answer
            UpdateWindow();
        }
        private void navQuestion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            prevQuestion = currentQuestion;
            currentQuestion = int.Parse((((sender as StackPanel).Children[0] as StackPanel).Children[0] as Label).Content.ToString());
            NavPanel.Visibility = Visibility.Collapsed; //no animation
            UpdateWindow();
        }

        //этот метод вызывается вначале 1 раз и еще каждый раз когда пользователь меняет вопрос кликая на кнопки changeQuestionButton_Click
        private void UpdateWindow()
        {
            ChangeBtnToPassive(buttons.Where(x => x.Content.ToString() == $"{prevQuestion}").First());
            ChangeNavQuestToPassive(navPanels.Where(x => x.Name.ToString() == $"questionNavStackPanel{prevQuestion}").First());
            questionTextBlock.Text = fakeList[currentQuestion - 1];
            //questionTextBlock.Text = fakeList[currentQuestion - 1];
            UpdateWindowContent();

            //other window updates
            //....
            //...
            //changes the color of exact button which was chosen as current
            ChangeBtnToActive(buttons.Where(x => x.Content.ToString() == $"{currentQuestion}").First());
            ChangeNavQuestToActive(navPanels.Where(x => x.Name.ToString() == $"questionNavStackPanel{currentQuestion}").First());
            ChangeBtnToActive(buttons.Where(x => x.Content.ToString() == $"{_universalTestViewModel.CurrentQuestionIndex + 1}").First());
        }

        #endregion


        #region Methods To OPERATE BUTTONS

        private void changeQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            //ChangeBtnToPassive(buttons.Where(x => x.Content.ToString() == $"{currentQuestion}").First());
            //currentQuestion = int.Parse((sender as Button).Content.ToString());
            ChangeBtnToPassive(buttons.Where(x => x.Content.ToString() == $"{_universalTestViewModel.CurrentQuestionIndex + 1}").First());
            _universalTestViewModel.CurrentQuestionIndex = int.Parse((sender as Button).Content.ToString()) - 1;

            //Save chosen answer
            UpdateWindow();
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

        #endregion


        #region prevButton and nextButton Clicks

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeBtnToPassive(buttons.Where(x => x.Content.ToString() == $"{_universalTestViewModel.CurrentQuestionIndex + 1}").First());
            _universalTestViewModel.CurrentQuestionIndex--;
            UpdateWindow();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeBtnToPassive(buttons.Where(x => x.Content.ToString() == $"{_universalTestViewModel.CurrentQuestionIndex + 1}").First());
            _universalTestViewModel.CurrentQuestionIndex++;
            UpdateWindow();
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


        #region Method That are called only at the beginning once
        private void AssignImageSources()
        {
            actLogoImage.Source = new BitmapImage(new Uri("pack://application:,,,/Img/large.png"));
        }

        private void CreateButtons()
        {
            for (int i = 0; i < _universalTestViewModel.Questions.Count; i++)
            {
                Button btn = new Button();
                btn.Name = $"btn{i + 1}";
                btn.Height = 30;

                btn.Width = 27;
                Thickness margin = btn.Margin;
                margin.Left = 3;
                margin.Bottom = 0;
                btn.Margin = margin;
                btn.Content = $"{i + 1}";
                btn.Click += changeQuestionButton_Click;
                btn.Background = new SolidColorBrush(Colors.White);

                var style = new Style
                {
                    TargetType = typeof(Border),
                    Setters = { new Setter { Property = Border.CornerRadiusProperty, Value = new CornerRadius(3) } }
                };
                btn.Resources.Add(style.TargetType, style);

                buttons.Add(btn);
                questionsStackPanel.Children.Add(btn);
            }
        }
        private void CreateNavButtons()
        {
            for (int i = 0; i < fakeList.Count; i++)
            {
                Border border = new Border();
                border.Name = $"borderStackPanel{i + 1}";
                border.BorderThickness = new Thickness(0, 1, 0, 0);
                border.BorderBrush = new SolidColorBrush(Colors.DarkGray);
                
                StackPanel questionsNavStackPanel = new StackPanel();
                questionsNavStackPanel.Name = $"questionNavStackPanel{i+1}";
                questionsNavStackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
                questionsNavStackPanel.Orientation = Orientation.Horizontal;
                questionsNavStackPanel.Background = new SolidColorBrush(Colors.LightGray);
                questionsNavStackPanel.MouseDown += navQuestion_MouseDown;
                questionsNavStackPanel.MouseEnter += navQuestion_MouseEnter;
                questionsNavStackPanel.MouseLeave += navQuestion_MouseLeave;

                StackPanel numStackPanel = new StackPanel();
                numStackPanel.Name = $"numStackPanel{i + 1}";
                numStackPanel.VerticalAlignment = VerticalAlignment.Stretch;
                numStackPanel.Margin = new Thickness(0);
                numStackPanel.Width = 70;

                StackPanel stateStackPanel = new StackPanel();
                stateStackPanel.Name = $"stateStackPanel{i + 1}";
                stateStackPanel.VerticalAlignment = VerticalAlignment.Stretch;
                stateStackPanel.Margin = new Thickness(0);
                stateStackPanel.Width = 200;

                Label numQuestion = new Label();
                numQuestion.Name = $"numQuestion{i + 1}";
                numQuestion.HorizontalAlignment = HorizontalAlignment.Center;
                numQuestion.VerticalAlignment = VerticalAlignment.Center;
                numQuestion.Padding = new Thickness(0,2,0,2);
                numQuestion.Margin = new Thickness(0);
                numQuestion.FontSize = 22;
                numQuestion.FontWeight = FontWeights.Light;
                numQuestion.Content = $"{i + 1}";

                Label stateQuestion = new Label();
                stateQuestion.Name = $"stateQuestion{i + 1}";
                stateQuestion.HorizontalAlignment = HorizontalAlignment.Center;
                stateQuestion.VerticalAlignment = VerticalAlignment.Center;
                stateQuestion.Padding = new Thickness(0,2,0,2);
                stateQuestion.Margin = new Thickness(0);
                stateQuestion.FontSize = 22;
                stateQuestion.FontWeight = FontWeights.Light;
                stateQuestion.Content = $"Unanswered";

                numStackPanel.Children.Add(numQuestion);
                stateStackPanel.Children.Add(stateQuestion);
                questionsNavStackPanel.Children.Add(numStackPanel);
                questionsNavStackPanel.Children.Add(stateStackPanel);
                navPanels.Add(questionsNavStackPanel);
                border.Child = questionsNavStackPanel;
                navBody.Children.Add(border);
            }
        }
        #endregion

        #region Navigation Panel Methods
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
            if((sender as StackPanel).Name == $"questionNavStackPanel{currentQuestion}")
                (sender as StackPanel).Background = new SolidColorBrush(Colors.SkyBlue);
            else
                (sender as StackPanel).Background = new SolidColorBrush(Colors.LightGray);
        }

        #endregion


    }
}

