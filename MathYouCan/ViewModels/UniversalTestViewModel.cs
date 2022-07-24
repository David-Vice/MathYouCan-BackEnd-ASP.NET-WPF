//using MathYouCan.Models;
using MathYouCan.Converters;
using MathYouCan.Data;
using MathYouCan.Models;
using MathYouCan.Models.Exams;
using MathYouCan.Services.Concrete;
using MathYouCan.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Section = MathYouCan.Models.Exams.Section;

namespace MathYouCan.ViewModels
{
    public class UniversalTestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        //first question is Instructions
        public IList<QuestionView> Questions { get; set; }
        public Section _section { get; set; }
        public int CurrentQuestionIndex { get; set; } = -1;
        public int PrevQuestionIndex { get; set; } = -1;
        public TextToFlowDocumentConverter Converter { get; set; }
        public Brush SelectedTextBrush { get; set; }  // Color of selected part of text sent by API
        public Brush HighLighteTextBrush { get; set; }  // Color of highlight
        public bool IsHighlightEnabled { get; set; } = false;
        public bool IsEliminatorEnabled { get; set; } = false;
        public int NumberOfCorrectAnswers { get; set; } = 0;

        //потом этот метод должен принимать IEnumerable<Question>
        public UniversalTestViewModel(Section section)
        {

            _section = section;
            Questions = new List<QuestionView>();
            SelectedTextBrush = Brushes.Yellow;
            HighLighteTextBrush = Brushes.GreenYellow;
            Converter = new TextToFlowDocumentConverter(SelectedTextBrush, HighLighteTextBrush);
            InitializeList(section.Name);
        }
        //private void SetInstructions()
        //{
        //    Instruction ins = GetInstrucitons(_section.Name);
        //    Question instruction = new Question();
        //    instruction.Text = ins.Header + "\n" + ins.InstructionText;
        //    (_section.Questions as List<Question>).Insert(0, instruction);

