﻿using System;
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

    }
}
