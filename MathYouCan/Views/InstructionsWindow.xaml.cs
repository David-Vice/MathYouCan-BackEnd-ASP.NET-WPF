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
    /// Interaction logic for InstructionsWindow.xaml
    /// </summary>
    public partial class InstructionsWindow : Window
    {
        private int _currentInstructionNumber = 1;

        public InstructionsWindow()
        {
            InitializeComponent();
        }
        private void LoadInstruction()
        {
            if (_currentInstructionNumber == 1) LoadInstruction1();
            else if (_currentInstructionNumber == 2) LoadInstruction2();
            else if (_currentInstructionNumber == 3) LoadInstruction3();
            else if (_currentInstructionNumber == 4) LoadInstruction4();
        }

        private void LoadInstruction1()
        {
            instructionSectionNameLabel.Content = "General Instructions";

            instructionContentTextBlock.Inlines.Clear();

            instructionContentTextBlock.Inlines.Add(new Bold(new Run("IMPORTANT: ")));
            instructionContentTextBlock.Inlines.Add(new Run("Read this information before selecting the"));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run(" Next ")));
            instructionContentTextBlock.Inlines.Add(new Run("button.\n\n"));
            instructionContentTextBlock.Inlines.Add(new Run("All items brought into the test center may be searched. Items susoected of being used to" +
                "engage in misconduct may be\nconfiscated and retained.\n\nCell phones, smart watches, fitness bands, and other devices with recording" +
                "or communication capabilities are\nprohibited.\n\nYou may not handle or access such devices during testing or during breaks. All" +
                " electronic devices must be powered off and\nstored out of sight. Turning your device to silent or airplane mode is not" +
                " acceptable.\n\nPlease clear your workstation of everything except your testing computer, scratch paper, and pencil. Place " +
                "all personal items\nunder your seat. You will not be able to access them during testing or during breaks. ACT and this test " +
                "site are not responsive for\nthe loss of any personal items. If you brought a calculator, put it under your seat now; you may " +
                "use it only during the\nmathematics test. Please keep the walking spaces clear.\n\nSelect the "));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("Next ")));
            instructionContentTextBlock.Inlines.Add(new Run("button to proceed."));
        }

        private void LoadInstruction2()
        {
            instructionSectionNameLabel.Content = "Prohibited Behaviour";

            instructionContentTextBlock.Inlines.Clear();

            instructionContentTextBlock.Inlines.Add(new Bold(new Run("IMPORTANT: ")));
            instructionContentTextBlock.Inlines.Add(new Run("Read this information before selecting the "));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("Next ")));
            instructionContentTextBlock.Inlines.Add(new Run("button.\n\nA complete list of the prohibited behaviours was provided during the registration" +
                "process. Please be reminded of the following:\n\n"));

            instructionContentTextBlock.Inlines.Add(new Bold(new Run("  •  ")));
            instructionContentTextBlock.Inlines.Add(new Run("You may not access an electronic device, other than your testing computer and " +
                "calculator (during Mathematics only), at any\ntime during the testing or during breaks. All devices, other than your computer, must be " +
                "powered off and placed out of the sight\nfrom the time you are admitted to the test room until you are dismissed.\n"));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("  •  ")));
            instructionContentTextBlock.Inlines.Add(new Run("You may not give or receive assistance by any means. This includes looking at another" +
                "person's computer or scratch paper.\n"));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("  •  ")));
            instructionContentTextBlock.Inlines.Add(new Run("You are not allowed to use any notes, dictionaries, or other aids.\n"));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("  •  ")));
            instructionContentTextBlock.Inlines.Add(new Run("You may use only the scratch paper provided to you.\n"));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("  •  ")));
            instructionContentTextBlock.Inlines.Add(new Run("You may not allow an alarm to sound in the test room or create any ither disturbance. " +
                "If you are wearing a watch with an\nalarm or have any other device, you must be sure it is turned off.\n"));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("  •  ")));
            instructionContentTextBlock.Inlines.Add(new Run("The test is confidential and remains so even after the exam is complete. You may not" +
                "remove any materials from the test\nroom. You may not discuss the test questions or responses at any time, including the break.\n"));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("  •  ")));
            instructionContentTextBlock.Inlines.Add(new Run("Finally, eating, drinking, and the use of tabacco or reading materials are not permitted " +
                "in the test room.\n\n"));

            instructionContentTextBlock.Inlines.Add(new Run("If you are observed or suspected of engaging in prohibited behaviour, you will be dismissed and " +
                "your test will not be scored.\n\n Testing staff will monitor the room. If you have a question during testing, raise your hand.\n\n" +
                "Select the "));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("Next ")));
            instructionContentTextBlock.Inlines.Add(new Run("button to proceed."));
        }

        private void LoadInstruction3()
        {
            instructionSectionNameLabel.Content = "Test Directions";

            instructionContentTextBlock.Inlines.Clear();

            instructionContentTextBlock.Inlines.Add(new Bold(new Run("IMPORTANT: ")));
            instructionContentTextBlock.Inlines.Add(new Run("Read this information before selecting the"));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run(" Next ")));
            instructionContentTextBlock.Inlines.Add(new Run("button.\n\nYou are about to take the ACT, which is composed of multiple-choice tests in English, " +
                "mathematics, reading, and science,\nfollewed by a writing test, for which you will complete an essay written in English.\n\nThese tests" +
                "measure skills and abilities highly related to high school course work and success in college. "));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("Calculators may be\nused on the mathematics only.\n\n")));
            instructionContentTextBlock.Inlines.Add(new Run("For each multiple-choice question, choose the best answer by selecting the circle next to it. " +
                "If you change your mind about an\nanswer, choose a different answer and select the circle next to it. Select the "));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("Next ")));
            instructionContentTextBlock.Inlines.Add(new Run("button to move to the next question. For the\nwriting test, type your essay into the " +
                "text box below the writing prompt and select the "));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("Next ")));
            instructionContentTextBlock.Inlines.Add(new Run("button when finished.\n\nYour score on each multiple-choice test will be based only on " +
                "the number of question you answered correctly during the time\nallowed for that test. You will "));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("not ")));
            instructionContentTextBlock.Inlines.Add(new Run(" be penalized for guessing. "));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("It is to your advantage to answer every question. ")));
            instructionContentTextBlock.Inlines.Add(new Run("Your score on\nthe writing test is based on the essay you type into the text box.\n\n" +
                "Your computer will keep the official time for your examination. There will be a countdown timer that will tell you the time\n" +
                "remaining for the test you are working on. When 5 minutes remain on each test, a message will appear on your screen to serve as\n" +
                "a warning before time is up. When time runs out, submit your test according to the instructions on your screen.\n\n If you finish" +
                "a test easly, you may sit quietly or use the remaining time to reconsider questions you are uncertain about in that test\nor to review" +
                "yout essay. You will "));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("not ")));
            instructionContentTextBlock.Inlines.Add(new Run("be able to look back at the test questions or the essay once the test is submitted.\n\n" +
                "Please read and agree to the Examinee Statement on the next screen. The Examinee Statement section is not scored.\n\nSelect the "));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("Next ")));
            instructionContentTextBlock.Inlines.Add(new Run("button to proceed."));

            acceptButton.Click -= acceptButton_Click;
            declineButton.Click -= declineButton_Click;

            acceptDeclineStackPanel.Visibility = Visibility.Hidden;
        }

        private void LoadInstruction4()
        {
            instructionSectionNameLabel.Content = "Examinee Statement";

            instructionContentTextBlock.Inlines.Clear();

            instructionContentTextBlock.Inlines.Add(new Run("By accessing the online test, I agree to comply with and be bound by the "));
            instructionContentTextBlock.Inlines.Add(new Italic(new Run("Terms and Conditions: Testing Rules and Ploicies for the\n ACT Test ")));
            instructionContentTextBlock.Inlines.Add(new Run("provided in the ACT registration material for this test, including those conserning test security, " +
                "score cancellation,\nexaminee remedies, binding arbitration, and consent to the processing of my personally identifying information, " +
                "including the\ncollection, use, transfer, and disclosure of information as described in the ACT Privace Policy (www.act.org/privacy.html).\n\n" +
                "I understand that ACT owns the test questions and responces and affirm that I will not share any test questions or responces with\nanyone " +
                "by any form of communication before, during, or after the test administration. I understand that assuming anyone else's\n identity to take this test " +
                "is strictly prohibited and may violate the law and subject me to legal penalties.\n\n"));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("International Examinees: ")));
            instructionContentTextBlock.Inlines.Add(new Run("By accessing the online test, I an also providing my consent to ACT to transfer my personally\n" +
                "identifying information to the United States to ACT, or a third-party service provider, where it will be subject to use and disclosure\n" +
                "unser the laws of the United States. I acknowledge and agree that it may also be accessible to law enforcement and national\nsecurity authorities " +
                "im the United States.\n\nBy selecting "));
            instructionContentTextBlock.Inlines.Add(new Bold(new Run("Accept ")));
            instructionContentTextBlock.Inlines.Add(new Run("below and/or accessing the online test, I confirm my acceptance of the above terms."));

            acceptButton.Click += acceptButton_Click;
            declineButton.Click += declineButton_Click;

            acceptDeclineStackPanel.Visibility = Visibility.Visible;
        }

        private void SetWindowDefaultSettings()
        {
            this.WindowState = WindowState.Maximized;
        }

        private void AssignImageSources()
        {
            actLogoImage.Source = new BitmapImage(new Uri("pack://application:,,,/Img/act_logo.png"));
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentInstructionNumber == 1) prevButton.IsEnabled = true;

            _currentInstructionNumber++;
            LoadInstruction();

            if (_currentInstructionNumber == 4) nextButton.IsEnabled = false;
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentInstructionNumber == 4) nextButton.IsEnabled = true;

            _currentInstructionNumber--;
            LoadInstruction();

            if (_currentInstructionNumber == 1) prevButton.IsEnabled = false;
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("a");
        }

        private void declineButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("d");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetWindowDefaultSettings();
            LoadInstruction();
            AssignImageSources();
        }

     

    }
}
