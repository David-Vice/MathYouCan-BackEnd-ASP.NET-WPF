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
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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


        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #region Bindings
        private string questionImage = "";
        public string QuestionImage
        {
            get => questionImage;
            set
            {
                if (!questionImage.Equals(value))
                {
                    questionImage = value;
                    OnPropertyChanged(nameof(QuestionImage));
                }
            }

        }
        private string questionImageWidth = "";
        public string QuestionImageWidth
        {
            get => questionImageWidth;
            set
            {
                if (!questionImageWidth.Equals(value))
                {
                    questionImageWidth = value;
                    OnPropertyChanged(nameof(QuestionImageWidth));
                }
            }

        }
        private string questionImageHeight = "";
        public string QuestionImageHeight
        {
            get => questionImageHeight;
            set
            {
                if (!questionImageHeight.Equals(value))
                {
                    questionImageHeight = value;
                    OnPropertyChanged(nameof(QuestionImageHeight));
                }
            }

        }
        private string answerImage1 = "";
        public string AnswerImage1
        {
            get { return answerImage1; }
            set
            {
                if (!answerImage1.Equals(value))
                {
                    answerImage1 = value;
                    OnPropertyChanged(nameof(AnswerImage1));
                }
            }
        }
        private string answerImageWidth1 = "";
        public string AnswerImageWidth1
        {
            get { return answerImageWidth1; }
            set
            {
                if (!answerImageWidth1.Equals(value))
                {
                    answerImageWidth1 = value;
                    OnPropertyChanged(nameof(AnswerImageWidth1));
                }
            }
        }
        private string answerImageHeight1 = "";
        public string AnswerImageHeight1
        {
            get { return answerImageHeight1; }
            set
            {
                if (!answerImageHeight1.Equals(value))
                {
                    answerImageHeight1 = value;
                    OnPropertyChanged(nameof(AnswerImageHeight1));
                }
            }
        }
        private string answerImage2 = "";
        public string AnswerImage2
        {
            get { return answerImage2; }
            set
            {
                if (!answerImage2.Equals(value))
                {
                    answerImage2 = value;
                    OnPropertyChanged(nameof(AnswerImage2));
                }
            }
        }
        private string answerImageWidth2 = "";
        public string AnswerImageWidth2
        {
            get { return answerImageWidth2; }
            set
            {
                if (!answerImageWidth2.Equals(value))
                {
                    answerImageWidth2 = value;
                    OnPropertyChanged(nameof(AnswerImageWidth2));
                }
            }
        }
        private string answerImageHeight2 = "";
        public string AnswerImageHeight2
        {
            get { return answerImageHeight2; }
            set
            {
                if (!answerImageHeight2.Equals(value))
                {
                    answerImageHeight2 = value;
                    OnPropertyChanged(nameof(AnswerImageHeight2));
                }
            }
        }
        private string answerImage3 = "";
        public string AnswerImage3
        {
            get { return answerImage3; }
            set
            {
                if (!answerImage3.Equals(value))
                {
                    answerImage3 = value;
                    OnPropertyChanged(nameof(AnswerImage3));
                }
            }
        }
        private string answerImageWidth3 = "";
        public string AnswerImageWidth3
        {
            get { return answerImageWidth3; }
            set
            {
                if (!answerImageWidth3.Equals(value))
                {
                    answerImageWidth3 = value;
                    OnPropertyChanged(nameof(AnswerImageWidth3));
                }
            }
        }
        private string answerImageHeight3 = "";
        public string AnswerImageHeight3
        {
            get { return answerImageHeight3; }
            set
            {
                if (!answerImageHeight3.Equals(value))
                {
                    answerImageHeight3 = value;
                    OnPropertyChanged(nameof(AnswerImageHeight3));
                }
            }
        }
        private string answerImage4 = "";
        public string AnswerImage4
        {
            get { return answerImage4; }
            set
            {
                if (!answerImage4.Equals(value))
                {
                    answerImage4 = value;
                    OnPropertyChanged(nameof(AnswerImage4));
                }
            }
        }
        private string answerImageWidth4 = "";
        public string AnswerImageWidth4
        {
            get { return answerImageWidth4; }
            set
            {
                if (!answerImageWidth4.Equals(value))
                {
                    answerImageWidth4 = value;
                    OnPropertyChanged(nameof(AnswerImageWidth4));
                }
            }
        }
        private string answerImageHeight4 = "";
        public string AnswerImageHeight4
        {
            get { return answerImageHeight4; }
            set
            {
                if (!answerImageHeight4.Equals(value))
                {
                    answerImageHeight4 = value;
                    OnPropertyChanged(nameof(AnswerImageHeight4));
                }
            }
        }
        private string answerImage5 = "";
        public string AnswerImage5
        {
            get { return answerImage5; }
            set
            {
                if (!answerImage5.Equals(value))
                {
                    answerImage5 = value;
                    OnPropertyChanged(nameof(AnswerImage5));
                }
            }
        }
        private string answerImageWidth5 = "";
        public string AnswerImageWidth5
        {
            get { return answerImageWidth5; }
            set
            {
                if (!answerImageWidth5.Equals(value))
                {
                    answerImageWidth5 = value;
                    OnPropertyChanged(nameof(AnswerImageWidth5));
                }
            }
        }
        private string answerImageHeight5 = "";
        public string AnswerImageHeight5
        {
            get { return answerImageHeight5; }
            set
            {
                if (!answerImageHeight5.Equals(value))
                {
                    answerImageHeight5 = value;
                    OnPropertyChanged(nameof(AnswerImageHeight5));
                }
            }
        }
        #endregion
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

            instruction.Question.QuestionContent = ins.Header + "\n" + ins.InstructionText;
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
                else if (i != 0) incorrectQuestions.Add(i);
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

            if (Questions[CurrentQuestionIndex].Question.QuestionContent == String.Empty &&
                Questions[CurrentQuestionIndex].Question.PhotoName == String.Empty)
            {
                Questions[CurrentQuestionIndex].Question.QuestionContent = Questions[CurrentQuestionIndex].Question.Text;
                questionTextBlock.Visibility = Visibility.Collapsed;
                Questions[CurrentQuestionIndex].Question.Text = String.Empty;
            }

            Converter.ConvertToParagraph(questionPassageParagraph,
                Questions[CurrentQuestionIndex].Question.QuestionContent, 16);

            questionTextBlock.Inlines.Clear();

            string questionContent = Questions[CurrentQuestionIndex].Question.Text;

            if (!String.IsNullOrEmpty(questionContent))
                questionTextBlock.Inlines.Add(questionContent);
            else questionTextBlock.Visibility = Visibility.Collapsed;
        }

        public void FillImage()
        {
          //  imageContainer.Source=null;
            String photoname = Questions[CurrentQuestionIndex].Question.PhotoName;
            if (String.IsNullOrEmpty(photoname))
            {
                QuestionImage = "";
                //if (imageContainer.Child != null) (imageContainer.Child as Image).Visibility = Visibility.Hidden;
                return;
            }
            QuestionImage = ApiUri.ActApiUri + "/" + photoname.Split('&')[0];
            byte[] imageData = new WebClient().DownloadData(ApiUri.ActApiUri + "/" + photoname.Split('&')[0]);
            MemoryStream imgStream = new MemoryStream(imageData);
            System.Drawing.Image img = System.Drawing.Image.FromStream(imgStream);
           // QuestionImageHeight=$"{img.Height}";
          //  QuestionImageWidth=$"{img.Width}";
            //imageContainer.Source=new BitmapImage(new Uri( ApiUri.ActApiUri + "/" + photoname));

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
                
                String photoname = (Questions[CurrentQuestionIndex].Question.QuestionAnswers as List<QuestionAnswer>)[i].PhotoName;
                if (String.IsNullOrEmpty(photoname)) {
                    if (i + 1 == 1) AnswerImage1 = "";
                    if (i + 1 == 2) AnswerImage2 = "";
                    if (i + 1 == 3) AnswerImage3 = "";
                    if (i + 1 == 4) AnswerImage4 = "";
                    if (i + 1 == 5) AnswerImage5 = "";
                    continue;
                }
                //byte[] imageData = new WebClient().DownloadData(ApiUri.ActApiUri + "/" + photoname.Split('&')[0]);
                //MemoryStream imgStream = new MemoryStream(imageData);
                //System.Drawing.Image img = System.Drawing.Image.FromStream(imgStream);

                if (i + 1 == 1) { 
                    AnswerImage1 = ApiUri.ActApiUri + "/" + photoname.Split('&')[0];
                 //   AnswerImageHeight1 = $"{img.Height}";
                 //   AnswerImageWidth1 = $"{img.Width}";

                }
                if (i + 1 == 2) { 
                    AnswerImage2 = ApiUri.ActApiUri + "/" + photoname.Split('&')[0];
                }
                if (i + 1 == 3) { 
                    AnswerImage3 = ApiUri.ActApiUri + "/" + photoname.Split('&')[0];
                }
                if (i + 1 == 4) { 
                    AnswerImage4 = ApiUri.ActApiUri + "/" + photoname.Split('&')[0];
                }
                if (i + 1 == 5) { 
                    AnswerImage5 = ApiUri.ActApiUri + "/" + photoname.Split('&')[0];
                }

                //imageContainer.Child = CreateImage(photoname.Split('&')[0], true);

            }
            for (int i = answers.Count; i < answersPerQuestion; i++)
            {
                var answerGrid = (Grid)window.FindName($"GridAns{i + 1}");
                answerGrid.Visibility = Visibility.Collapsed;
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
