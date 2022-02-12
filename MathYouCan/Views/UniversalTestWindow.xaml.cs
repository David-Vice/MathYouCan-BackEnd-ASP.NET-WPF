using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        int currentQuestion=1;
        public UniversalTestWindow()
        {
            InitializeComponent();
            InitializeList();
            CreateButtons();
            UpdateWindow();
        }
      

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AssignImageSources();
        }

        private void changeQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeBtnToPassive(buttons.Where(x => x.Content.ToString() == $"{currentQuestion}").First());
            currentQuestion = int.Parse((sender as Button).Content.ToString());
            //Save chosen answer
            UpdateWindow();

        }

        

     
        //этот метод вызывается вначале 1 раз и еще каждый раз когда пользователь меняет вопрос кликая на кнопки changeQuestionButton_Click
        private void UpdateWindow()
        {
            questionTextBlock.Text = fakeList[currentQuestion - 1];
            //other window updates
            //....
            //...
            //changes the color of exact button which was chosen as current
            ChangeBtnToActive(buttons.Where(x => x.Content.ToString() == $"{currentQuestion}").First());
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
      
        #endregion
    }
}
