using MathYouCan.Models;
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
    /// Interaction logic for StudentPrsonalInfoWindow.xaml
    /// </summary>
    public partial class StudentPrsonalInfoWindow : Window
    {
        UserCredentials _userCredentials;
        public StudentPrsonalInfoWindow(UserCredentials userCredentials)
        {
            InitializeComponent();
            _userCredentials = userCredentials;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text == String.Empty && surnameTextBox.Text == String.Empty)
                MessageBox.Show("Please provide your name and surname to proceed", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (nameTextBox.Text == String.Empty) 
                MessageBox.Show("Please provide your name to proceed", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (surnameTextBox.Text == String.Empty) 
                MessageBox.Show("Please provide your surname to proceed", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _userCredentials.Name = nameTextBox.Text;
                _userCredentials.Surname = surnameTextBox.Text;
                Close();
            }
        }
    }
}
