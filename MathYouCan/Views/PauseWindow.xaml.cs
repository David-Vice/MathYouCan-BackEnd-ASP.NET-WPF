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
using System.Windows.Threading;

namespace MathYouCan.Views
{
    /// <summary>
    /// Interaction logic for PauseWindow.xaml
    /// </summary>
    public partial class PauseWindow : Window
    {
        TimeSpan _time = TimeSpan.FromSeconds(10*60-1);
        public PauseWindow()
        {
            InitializeComponent();
            
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                TimerLabel.Content = _time.ToString(@"mm\:ss");
                if (_time == TimeSpan.Zero)
                {
                    dispatcherTimer.Stop();
                    Close();
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            dispatcherTimer.Start();
        }

    }
}
