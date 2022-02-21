using MathYouCan.Converters;
using MathYouCan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Threading;
using MathYouCan.Models.Exams;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Documents;
using Section = MathYouCan.Models.Exams.Section;

namespace MathYouCan.Views
{
    public partial class UniversalTestWindow : Window
    {
        //возьмем из коллекшина тот который совпадает с кнопкой на которую нажали по номеру вопроса, 
        // (по дэфолту он 1 ) выбираем вопрос из этого коллекшина API и фулл показывем с помощью UpdateWindow(int questionNumber)
        //а сам коллекшн и его длинную используем для создание динамч. платформы вопросов внизу
        //сам коллекшн передадим через конструкктор
        //пока пусть это будет коллекшн 'нецензурное слово' текста но потом поменяем на коллекш класса в котором уже
        //и текст и картинки и варианты ответов
        //IEnumerable<Question> questions
        List<Button> buttons = new List<Button>();
        List<StackPanel> navPanels = new List<StackPanel>();
        int answersPerQuestion = 5;

        UniversalTestViewModel _universalTestViewModel;
        public UniversalTestWindow(Section section)
        {

            InitializeComponent();
            _universalTestViewModel = new UniversalTestViewModel(section);
            CreateButtons();
            CreateNavButtons();
            LoadInfo(section);
            ChangeBtnToActive(infoButton);
            CreateAnswers(answersPerQuestion);
        }

        #region Methods To UPDATE WINDOW

        /// <summary>
        ///     -- Enables/Disables (nextButton), (prevButton)  depending on current question number (_universalTestViewModel.CurrentQuestionIndex)
        ///     -- Fills instruction content
        ///     -- Sets title for question
        /// </summary>
        /// 
        private void UpdateWindowContent()
        {
            /* Enabling/Disabling next and prev buttons */

            // First question loaded
            if (_universalTestViewModel.CurrentQuestionIndex == 0)
            {
                prevButton.IsEnabled = false;
                nextButton.IsEnabled = true;
            }
            // Last question loaded
            else if (_universalTestViewModel.CurrentQuestionIndex == _universalTestViewModel.Questions.Count - 1)
            {
                prevButton.IsEnabled = true;
                nextButton.IsEnabled = false;
            }
            else
            {
                prevButton.IsEnabled = true;
                nextButton.IsEnabled = true;
            }
            //questionTitleLabel.Content = _universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].Question.;

            FillQuestion();
        }

        private void FillQuestion()
        {
            FillQuestionPassage();
            FillAnswers();
        }

        /// <summary>
        /// Sets question text to QuestionPassage(Stack Panel) according to current Question index(CurrentQuestionIndex) from view model
        /// </summary>
        private void FillQuestionPassage()
        {
            _universalTestViewModel.Converter.ConvertToParagraph(questionPassageParagraph,
                _universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].Question.Text, 16);
        //    TextToFlowDocumentConverter textTo = new TextToFlowDocumentConverter(Brushes.Yellow, Brushes.GreenYellow);
        //    textTo.ConvertToParagraph(questionPassageParagraph, _universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].Text, 16);
        //    textTo.ConvertToParagraph(questionPassageParagraph, _universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].QuestionContent, 16);
        //    textTo.ConvertToParagraph(questionPassageParagraph, _universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].QuestionContent, 16);
        }

        private void FillAnswers()
        {
            List<QuestionAnswer> answers = (List<QuestionAnswer>)_universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].Question.Answers;

