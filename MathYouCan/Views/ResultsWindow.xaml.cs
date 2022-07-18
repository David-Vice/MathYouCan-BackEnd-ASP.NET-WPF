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
    /// <summary>
    /// Interaction logic for ResultsWindow.xaml
    /// </summary>
    public partial class ResultsWindow : Window
    {
        public ResultsWindow()
        {
            InitializeComponent();
            MathAnswers = "0/0";
            EnglishAnswers = "0/0";
            ScienceAnswers = "0/0";
            ReadingAnswers = "0/0";
        }
        public string MathAnswers {
            set
            {
                mathResults.Content = value;
            }
        }
        public string ScienceAnswers
        {
            set
            {
                scienceResults.Content = value;
            }
        }
        public string ReadingAnswers
        {
            set
            {
                readingResults.Content = value;
            }
        }
        public string EnglishAnswers
        {
            set
            {
                englishResults.Content = value;
            }
        }
        #region On Window Load

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetWindowDefaultSettings();
            AssignImageSources();
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
    }
}
