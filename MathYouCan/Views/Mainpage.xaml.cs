using MathYouCan.Models.Exams;
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
    /// Interaction logic for Mainpage.xaml
    /// </summary>
    public partial class Mainpage : Window
    {
        private OfflineExam _exam;
        public Mainpage(OfflineExam exam)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //time check and so on
            //
            List<UniversalTestWindow> windows = new List<UniversalTestWindow>();
            
            for (int i = 0; i < _exam.Sections.Count(); i++)
            {
                windows.Add( new UniversalTestWindow(_exam.Sections.ElementAt(i)));
                if (i==2)
                {
                    //open break-time window
                }
                if(windows[i].ShowDialog()==true)
                {
                    continue;
                }
            }
        }
    }
}
