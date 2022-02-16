using MathYouCan.Models;
using MathYouCan.Services.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MathYouCan.ViewModels
{
    public class UniversalTestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //first question is Instructions
        public IList<Question> Questions { get; set; }

        public int CurrentQuestionIndex { get; set; } = 0;

        public UniversalTestViewModel()
        {
            Questions = new List<Question>();

            InitializeList();
        }

        private void InitializeList()
        {
            //потом этот метод должен принимать IEnumerable<Question>
            for (int i = 0; i < 90; i++)
            {
                Question question = new Question
                {
                    QuestionContent = $"What is 1 + {i}?",
                    QuestionTitle = "Title",
                    Answers = new List<Answer>()
                    {
                        new Answer { AnswerContent = $"{i + 1}" },
                        new Answer { AnswerContent = $"{i + 4}" },
                        new Answer { AnswerContent = $"{i + 2}" },
                        new Answer { AnswerContent = $"{i + 3}" }
                    }
                };


                Questions.Add(question);
            }

            Question question2 = new Question
            {
                QuestionContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque tortor lacus, accumsan sed augue rhoncus," +
                "sodales gravida dolor. Morbi felis augue, pretium non lectus et, porttitor tincidunt lorem. Duis eget odio" +
                "tincidunt, congue sem gravida, maximus lorem. Integer at imperdiet est. Donec in dapibus diam. Phasellus sit" +
                "amet tellus in neque suscipit commodo facilisis vitae lacus. Aliquam quis vestibulum ex. Nulla mattis, eros efficiturul lamcorper pretium, felis dolor congue lectus, a volutpat turpis mauris sed nunc. Donec in nibh sit amet nunc fringilla placerat eu dictum nibh. Nulla facilisi. Phasellus a massa porta, pulvinar ante eu, sodales augue.",
                QuestionTitle = "Title",
                Answers = new List<Answer>()
                    {
                        new Answer { AnswerContent = $"{1}" },
                        new Answer { AnswerContent = $"{4}" },
                        new Answer { AnswerContent = $"{2}" },
                        new Answer { AnswerContent = $"{3}" }
                    }
            };


            Questions.Add(question2);

        }
        public List<Button> CreateButtons()
        {
            List<Button> buttons=new List<Button>();
            for (int i = 0; i < this.Questions.Count; i++)
            {
                Button btn = new Button();
                btn.Name = $"btn{i + 1}";
                btn.Height = 30;
                btn.IsEnabled = false;
                btn.Width = 27;
                Thickness margin = btn.Margin;
                margin.Left = 3;
                margin.Bottom = 0;
                btn.Margin = margin;
                btn.Content = $"{i + 1}";
                btn.Background = new SolidColorBrush(Colors.White);
                btn.Foreground = new SolidColorBrush((Colors.Black));
                btn.BorderBrush = new SolidColorBrush((Colors.Black));
                btn.FontWeight = FontWeights.Normal;
                btn.BorderThickness = new Thickness(1);
                var style = new Style
                {
                    TargetType = typeof(Border),
                    Setters = { new Setter { Property = Border.CornerRadiusProperty, Value = new CornerRadius(3) } }
                };
                btn.Resources.Add(style.TargetType, style);

                buttons.Add(btn);
            }
            return buttons;
        }

        public List<StackPanel> CreateNavButtons(List<Border> borders)
        {
            List<StackPanel> navPanels=new List<StackPanel>();
            for (int i = 0; i < this.Questions.Count; i++)
            {
                Border border = new Border();
                border.Name = $"borderStackPanel{i + 1}";
                border.BorderThickness = new Thickness(0, 1, 0, 0);
                border.BorderBrush = new SolidColorBrush(Colors.DarkGray);

                StackPanel questionsNavStackPanel = new StackPanel();
                questionsNavStackPanel.Name = $"questionNavStackPanel{i + 1}";
                questionsNavStackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
                questionsNavStackPanel.Orientation = Orientation.Horizontal;
                questionsNavStackPanel.Background = new SolidColorBrush(Colors.LightGray);
                
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
                numQuestion.Padding = new Thickness(0, 2, 0, 2);
                numQuestion.Margin = new Thickness(0);
                numQuestion.FontSize = 22;
                numQuestion.FontWeight = FontWeights.Light;
                numQuestion.Content = $"{i + 1}";

                Label stateQuestion = new Label();
                stateQuestion.Name = $"stateQuestion{i + 1}";
                stateQuestion.HorizontalAlignment = HorizontalAlignment.Center;
                stateQuestion.VerticalAlignment = VerticalAlignment.Center;
                stateQuestion.Padding = new Thickness(0, 2, 0, 2);
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
                borders.Add(border);
            }
            return navPanels;
        }
        public string GetInfo(string testType)
        {
            InfosAndInstructions infosAndInstructions = new InfosAndInstructions(testType);
            return infosAndInstructions.GetInfo();
            
        }

        public string GetInstrucitons(string testType)
        {
            InfosAndInstructions infosAndInstructions = new InfosAndInstructions(testType);
            return infosAndInstructions.GetInstructions();
        }

        internal void EnableButtons(List<Button> buttons)
        {
            foreach (var button in buttons)
            {
                button.IsEnabled = true;
            }
        }
    }
}
