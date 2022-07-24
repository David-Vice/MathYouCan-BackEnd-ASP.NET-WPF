using MathYouCan.Models;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MathYouCan.Views
{
    /// <summary>
    /// Interaction logic for ResultsWindow.xaml
    /// </summary>
    public partial class ResultsWindow : Window
    {
        public ExamResults ExamResults { get; } = new ExamResults();
        public ResultsWindow()
        {
            InitializeComponent();
        }

        #region On Window Load

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetWindowDefaultSettings();
            AssignImageSources();
            FillResultsTable();
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
            mathCorrectNumber.Content= ExamResults.MathCorrectNumber;
            readingCorrectNumber.Content = ExamResults.ReadingCorrectNumber;
            scienceCorrectNumber.Content = ExamResults.ScienceCorrectNumber;

            englishTotal.Content = ExamResults.EnglishTotalNumber;
            mathTotal.Content = ExamResults.MathTotalNumber;
            readingTotal.Content = ExamResults.ReadingTotalNumber;
            scienceTotal.Content = ExamResults.ScienceTotalNumber;

            englishGrade.Content = ExamResults.EnglishGrade;
            mathGrade.Content= ExamResults.MathGrade;
            readingGrade.Content = ExamResults.ReadingGrade;
            scienceGrade.Content = ExamResults.ScienceGrade;
        }
    }
}