            for (int i=0;i<answers.Count;i++)
            {
                var answerGrid = (Grid)this.FindName($"GridAns{i + 1}");
                answerGrid.Visibility = Visibility.Visible;
                var answer = (Paragraph)this.FindName($"BodyAns{i + 1}");
                _universalTestViewModel.Converter.ConvertToParagraph(answer, (_universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].Question.Answers as List<QuestionAnswer>)[i].Text, 16);
            }
            for (int i = answers.Count; i < answersPerQuestion; i++)
            {
                var answerGrid = (Grid)this.FindName($"GridAns{i + 1}");
                answerGrid.Visibility = Visibility.Collapsed;
            }
        }

        //этот метод вызывается вначале 1 раз и еще каждый раз когда пользователь меняет вопрос кликая на кнопки changeQuestionButton_Click
        private void UpdateWindow()
        {
            if (_universalTestViewModel.PrevQuestionIndex >= 0 )
            {
                ChangeBtnToPassive(buttons[_universalTestViewModel.PrevQuestionIndex]);
                ChangeNavQuestToPassive(navPanels.Where(x => x.Name.ToString() == $"questionNavStackPanel{_universalTestViewModel.PrevQuestionIndex}").First());
            }
            UpdateWindowContent();

            ChangeNavQuestToActive(navPanels.Where(x => x.Name.ToString() == $"questionNavStackPanel{_universalTestViewModel.CurrentQuestionIndex}").First());
            ChangeBtnToActive(buttons[_universalTestViewModel.CurrentQuestionIndex]);

        }

        #endregion

        #region Methods To OPERATE BUTTONS (Click, Active Passive)

        private void changeQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            _universalTestViewModel.PrevQuestionIndex = _universalTestViewModel.CurrentQuestionIndex;

            int num;
            if (int.TryParse((sender as Button).Content.ToString(), out num))
            {
                _universalTestViewModel.CurrentQuestionIndex = num;
            }
            else
            {
                _universalTestViewModel.CurrentQuestionIndex = 0;
            }
            UpdateWindow();
            //Save chosen answer
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
        private void ChangeNavQuestToActive(StackPanel stack)
        {
            stack.Background = new SolidColorBrush(Colors.SkyBlue);
        }
        private void ChangeNavQuestToPassive(StackPanel stack)
        {
            stack.Background = new SolidColorBrush(Colors.LightGray);
        }

        #endregion

        #region prevButton and nextButton Clicks

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            _universalTestViewModel.PrevQuestionIndex = _universalTestViewModel.CurrentQuestionIndex;
            _universalTestViewModel.CurrentQuestionIndex--;
            UpdateWindow();
        }
        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (infoButton.IsEnabled)
            {
                ChangeBtnToPassive(infoButton);
                _universalTestViewModel.EnableButtons(buttons);
                navButton.IsEnabled = true;
                infoButton.IsEnabled = false;
                endSectionButton.IsEnabled = true;
                toolsButton.IsEnabled = true;
                if (_universalTestViewModel.TestIsTimed())
                {
                    _universalTestViewModel.SetTimer(timerTextBlock,this,timerProgressBar);
                }
            }
            else
            {
                _universalTestViewModel.PrevQuestionIndex = _universalTestViewModel.CurrentQuestionIndex ;
                _universalTestViewModel.CurrentQuestionIndex++;
            }
            UpdateWindow();
        }

        #endregion
        
        #region Methods which are called only at the beginning once
        private void LoadInfo(Section section) { 
            TextToFlowDocumentConverter converter = new TextToFlowDocumentConverter(Brushes.Yellow, Brushes.GreenYellow);
            converter.ConvertToParagraph(questionPassageParagraph, _universalTestViewModel.GetInfo(section.Name),17);
        }
        
        private void CreateButtons()
        {
            buttons = _universalTestViewModel.CreateButtons();
            foreach (var button in buttons)
            {
                button.Click += changeQuestionButton_Click;
                questionsStackPanel.Children.Add(button);
            }
        }
        private void CreateNavButtons()
        {
            List<Border> borders = new List<Border>();
            navPanels = _universalTestViewModel.CreateNavButtons(borders);
            for (int i = 0; i < navPanels.Count; i++)
            {
                navPanels[i].MouseDown += navQuestion_MouseDown;
                navPanels[i].MouseEnter += navQuestion_MouseEnter;
                navPanels[i].MouseLeave += navQuestion_MouseLeave;
                navBody.Children.Add(borders[i]);
            }
        }
        private void CreateAnswers(int answersNum)
        {
            /*
            <FlowDocumentScrollViewer  Name="questionPassageFlowDocument" Grid.Row="1"
                                       IsMouseCapturedChanged="questionPassageFlowDocument_IsMouseCapturedChanged"
                                       LostMouseCapture="questionPassageFlowDocument_LostMouseCapture">
                <FlowDocument>
                    <Paragraph Name="questionPassageParagraph">

                    </Paragraph>
                </FlowDocument>
            </FlowDocumentScrollViewer>
            */
            for (int i = 0; i < answersNum; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;
                AnswersGrid.RowDefinitions.Add(row);
                Grid gridAns = new Grid();
                gridAns.Name = $"GridAns{i + 1}";
                gridAns.SetValue(Grid.RowProperty, i);
                ColumnDefinition gridCol1 = new ColumnDefinition();
                gridCol1.Width = GridLength.Auto;
                ColumnDefinition gridCol2 = new ColumnDefinition();
                gridCol2.Width = new GridLength(1, GridUnitType.Star);
                gridAns.ColumnDefinitions.Add(gridCol1);
                gridAns.ColumnDefinitions.Add(gridCol2);
                gridAns.Visibility = Visibility.Collapsed;
                RegisterName($"GridAns{i + 1}", gridAns);

                RadioButton radioAns = new RadioButton();
                radioAns.SetValue(Grid.ColumnProperty, 0);
                radioAns.Name = $"RadioAns{i + 1}";
                radioAns.GroupName = "RadioAnswers";
                radioAns.VerticalContentAlignment = VerticalAlignment.Center;
                radioAns.Margin = new Thickness(0, 10, 0, 10);
                radioAns.FontSize = 17;
                radioAns.FontWeight = FontWeights.DemiBold;
                radioAns.Background = new SolidColorBrush(Colors.White);
                radioAns.Content = $"{(char)(65 + i)}.";

                FlowDocumentScrollViewer bodyScroll = new FlowDocumentScrollViewer();
                bodyScroll.Name = $"BodyScroll{i + 1}";
                bodyScroll.SetValue(Grid.ColumnProperty, 1);
                bodyScroll.IsMouseCapturedChanged += questionPassageFlowDocument_IsMouseCapturedChanged;
                bodyScroll.LostMouseCapture += questionPassageFlowDocument_LostMouseCapture;
                bodyScroll.HorizontalAlignment = HorizontalAlignment.Stretch;
                bodyScroll.VerticalAlignment = VerticalAlignment.Center;
                bodyScroll.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                bodyScroll.Margin = new Thickness(10);
                RegisterName($"BodyScroll{i + 1}", bodyScroll);

                FlowDocument bodyFlowDoc = new FlowDocument();
                bodyFlowDoc.Name = $"BodyFlowDoc{i + 1}";
                RegisterName($"BodyFlowDoc{i + 1}", bodyFlowDoc);

                Paragraph bodyAns = new Paragraph();
                bodyAns.Name = $"BodyAns{i + 1}";
                bodyAns.FontSize = 17;
                RegisterName($"BodyAns{i + 1}", bodyAns);

                gridAns.Children.Add(radioAns);
                bodyFlowDoc.Blocks.Add(bodyAns);
                bodyScroll.Document = bodyFlowDoc;
                gridAns.Children.Add(bodyScroll);
                AnswersGrid.Children.Add(gridAns);
            }
        }

        #endregion

        #region Methods for NAVIGATION PANEL
        private void navQuestion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _universalTestViewModel.PrevQuestionIndex = _universalTestViewModel.CurrentQuestionIndex;
            int num;
            if (int.TryParse((((sender as StackPanel).Children[0] as StackPanel).Children[0] as Label).Content.ToString(), out num))
            {
                _universalTestViewModel.CurrentQuestionIndex = num;
            }
            else
            {
                _universalTestViewModel.CurrentQuestionIndex = 0;
            }

            NavPanel.Visibility = Visibility.Collapsed; //no animation
            UpdateWindow();
        }

        private void navButton_Click(object sender, RoutedEventArgs e)
        {
            NavPanel.Visibility = Visibility.Visible;
        }
        private void navPanelClosing_Completed(object sender, EventArgs e)
        {
            NavPanel.Visibility = Visibility.Collapsed;
        }
        private void navQuestion_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as StackPanel).Background = new SolidColorBrush(Colors.AliceBlue);
        }
        private void navQuestion_MouseLeave(object sender, MouseEventArgs e)
        {
            if ((sender as StackPanel).Name == $"questionNavStackPanel{_universalTestViewModel.CurrentQuestionIndex}")
                (sender as StackPanel).Background = new SolidColorBrush(Colors.SkyBlue);
            else
                (sender as StackPanel).Background = new SolidColorBrush(Colors.LightGray);
        }

        #endregion

        #region Methods for TOOLS PANEL AND ENDSECTION

        private void toolsButton_Click(object sender, RoutedEventArgs e)
        {
            toolsPopUpPanel.IsOpen = !toolsPopUpPanel.IsOpen;
        }

        private void popUpOptionStackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            Label l = (sp.Children[0] as Label);
            if (l.Visibility == Visibility.Visible)
            {
                l.Visibility = Visibility.Collapsed;
                ClearHighlight();
            }
            else l.Visibility = Visibility.Visible;


            //==============================================================================================

            // Enable and diable highlight
            if (sp.Name == "highlightOption")
            {
                _universalTestViewModel.IsHighlightEnabled = !_universalTestViewModel.IsHighlightEnabled;
                clearHighlightsButton.IsEnabled = !clearHighlightsButton.IsEnabled;
            }
            //==============================================================================================


            toolsPopUpPanel.IsOpen = !toolsPopUpPanel.IsOpen;
        }

        private void popUpOptionStackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            sp.Background = new SolidColorBrush(Color.FromRgb(218, 37, 29));

            for (int i = 0; i < sp.Children.Count; i++)
            {
                (sp.Children[i] as Label).Foreground = Brushes.White;
            }
        }
        private void popUpOptionStackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            sp.Background = Brushes.Transparent;

            for (int i = 0; i < sp.Children.Count; i++)
            {
                (sp.Children[i] as Label).Foreground = Brushes.Black;
            }
        }
        private void endSectionButton_Click(object sender, RoutedEventArgs e)
        {
            _universalTestViewModel.SendResultAndExitWindow(this);
        }
        #endregion

        //==============================================================================================

        //Reload the page
        private void ClearHighlight()
        {
            UpdateWindowContent();
        }

        private void questionPassageFlowDocument_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (_universalTestViewModel.IsHighlightEnabled)
            {
                // Highlight the text

                System.Windows.Documents.TextPointer potStart = (sender as FlowDocumentScrollViewer).Selection.Start;
                System.Windows.Documents.TextPointer potEnd = (sender as FlowDocumentScrollViewer).Selection.End;
                System.Windows.Documents.TextRange range = new System.Windows.Documents.TextRange(potStart, potEnd);
                range.ApplyPropertyValue(System.Windows.Documents.TextElement.BackgroundProperty, _universalTestViewModel.HighLighteTextBrush);

                //ThreadPool.QueueUserWorkItem((o) => { MessageBox.Show((_universalTestViewModel.DefaultFontSize + 1).ToString()); });
                //range.ApplyPropertyValue(TextElement.FontSizeProperty, _universalTestViewModel.DefaultFontSize + 1);
                //range.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);

            }
        }

        private void clearHighlightsButton_Click(object sender, RoutedEventArgs e)
        {
            ClearHighlight();
        }

        private void questionPassageFlowDocument_LostMouseCapture(object sender, MouseEventArgs e)
        {
            //if (_universalTestViewModel.IsHighlightEnabled && _universalTestViewModel.Converter.SelectedWords.Count != 0)
            //{
            //    foreach (string item in _universalTestViewModel.Converter.SelectedWords)
            //    {
            //        String search = item;

            //        TextPointer text = questionPassageParagraph.ContentStart;
            //        while (true)
            //        {
            //            TextPointer next = text.GetNextContextPosition(LogicalDirection.Forward);
            //            if (next == null)
            //            {
            //                break;
            //            }
            //            TextRange txt = new TextRange(text, next);

            //            int indx = txt.Text.IndexOf(search);
            //            if (indx > 0)
            //            {
            //                TextPointer sta = text.GetPositionAtOffset(indx);
            //                TextPointer end = text.GetPositionAtOffset(indx + search.Length);
            //                TextRange textR = new TextRange(sta, end);
            //                textR.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Yellow));
            //            }
            //            text = next;
            //        }

            //    }
            //}

        }

        //==============================================================================================


    }
}

