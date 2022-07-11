using MathYouCan.Models.Exams;
using MathYouCan.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MathYouCan.Views
{
    /// <summary>
    /// Interaction logic for TestSelection.xaml
    /// </summary>
    public partial class TestSelection : Window
    {
        public int SelectedOfflineExamId { get; set; } = -1;

        private List<OfflineExam> _offlineExams = new List<OfflineExam>(); 
        public TestSelection()
        {
            InitializeComponent();

            FillListBox();
        }

        private void FillListBox()
        {
            DataHandlerService dataHandlerService = new DataHandlerService();
            _offlineExams = dataHandlerService.GetAllOfflineExams().ToList();

            for (int i = 0; i < _offlineExams.Count(); i++)
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = _offlineExams[i].Name;
                lbi.FontSize = 17;
                lbi.BorderThickness = new Thickness(0, 0, 0, 0.5);
                lbi.BorderBrush = new SolidColorBrush(Colors.LightGray);
                lbi.Margin = new Thickness(10, 2, 10, 1);
                lbi.Padding = new Thickness(0, 6, 0, 0);
                examsListBox.Items.Add(lbi);
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


        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedOfflineExamId == -1)
            {
                MessageBox.Show("Please select a test to continue.", "No test selected", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Close();
        }

        private void examsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedOfflineExamId = _offlineExams.Where(x => x.Name == (examsListBox.SelectedValue as ListBoxItem).Content.ToString()).Select(x => x.Id).FirstOrDefault();
        }
    }
}
