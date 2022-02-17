using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MathYouCan.Views;

namespace MathYouCan
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                if (new UniversalTestWindow().ShowDialog() == true)
                {
                    new InstructionsWindow().ShowDialog();
                }
            }
            finally
            {
                Shutdown();
            }
        }
    }
}
