using MathYouCan.Models.Enums;
using MathYouCan.Models.Exams;
using MathYouCan.Views;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MathYouCan
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                if (new Login().ShowDialog() == true)
                {
                    //api call and get the OfflineExam Object
                    //now just for example I create it for mySelf
                    OfflineExam exam = CreateExam();
                    new InstructionsWindow(exam).ShowDialog();
                }
            }
            finally
            {
                Shutdown();
            }
        }
        //MethodForTests
        private OfflineExam CreateExam()
        {
            return new OfflineExam()
            {
                Date = DateTime.Now,
                Name = "Practise Test 1",
                Sections = new List<Section>()
                {
                    new Section()
                    {
                        Duration=45*60,
                        Name="English Practise Test",
                        Questions=new List<Question>()
                        {
                            new Question()
                            {
                                Text="Question1",
                                Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Text="Answer1",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                        Text="Answer2",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                        Text="Answer3",
                                        Type=AnswerType.C
                                    }
                                }
                            },
                             new Question()
                            {
                                Text="Question2",
                                Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Text="Answer1",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                        Text="Answer2",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                        Text="Answer3",
                                        Type=AnswerType.C
                                    }
                                }
                            },
                              new Question()
                            {
                                Text="Question3",
                                Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Text="Answer1",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                        Text="Answer2",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                        Text="Answer3",
                                        Type=AnswerType.C
                                    }
                                }
                            },
                               new Question()
                            {
                                Text="Question4",
                                Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Text="Answer1",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                        Text="Answer2",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                        Text="Answer3",
                                        Type=AnswerType.C
                                    }
                                }
                            }
                        }
                    },
                    new Section()
                    {
                        Duration=30*60,
                        Name="Mathematics Practise Test",
                        Questions=new List<Question>()
                        {
                            new Question()
                            {
                                Text="Question1",
                                Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Text="Answer1",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                        Text="Answer2",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                        Text="Answer3",
                                        Type=AnswerType.C
                                    }
                                }
                            },
                             new Question()
                            {
                                Text="Question2",
                                Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Text="Answer1",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                        Text="Answer2",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                        Text="Answer3",
                                        Type=AnswerType.C
                                    }
                                }
                            },
                              new Question()
                            {
                                Text="Question3",
                                Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Text="Answer1",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                        Text="Answer2",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                        Text="Answer3",
                                        Type=AnswerType.C
                                    }
                                }
                            },
                               new Question()
                            {
                                Text="Question4",
                                Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Text="Answer1",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                        Text="Answer2",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                        Text="Answer3",
                                        Type=AnswerType.C
                                    }
                                }
                            }
                        }
                    }
                }

            };

        }
    }
}
