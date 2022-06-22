using MathYouCan.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
       
        public Login()
        {
            InitializeComponent();
        }
       
        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Label).Opacity = 0.5;

        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Label).Opacity = 1;
        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
             if(MessageBox.Show("Do you want to exit MathYouCan?", "Exit", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
             {
                Close();
             }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string jsonData=_authValidatorService.AreValidCredentials(mailTextBox.Text, passwordBox.Password);
            //AuthUserConverterService.GetData(jsonData);
            if (mailTextBox.Text!=""&&passwordBox.Password!="")
            {
                DataHandlerService dataHandlerService = new DataHandlerService();

                //dataHandlerService.GetLoginResult(mailTextBox.Text, passwordBox.Password);
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Email or password is not provided","Error",System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        //private void ins_Click(object sender, RoutedEventArgs e)
        //{
        //    InstructionsWindow instructionsWindow = new InstructionsWindow();
        //    Close();
        //    instructionsWindow.ShowDialog();
        //}
    }
}