        //}
        private void InitializeList(string sectionName)
        {
            //adding instruction page
            QuestionView instruction = new QuestionView();
            Instruction ins = GetInstrucitons(sectionName);
            instruction.IsAnswered = true;

            instruction.Question = new Question();
            instruction.Question.QuestionAnswers = new List<QuestionAnswer>();

            instruction.Question.Text = ins.Header + "\n" + ins.InstructionText;
            Questions.Add(instruction);


            foreach (var item in _section.Questions)
            {
                Questions.Add(new QuestionView() { Question = item });
            }

        }
        public List<Button> CreateButtons()
        {
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < Questions.Count; i++)
            {
                Button btn = new Button();
                btn.Name = $"btn{i}";
                btn.Height = 30;
                btn.IsEnabled = false;
                btn.Width = 27;
                Thickness margin = btn.Margin;
                margin.Left = 3;
                margin.Bottom = 0;
                btn.Margin = margin;
                _ = i == 0 ? btn.Content = "Instr" : btn.Content = $"{i}";
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

        public List<StackPanel> CreateNavButtons(List<Border> borders, UniversalTestWindow window)
        {
            List<StackPanel> navPanels = new List<StackPanel>();
            for (int i = 0; i < Questions.Count; i++)
            {
                Border border = new Border();
                border.Name = $"borderStackPanel{i }";
                border.BorderThickness = new Thickness(0, 1, 0, 0);
                border.BorderBrush = new SolidColorBrush(Colors.DarkGray);

                StackPanel questionsNavStackPanel = new StackPanel();
                questionsNavStackPanel.Name = $"questionNavStackPanel{i }";
                questionsNavStackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
                questionsNavStackPanel.Orientation = Orientation.Horizontal;
                questionsNavStackPanel.Background = new SolidColorBrush(Colors.LightGray);

                StackPanel numStackPanel = new StackPanel();
                numStackPanel.Name = $"numStackPanel{i}";
                numStackPanel.VerticalAlignment = VerticalAlignment.Stretch;
                numStackPanel.Margin = new Thickness(0);
                numStackPanel.Width = 70;

                StackPanel stateStackPanel = new StackPanel();
                stateStackPanel.Name = $"stateStackPanel{i}";
                stateStackPanel.VerticalAlignment = VerticalAlignment.Stretch;
                stateStackPanel.Margin = new Thickness(0);
                stateStackPanel.Width = 200;

                Label numQuestion = new Label();
                numQuestion.Name = $"numQuestion{i }";
                numQuestion.HorizontalAlignment = HorizontalAlignment.Center;
                numQuestion.VerticalAlignment = VerticalAlignment.Center;
                numQuestion.Padding = new Thickness(0, 2, 0, 2);
                numQuestion.Margin = new Thickness(0);
                numQuestion.FontSize = 22;
                numQuestion.FontWeight = FontWeights.Light;
                _ = i == 0 ? numQuestion.Content = "Instr" : numQuestion.Content = $"{i}";
                //   numQuestion.Content = $"{i + 1}";

                Label stateQuestion = new Label();
                stateQuestion.Name = $"stateQuestion{i}";
                stateQuestion.HorizontalAlignment = HorizontalAlignment.Center;
                stateQuestion.VerticalAlignment = VerticalAlignment.Center;
                stateQuestion.Padding = new Thickness(0, 2, 0, 2);
                stateQuestion.Margin = new Thickness(0);
                stateQuestion.FontSize = 22;
                stateQuestion.FontWeight = FontWeights.Light;
                stateQuestion.Content = $"Unanswered";
                window.RegisterName($"stateQuestion{i}", stateQuestion);

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



        public Instruction GetInstrucitons(string section)
        {
            InfosAndInstructions infosAndInstructions = new InfosAndInstructions(section);
            return infosAndInstructions.GetInstructions();
        }

        public void EnableButtons(List<Button> buttons)
        {
            foreach (var button in buttons)
            {
                button.IsEnabled = true;
            }
        }

        #region Timer Methods

        //These 2 methods will work with api values
        public bool TestIsTimed()
        {
            return _section.Duration != null;
        }
        public int GetTime()
        {
            return (int)_section.Duration * 60;
        }
        public void SetTimer(TextBlock timeLabel, UniversalTestWindow window, ProgressBar progressBar, ResultsWindow resultsWindow)
        {
            int time = GetTime();
            progressBar.Maximum = time;
            progressBar.Value = time;

            TimeSpan _time = TimeSpan.FromSeconds(time);
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                timeLabel.Text = _time.ToString(@"mm\:ss");
                progressBar.Value--;
                if (_time == TimeSpan.Zero)
                {
                    dispatcherTimer.Stop();
                    SendResultAndExitWindow(window, resultsWindow);
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            dispatcherTimer.Start();
        }

        #endregion


        //this method will be called when end_section_button clicked and when time is out
        public void SendResultAndExitWindow(UniversalTestWindow window, ResultsWindow resultsWindow)
        {
            List<int> incorrectQuestions = new List<int>();

            // calculating number of correct answers and getting incorrect questions
            for (int i = 0; i < Questions.Count; i++)
            {
                bool isQuestionCorrect = false;
                for (int j = 0; j < Questions[i].Question.QuestionAnswers.Count(); j++)
                {
                    if (Questions[i].ChosenAnswerId == Questions[i].Question.QuestionAnswers[j].Id && Questions[i].Question.QuestionAnswers[j].IsCorrect)
                        isQuestionCorrect = true;
                }

                if (isQuestionCorrect) NumberOfCorrectAnswers++;
                else if (i != 0) incorrectQuestions.Add(i+1);
            }

            DataHandlerService dataHandlerService = new DataHandlerService();

            if (_section.Name == "English Section")
            {
                resultsWindow.ExamResults.EnglishCorrectNumber = NumberOfCorrectAnswers;
                resultsWindow.ExamResults.EnglishIncorrectQuestionNumbers = incorrectQuestions;
                resultsWindow.ExamResults.EnglishTotalNumber = Questions.Count - 1;
                resultsWindow.ExamResults.EnglishGrade = dataHandlerService.GetExamGrade(_section.Id, NumberOfCorrectAnswers);
            }
            else if (_section.Name == "Math Section")
            {
                resultsWindow.ExamResults.MathCorrectNumber = NumberOfCorrectAnswers;
                resultsWindow.ExamResults.MathIncorrectQuestionNumbers = incorrectQuestions;
                resultsWindow.ExamResults.MathTotalNumber = Questions.Count - 1;
                resultsWindow.ExamResults.MathGrade = dataHandlerService.GetExamGrade(_section.Id, NumberOfCorrectAnswers);
            }
            else if (_section.Name == "Reading Section")
            {
                resultsWindow.ExamResults.ReadingCorrectNumber = NumberOfCorrectAnswers;
                resultsWindow.ExamResults.ReadingIncorrectQuestionNumbers = incorrectQuestions;
                resultsWindow.ExamResults.ReadingTotalNumber = Questions.Count - 1;
                resultsWindow.ExamResults.ReadingGrade = dataHandlerService.GetExamGrade(_section.Id, NumberOfCorrectAnswers);
            }
            else if (_section.Name == "Science Section")
            {
                resultsWindow.ExamResults.ScienceCorrectNumber = NumberOfCorrectAnswers;
                resultsWindow.ExamResults.ScienceIncorrectQuestionNumbers = incorrectQuestions;
                resultsWindow.ExamResults.ScienceTotalNumber = Questions.Count - 1;
                resultsWindow.ExamResults.ScienceGrade = dataHandlerService.GetExamGrade(_section.Id, NumberOfCorrectAnswers);
            }

            window.Close();
        }


        #region Filling 
        public void FillQuestionInfo(Paragraph questionPassageParagraph, TextBlock questionTextBlock)
        {
            questionTextBlock.Visibility = Visibility.Visible;

            if (Questions[CurrentQuestionIndex].Question.Text == String.Empty &&
                Questions[CurrentQuestionIndex].Question.PhotoName == String.Empty)
            {
                Questions[CurrentQuestionIndex].Question.Text = Questions[CurrentQuestionIndex].Question.QuestionContent;
                questionTextBlock.Visibility = Visibility.Collapsed;
                Questions[CurrentQuestionIndex].Question.QuestionContent = String.Empty;
            }

            Converter.ConvertToParagraph(questionPassageParagraph,
                Questions[CurrentQuestionIndex].Question.Text, 16);

            questionTextBlock.Inlines.Clear();

            string questionContent = Questions[CurrentQuestionIndex].Question.QuestionContent;

            if (!String.IsNullOrEmpty(questionContent))
                questionTextBlock.Inlines.Add(questionContent);
            else questionTextBlock.Visibility = Visibility.Collapsed;
        }

        public void FillImage(BlockUIContainer imageContainer)
        {
            imageContainer.Child = null;
            string photoname = Questions[CurrentQuestionIndex].Question.PhotoName;
            if (String.IsNullOrEmpty(photoname))
            {
                //if (imageContainer.Child != null) (imageContainer.Child as Image).Visibility = Visibility.Hidden;
                return;
            }
            imageContainer.Child = CreateImage(photoname.Split('&')[0], false);
        }
        public void FillAnswers(UniversalTestWindow window, int answersPerQuestion)
        {
            List<QuestionAnswer> answers = (List<QuestionAnswer>)Questions[CurrentQuestionIndex].Question.QuestionAnswers;
            if (answers == null) return;
            for (int i = 0; i < answers.Count; i++)
            {

                var answerGrid = (Grid)window.FindName($"GridAns{i + 1}");
                answerGrid.Visibility = Visibility.Visible;
                var answer = (Paragraph)window.FindName($"BodyAns{i + 1}");
                Converter.ConvertToParagraph(answer, (Questions[CurrentQuestionIndex].Question.QuestionAnswers as List<QuestionAnswer>)[i].Text, 16);
                var imageContainer = (BlockUIContainer)window.FindName($"imageContainer{i + 1}");

                imageContainer.Child = null;
                _ = imageContainer.Child == null ? answer.Margin = new Thickness(0, 5, 0, 0) : answer.Margin = new Thickness(0, 0, 0, 0);

                String photoname = (Questions[CurrentQuestionIndex].Question.QuestionAnswers as List<QuestionAnswer>)[i].PhotoName;
                if (String.IsNullOrEmpty(photoname)) continue;

                imageContainer.Child = CreateImage(photoname.Split('&')[0], true);
            }
            for (int i = answers.Count; i < answersPerQuestion; i++)
            {
                var answerGrid = (Grid)window.FindName($"GridAns{i + 1}");
                answerGrid.Visibility = Visibility.Collapsed;
            }
        }


        //Method is user by FillImage and FillAnswers
        Image CreateImage(string photoName, bool isAnswer)
        {
            if (!String.IsNullOrEmpty(photoName))
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(ApiUri.ActApiUri + "/" + photoName, UriKind.Absolute));
                Image image = new Image()
                {
                    Source = bitmapImage,
                    Visibility = Visibility.Visible,
                    Stretch = Stretch.Fill

                };
                if (bitmapImage.IsDownloading)
                {
                    bitmapImage.DownloadCompleted += (e, arg) =>
                    {

                        if (bitmapImage.PixelWidth > 150 && bitmapImage.PixelHeight > 150 && isAnswer)
                        {
                            image.Width = bitmapImage.PixelWidth / (bitmapImage.PixelHeight / 150);
                            image.Height = bitmapImage.PixelHeight / (bitmapImage.PixelHeight / 150);
                        }
                    };
                }


                image.HorizontalAlignment = HorizontalAlignment.Left;
                return image;
            }
            else
            {

                return null;
            }
        }


        #endregion
        #region Buttons Conditions
        public void ChangeBtnToActive(Button btn)
        {
            //changes color to red
            btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e42a22"));
            btn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f2f2f2"));
            btn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f2f2f2"));
            btn.FontWeight = FontWeights.Bold;
            btn.BorderThickness = new Thickness(2);
        }
        public void ChangeBtnToPassive(Button btn)
        {
            //changes color to white
            btn.Background = new SolidColorBrush(Colors.White);
            btn.Foreground = new SolidColorBrush((Colors.Black));
            btn.BorderBrush = new SolidColorBrush((Colors.Black));
            btn.FontWeight = FontWeights.Normal;
            btn.BorderThickness = new Thickness(1);
        }
        public void ChangeBtnToAnswered(Button btn)
        {
            //changes color to white
            btn.Background = new SolidColorBrush(Colors.DarkGray);
            btn.Foreground = new SolidColorBrush((Colors.Black));
            btn.BorderBrush = new SolidColorBrush((Colors.Black));
            btn.FontWeight = FontWeights.Normal;
            btn.BorderThickness = new Thickness(1);
        }
        public void ChangeNavQuestToActive(StackPanel stack)
        {
            stack.Background = new SolidColorBrush(Colors.SkyBlue);
        }
        public void ChangeNavQuestToPassive(StackPanel stack)
        {
            stack.Background = new SolidColorBrush(Colors.LightGray);
        }
        #endregion
    }
}
