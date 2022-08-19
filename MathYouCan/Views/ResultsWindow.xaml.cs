using MathYouCan.Models;
using MathYouCan.Services.Concrete;
using System;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MathYouCan.Views
{
    /// <summary>
    /// Interaction logic for ResultsWindow.xaml
    /// </summary>
    public partial class ResultsWindow : Window
    {
        private UserCredentials _userCredentials;
        public ExamResults ExamResults { get; } = new ExamResults();
        public ResultsWindow(UserCredentials userCredentials)
        {
            _userCredentials = userCredentials;
            InitializeComponent();
        }

        #region On Window Load

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetWindowDefaultSettings();
            AssignImageSources();

            FillResultsTable();
            FillIncorrectQuestions();
            SaveResults();
        }


        private void AssignImageSources()
        {
            actLogoImage.Source = new BitmapImage(new Uri("pack://application:,,,/Img/large.png"));
        }

        private void SetWindowDefaultSettings()
        {
            this.WindowState = WindowState.Maximized;
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FillResultsTable()
        {
            englishCorrectNumber.Content = ExamResults.EnglishCorrectNumber;
            mathCorrectNumber.Content = ExamResults.MathCorrectNumber;
            readingCorrectNumber.Content = ExamResults.ReadingCorrectNumber;
            scienceCorrectNumber.Content = ExamResults.ScienceCorrectNumber;

            englishTotal.Content = ExamResults.EnglishTotalNumber;
            mathTotal.Content = ExamResults.MathTotalNumber;
            readingTotal.Content = ExamResults.ReadingTotalNumber;
            scienceTotal.Content = ExamResults.ScienceTotalNumber;

            englishGrade.Content = ExamResults.EnglishGrade;
            mathGrade.Content = ExamResults.MathGrade;
            readingGrade.Content = ExamResults.ReadingGrade;
            scienceGrade.Content = ExamResults.ScienceGrade;

            totalGrade.Content = GetFinalGrade();
        }

        private void FillIncorrectQuestions()
        {
            Border border;
            Label label;

            for (int i = 0; i < ExamResults.EnglishIncorrectQuestionNumbers.Count; i++)
            {
                border = new Border();
                border.BorderThickness = new Thickness(1);
                border.BorderBrush = Brushes.Black;
                border.Width = 35;

                label = new Label();
                label.FontSize = 18;
                label.FontWeight = FontWeights.Bold;
                label.Foreground = Brushes.Red;
                label.Content = ExamResults.EnglishIncorrectQuestionNumbers[i];
                label.VerticalAlignment = VerticalAlignment.Center;
                label.HorizontalAlignment = HorizontalAlignment.Center;

                border.Child = label;

                englishIncorrectQuestionStackPanel.Children.Add(border);
            }

            for (int i = 0; i < ExamResults.MathIncorrectQuestionNumbers.Count; i++)
            {
                border = new Border();
                border.BorderThickness = new Thickness(1);
                border.BorderBrush = Brushes.Black;
                border.Width = 35;

                label = new Label();
                label.FontSize = 18;
                label.FontWeight = FontWeights.Bold;
                label.Foreground = Brushes.Red;
                label.Content = ExamResults.MathIncorrectQuestionNumbers[i];
                label.VerticalAlignment = VerticalAlignment.Center;
                label.HorizontalAlignment = HorizontalAlignment.Center;

                border.Child = label;

                mathIncorrectQuestionStackPanel.Children.Add(border);
            }

            for (int i = 0; i < ExamResults.ReadingIncorrectQuestionNumbers.Count; i++)
            {
                border = new Border();
                border.BorderThickness = new Thickness(1);
                border.BorderBrush = Brushes.Black;
                border.Width = 35;

                label = new Label();
                label.FontSize = 18;
                label.FontWeight = FontWeights.Bold;
                label.Foreground = Brushes.Red;
                label.Content = ExamResults.ReadingIncorrectQuestionNumbers[i];
                label.VerticalAlignment = VerticalAlignment.Center;
                label.HorizontalAlignment = HorizontalAlignment.Center;

                border.Child = label;

                readingIncorrectQuestionStackPanel.Children.Add(border);
            }

            for (int i = 0; i < ExamResults.ScienceIncorrectQuestionNumbers.Count; i++)
            {
                border = new Border();
                border.BorderThickness = new Thickness(1);
                border.BorderBrush = Brushes.Black;
                border.Width = 35;

                label = new Label();
                label.FontSize = 18;
                label.FontWeight = FontWeights.Bold;
                label.Foreground = Brushes.Red;
                label.Content = ExamResults.ScienceIncorrectQuestionNumbers[i];
                label.VerticalAlignment = VerticalAlignment.Center;
                label.HorizontalAlignment = HorizontalAlignment.Center;

                border.Child = label;

                scienceIncorrectQuestionStackPanel.Children.Add(border);
            }
        }
        private double total = 0;

        private string GetFinalGrade()
        {
            
            if (ExamResults.EnglishGrade != "Score not provided")
            {
                total+=Convert.ToInt32(ExamResults.EnglishGrade);
            }

            if (ExamResults.MathGrade != "Score not provided")
            {
                total += Convert.ToInt32(ExamResults.MathGrade);
            }

            if (ExamResults.ReadingGrade != "Score not provided")
            {
                total += Convert.ToInt32(ExamResults.ReadingGrade);
            }

            if (ExamResults.ScienceGrade != "Score not provided")
            {
                total += Convert.ToInt32(ExamResults.ScienceGrade);
            }
            total = Math.Round(total / 4, 2);
            return total.ToString();
        }
        private void SendResults()
        {
            SmtpClient Smtp = new SmtpClient();
            Smtp.UseDefaultCredentials = false;
            var NetworkCredentials = new NetworkCredential() { UserName = "noreply.mathyoucan@gmail.com", Password = "uywrwmokrazvreyb" };
            Smtp.Port = 587;
            Smtp.EnableSsl = true;
            Smtp.Host = "smtp.gmail.com";
            Smtp.Credentials = NetworkCredentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("noreply.mathyoucan@gmail.com");
            msg.To.Add(mailTextBox.Text);
            msg.Subject = "Your ACT Exam Results";
            msg.IsBodyHtml=true;

            string englishErrors = "";
            string mathErrors = "";
            string readingErrors = "";
            string scienceErrors = "";

            for (int i = 0; i < ExamResults.EnglishIncorrectQuestionNumbers.Count; i++)
            {
                englishErrors += $"{ExamResults.EnglishIncorrectQuestionNumbers[i]}";
                if (i!= ExamResults.EnglishIncorrectQuestionNumbers.Count-1)
                {
                    englishErrors += ", ";
                }
            }
            for (int i = 0; i < ExamResults.MathIncorrectQuestionNumbers.Count; i++)
            {
                mathErrors += $"{ExamResults.MathIncorrectQuestionNumbers[i]}";
                if (i != ExamResults.MathIncorrectQuestionNumbers.Count - 1)
                {
                    mathErrors += ", ";
                }
            }
            for (int i = 0; i < ExamResults.ReadingIncorrectQuestionNumbers.Count; i++)
            {
                readingErrors += $"{ExamResults.ReadingIncorrectQuestionNumbers[i]}";
                if (i != ExamResults.ReadingIncorrectQuestionNumbers.Count - 1)
                {
                    readingErrors += ", ";
                }
            }
            for (int i = 0; i < ExamResults.ScienceIncorrectQuestionNumbers.Count; i++)
            {
                scienceErrors += $"{ExamResults.ScienceIncorrectQuestionNumbers[i]}";
                if (i != ExamResults.ScienceIncorrectQuestionNumbers.Count - 1)
                {
                    scienceErrors += ", ";
                }
            }
            msg.Body = $"<h1>Dear {_userCredentials.Name} {_userCredentials.Surname}</h1>" +
                "<p>Thanks for passing ACT test at Mathyoucan!</p>" +
                $"<p>English section: <strong>{ExamResults.EnglishGrade}</strong> </p>" +
                $"<p>Math section: <strong>{ExamResults.MathGrade}</strong> </p>" +
                $"<p>Reading section: <strong>{ExamResults.ReadingGrade}</strong> </p>" +
                $"<p>Science section: <strong>{ExamResults.ScienceGrade}</strong> </p>" +
                $"<h2>Incorrect questions </h2>" +
                $"<p>English section:{englishErrors}" +
                $"<p>Math section: {mathErrors}" +
                $"<p>Reading section: {readingErrors} </p>" +
                $"<p>Science section: {scienceErrors}</p>" +
                $"<h3>Your total score : {total} </h3>";
               
            Smtp.Send(msg);


        }
        private void SaveResults()
        {
            
            DataHandlerService dataHandlerService = new DataHandlerService();
           
            dataHandlerService.AddStudent(_userCredentials.Name, _userCredentials.Surname,ExamResults.EnglishGrade,ExamResults.MathGrade,ExamResults.ReadingGrade,ExamResults.ScienceGrade,total);
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (mailTextBox.Text=="")
            {
                System.Windows.Forms.MessageBox.Show($"Please enter your email", "Mail", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }
            SendResults();
            System.Windows.Forms.MessageBox.Show($"Your results has been sent on email {mailTextBox.Text}","Sent",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Asterisk);
        }
    }
}
