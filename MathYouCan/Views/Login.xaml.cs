using MathYouCan.Services.Abstract;
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
        IAuthValidatorService _authValidatorService;

        public Login()
        {
            InitializeComponent();
            _authValidatorService = new AuthValidatorService();
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
             if(MessageBox.Show("Do you really want to exit MathYouCan?", "Exit", MessageBoxButton.YesNo).ToString() == "Yes")
             {
                Close();
             }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           string jsonData=_authValidatorService.AreValidCredentials(mailTextBox.Text, passwordBox.Password);
           
              AuthUserConverterService.GetData(jsonData);
        }

        private void ins_Click(object sender, RoutedEventArgs e)
        {
            InstructionsWindow instructionsWindow = new InstructionsWindow();
            instructionsWindow.ShowDialog();
        }
    }
}
