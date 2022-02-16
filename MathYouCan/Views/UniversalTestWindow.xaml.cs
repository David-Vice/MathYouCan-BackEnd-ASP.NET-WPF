﻿using MathYouCan.Converters;
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
        //пока пусть это будет коллекшн 'нецензурное слово' текста но потом поменяем на коллекш класса в котором уже
        //и текст и картинки и варианты ответов
        //IEnumerable<Question> questions
        List<Button> buttons = new List<Button>();
        List<StackPanel> navPanels = new List<StackPanel>();
        int prevQuestion = 1;

        private UniversalTestViewModel _universalTestViewModel;
 
        public UniversalTestWindow()
        {
            InitializeComponent();
            _universalTestViewModel = new UniversalTestViewModel();
            CreateButtons();
            CreateNavButtons();
          //  infoButton.IsEnabled = false;
            ChangeBtnToActive(infoButton);
            // UpdateWindow();
            //LoadInfo("English");
            
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

        //этот метод вызывается вначале 1 раз и еще каждый раз когда пользователь меняет вопрос кликая на кнопки changeQuestionButton_Click
        private void UpdateWindow()
        {

            ChangeBtnToPassive(buttons.Where(x => x.Content.ToString() == $"{prevQuestion}").First());
            ChangeNavQuestToPassive(navPanels.Where(x => x.Name.ToString() == $"questionNavStackPanel{prevQuestion}").First());
            
            UpdateWindowContent();

            ChangeNavQuestToActive(navPanels.Where(x => x.Name.ToString() == $"questionNavStackPanel{_universalTestViewModel.CurrentQuestionIndex + 1}").First());
            ChangeBtnToActive(buttons.Where(x => x.Content.ToString() == $"{_universalTestViewModel.CurrentQuestionIndex + 1}").First());
        }

        #endregion

        #region Methods To OPERATE BUTTONS

        private void changeQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            prevQuestion = _universalTestViewModel.CurrentQuestionIndex + 1;
            _universalTestViewModel.CurrentQuestionIndex = int.Parse((sender as Button).Content.ToString()) - 1;

            //Save chosen answer
            UpdateWindow();
            

        }
        private void navQuestion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_universalTestViewModel.CurrentQuestionIndex >= 0)
            {
                prevQuestion = _universalTestViewModel.CurrentQuestionIndex + 1;
                _universalTestViewModel.CurrentQuestionIndex = int.Parse((((sender as StackPanel).Children[0] as StackPanel).Children[0] as Label).Content.ToString()) - 1;
                NavPanel.Visibility = Visibility.Collapsed; //no animation
                UpdateWindow();

            }
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
            prevQuestion = _universalTestViewModel.CurrentQuestionIndex + 1;
            _universalTestViewModel.CurrentQuestionIndex--;
            UpdateWindow();
        }
        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (infoButton.Background == new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e42a22")))
            {
                ChangeBtnToPassive(infoButton);
                _universalTestViewModel.EnableButtons(buttons);
                navButton.IsEnabled = true;
                UpdateWindow();
            }
            else
            {
                prevQuestion = _universalTestViewModel.CurrentQuestionIndex + 1;
                _universalTestViewModel.CurrentQuestionIndex++;

                UpdateWindow();
            }
        }

        #endregion

        
        
        
        #region Methods which are called only at the beginning once

        private void LoadInfo(string testType)
        {
            StackPanelConverter converter = new StackPanelConverter("#00FFFF");
            converter.FillStackPanel(questionPassageStackPanel,_universalTestViewModel.GetInfo(testType));
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
            if((sender as StackPanel).Name == $"questionNavStackPanel{_universalTestViewModel.CurrentQuestionIndex + 1}")
                (sender as StackPanel).Background = new SolidColorBrush(Colors.SkyBlue);
            else
                (sender as StackPanel).Background = new SolidColorBrush(Colors.LightGray);
        }

        #endregion
    }
}

