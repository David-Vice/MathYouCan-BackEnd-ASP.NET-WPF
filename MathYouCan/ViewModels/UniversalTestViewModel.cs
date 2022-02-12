using MathYouCan.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace MathYouCan.ViewModels
{
    public class UniversalTestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
                QuestionContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque tortor lacus, accumsan sed augue rhoncus,\n" +
                "sodales gravida dolor. Morbi felis augue, pretium non lectus et, porttitor tincidunt lorem. Duis eget odio\n" +
                "tincidunt, congue sem gravida, maximus lorem. Integer at imperdiet est. Donec in dapibus diam. Phasellus sit\n" +
                "amet tellus in neque suscipit commodo facilisis vitae lacus. Aliquam quis vestibulum ex. Nulla mattis, eros efficitur\nullamcorper pretium, felis dolor congue lectus, a volutpat turpis mauris sed nunc. Donec in nibh sit amet nunc fringilla placerat eu dictum nibh. Nulla facilisi. Phasellus a massa porta, pulvinar ante eu, sodales augue.",
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

    }
}
