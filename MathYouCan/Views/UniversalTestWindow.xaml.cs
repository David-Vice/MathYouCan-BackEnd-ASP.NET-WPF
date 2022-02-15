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
        List<string> fakeList = new List<string>();
        List<Button> buttons = new List<Button>();
        List<StackPanel> navPanels = new List<StackPanel>();
        int prevQuestion = 1;
        int currentQuestion=1;
        public UniversalTestWindow()
        {
            InitializeComponent();
            InitializeList();
            CreateButtons();
            CreateNavButtons();
            UpdateWindow();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AssignImageSources();
        }

        private void changeQuestionButton_Click(object sender, RoutedEventArgs e)
        {
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
            //other window updates
            //....
            //...
            //changes the color of exact button which was chosen as current
            ChangeBtnToActive(buttons.Where(x => x.Content.ToString() == $"{currentQuestion}").First());
            ChangeNavQuestToActive(navPanels.Where(x => x.Name.ToString() == $"questionNavStackPanel{currentQuestion}").First());
        }

        private void ChangeBtnToActive(Button btn)
        {
            //changes color to red
            btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e42a22"));
        }
        private void ChangeBtnToPassive(Button btn)
        {
            //changes color to white
            btn.Background = new SolidColorBrush(Colors.White);
        }
        private void ChangeNavQuestToActive(StackPanel stack)
        {
            stack.Background = new SolidColorBrush(Colors.SkyBlue);
        }
        private void ChangeNavQuestToPassive(StackPanel stack)
        {
            stack.Background = new SolidColorBrush(Colors.LightGray);
        }


        #region Method That are called only at the beginning once
        private void AssignImageSources()
        {
            actLogoImage.Source = new BitmapImage(new Uri("pack://application:,,,/Img/large.png"));
        }
        private void InitializeList()
        {
            //потом этот метод должен принимать IEnumerable<Question>
            for (int i = 0; i < 100; i++)
            {
                fakeList.Add($"This is question {i+1}");
            }
        }
        private void CreateButtons()
        {
            for (int i = 0; i < fakeList.Count; i++)
            {
                Button btn = new Button();
                btn.Name = $"btn{i + 1}";
                btn.Height = 30;

                btn.Width = 25;
                Thickness margin = btn.Margin;
                margin.Left = 10;
                margin.Bottom = 5;
                btn.Margin = margin;
                btn.Content = $"{i+1}";
                btn.Click += changeQuestionButton_Click;
                btn.Background = new SolidColorBrush(Colors.White);
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
