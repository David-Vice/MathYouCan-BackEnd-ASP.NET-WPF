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
    /// Interaction logic for UniversalTestWindow.xaml
    /// </summary>
    public partial class UniversalTestWindow : Window
    {
        public UniversalTestWindow()
        {
            InitializeComponent();
        }

        private void AssignImageSources()
        {
            actLogoImage.Source = new BitmapImage(new Uri("pack://application:,,,/Img/mathyoucan_logo.png"));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AssignImageSources();
        }
    }
}
