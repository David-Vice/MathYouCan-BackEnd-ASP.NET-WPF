using MathYouCan.Converters;
using MathYouCan.Models.Exams;
using MathYouCan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MathYouCan.Views
{
    /// <summary>
    /// Interaction logic for InstructionsWindow.xaml
    /// </summary>
    public partial class InstructionsWindow : Window
    {
        private InstructionWindowViewModel _instructionWindowViewModel;
        private List<Button> _buttons = new List<Button>();
        public InstructionsWindow()
        {
            _instructionWindowViewModel = new InstructionWindowViewModel();
            InitializeComponent();
        }

        #region On Window Load

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetWindowDefaultSettings();
            AssignImageSources();
            CreateButtons();

            UpdateWindow();
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



        #region Updating Window

        //этот метод вызывается вначале 1 раз и еще каждый раз когда пользователь меняет вопрос кликая на кнопки changeQuestionButton_Click
        // Must be called after creating buttons
        private void UpdateWindow()
        {
            UpdateWindowContent();

            //changes the color of exact button which was chosen as current
            ChangeBtnToActive(_buttons.Where(x => x.Content.ToString() == $"{_instructionWindowViewModel.CurrentInstructionIndex + 1}").First());
            
        }



        /// <summary>
        ///     -- Enables/Disables (nextButton), (prevButton)  depending on cuurent instruction number (_currentInstructionIndex)
        ///     -- Fills instruction content
        ///     -- Sets header for instruction content
        ///     -- Adds/Removes accept and decline buttons(Only appear at last instruction page)
        /// </summary>
        /// 
        private void UpdateWindowContent()
        {
            /* Enabling/Disabling next and prev buttons */

            // First instruction loaded
            if (_instructionWindowViewModel.CurrentInstructionIndex == 0)
            {
                prevButton.IsEnabled = false;
                nextButton.IsEnabled = true;
            }
            // Last instruction loaded
            else if (_instructionWindowViewModel.CurrentInstructionIndex == _instructionWindowViewModel.Instructions.Count - 1)
            {
                prevButton.IsEnabled = true;
                nextButton.IsEnabled = false;
            }
            else
            {
                prevButton.IsEnabled = true;
                nextButton.IsEnabled = true;
            }


            /* Add/Remove accept dectline buttons*/

            if (_instructionWindowViewModel.CurrentInstructionIndex == _instructionWindowViewModel.Instructions.Count - 1)
            {
                acceptButton.Click += acceptButton_Click;
             

                acceptDeclineStackPanel.Visibility = Visibility.Visible;
            }
            else
            {
                acceptButton.Click -= acceptButton_Click;
         

                acceptDeclineStackPanel.Visibility = Visibility.Hidden;
            }


            FillInstruction();
            instructionSectionNameLabel.Content = _instructionWindowViewModel.Instructions[_instructionWindowViewModel.CurrentInstructionIndex].Header;

        }


        #endregion



        /// <summary>
        /// Sets instruction text to instructionContent(Stack Panel) according to current Instruction index(CurrentInstructionIndex) from view model
        /// </summary>
        public void FillInstruction()
        {
            TextToFlowDocumentConverter textTo = new TextToFlowDocumentConverter(Brushes.Yellow, Brushes.GreenYellow);
            textTo.ConvertToParagraph(instructionContentParagraph, _instructionWindowViewModel.Instructions[_instructionWindowViewModel.CurrentInstructionIndex].InstructionText);
        }


        #region Lower Panel Buttons

        private void CreateButtons()
        {
            for (int i = 0; i < _instructionWindowViewModel.Instructions.Count; i++)
            {
                Button btn = new Button();
                btn.Name = $"btn{i + 1}";
                btn.Height = 30;

                btn.Width = 27;
                Thickness margin = btn.Margin;
                margin.Left = 3;
                margin.Bottom = 0;
                btn.Margin = margin;
                btn.Content = $"{i + 1}";
                btn.Click += changeInstructionButton_Click;
                btn.Background = new SolidColorBrush(Colors.White);

                var style = new Style
                {
                    TargetType = typeof(Border),
                    Setters = { new Setter { Property = Border.CornerRadiusProperty, Value = new CornerRadius(3) } }
                };
                btn.Resources.Add(style.TargetType, style);

                _buttons.Add(btn);
                questionsStackPanel.Children.Add(btn);
            }

        }


        private void changeInstructionButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeBtnToPassive(_buttons.Where(x => x.Content.ToString() == $"{_instructionWindowViewModel.CurrentInstructionIndex + 1}").First());
            _instructionWindowViewModel.CurrentInstructionIndex = int.Parse((sender as Button).Content.ToString()) - 1;
            //Save chosen answer
            UpdateWindow();
        }

        private void ChangeBtnToActive(Button btn)
        {
            //changes color to red
            btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e42a22"));
            btn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f2f2f2"));
            btn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f2f2f2"));
            btn.FontWeight = FontWeights.Bold;
            btn.BorderThickness = new Thickness(2);
        }
        private void ChangeBtnToPassive(Button btn)
        {
            //changes color to white
            btn.Background = new SolidColorBrush(Colors.White);
            btn.Foreground = new SolidColorBrush((Colors.Black));
            btn.BorderBrush = new SolidColorBrush((Colors.Black));
            btn.FontWeight = FontWeights.Normal;
            btn.BorderThickness = new Thickness(1);
        }

        #endregion


        #region Prev, Nav, Next Button Events

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeBtnToPassive(_buttons.Where(x => x.Content.ToString() == $"{_instructionWindowViewModel.CurrentInstructionIndex + 1}").First());
            _instructionWindowViewModel.CurrentInstructionIndex++;
            UpdateWindow();
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeBtnToPassive(_buttons.Where(x => x.Content.ToString() == $"{_instructionWindowViewModel.CurrentInstructionIndex + 1}").First());
            _instructionWindowViewModel.CurrentInstructionIndex--;
            UpdateWindow();
        }

        #endregion


        #region Accept and Decline Buttons Events

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       


        #endregion
    }
}
