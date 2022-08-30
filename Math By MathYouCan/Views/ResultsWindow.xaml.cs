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
           
            mathCorrectNumber.Content = ExamResults.MathCorrectNumber;


            mathTotal.Content = ExamResults.MathTotalNumber;

            mathGrade.Content = ExamResults.MathGrade;


            totalGrade.Content = GetFinalGrade();
        }

        private void FillIncorrectQuestions()
        {
            Border border;
            Label label;

           
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
        }
        private double total = 0;

        private string GetFinalGrade()
        {
            if (ExamResults.MathGrade != "Score not provided")
            {
                total += Convert.ToInt32(ExamResults.MathGrade);
            }
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

            string mathErrors = "";

            
            for (int i = 0; i < ExamResults.MathIncorrectQuestionNumbers.Count; i++)
            {
                mathErrors += $"{ExamResults.MathIncorrectQuestionNumbers[i]}";
                if (i != ExamResults.MathIncorrectQuestionNumbers.Count - 1)
                {
                    mathErrors += ", ";
                }
            }
           
            msg.Body = $"<h1>Dear {_userCredentials.Name} {_userCredentials.Surname}</h1>" +
                "<p>Thanks for passing ACT test at Mathyoucan!</p>" +
            
                $"<p>Math section: <strong>{ExamResults.MathGrade}</strong> </p>" +
            
                $"<h2>Incorrect questions </h2>" +
            
                $"<p>Math section: {mathErrors}" +
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
