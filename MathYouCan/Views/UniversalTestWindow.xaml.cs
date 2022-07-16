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
        ResultsWindow _resultsWindow;
        UniversalTestViewModel _universalTestViewModel;
        public bool ExamEnded { get; set; } = false;
        public UniversalTestWindow(Section section,ResultsWindow resultsWindow)
        {

            InitializeComponent();
            _universalTestViewModel = new UniversalTestViewModel(section);
            _resultsWindow = resultsWindow;
            CreateButtons();
            CreateNavButtons();
            LoadInfo(section);
           _universalTestViewModel.ChangeBtnToActive(infoButton);
            CreateAnswers(answersPerQuestion);
        }

        #region Methods to UPDATE WINDOW

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
           _universalTestViewModel.FillQuestionInfo(questionPassageParagraph, questionTextBlock);
           _universalTestViewModel.FillImage(imageContainer);
           _universalTestViewModel.FillAnswers(this,answersPerQuestion);
        }

        /// <summary>
        /// Sets question text to QuestionPassage(Stack Panel) according to current Question index(CurrentQuestionIndex) from view model
        /// </summary>
       

        //этот метод вызывается вначале 1 раз и еще каждый раз когда пользователь меняет вопрос кликая на кнопки changeQuestionButton_Click
        private void UpdateWindow()
        {
            if (_universalTestViewModel.PrevQuestionIndex >= 0 )
            {
                if(_universalTestViewModel.Questions[_universalTestViewModel.PrevQuestionIndex].IsAnswered)
                {
                   _universalTestViewModel.ChangeBtnToAnswered(buttons[_universalTestViewModel.PrevQuestionIndex]);
                }
                else
                {
                    _universalTestViewModel.ChangeBtnToPassive(buttons[_universalTestViewModel.PrevQuestionIndex]);
                }
                _universalTestViewModel.ChangeNavQuestToPassive(navPanels.Where(x => x.Name.ToString() == $"questionNavStackPanel{_universalTestViewModel.PrevQuestionIndex}").First());
            }
            UpdateWindowContent();

            _universalTestViewModel.ChangeNavQuestToActive(navPanels.Where(x => x.Name.ToString() == $"questionNavStackPanel{_universalTestViewModel.CurrentQuestionIndex}").First());
            _universalTestViewModel.ChangeBtnToActive(buttons[_universalTestViewModel.CurrentQuestionIndex]);

            SyncRadioAnswers();
            if (_universalTestViewModel.IsEliminatorEnabled) UnEliminateAll();
        }

        #endregion

        #region Methods to OPERATE BUTTONS (Click, Active Passive)

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
        }
        private void SyncRadioAnswers()
        {
            bool isAnswered = _universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].IsAnswered;
            
            for (int i = 0; i < answersPerQuestion; i++)
            {
                var answerRadio = (RadioButton)this.FindName($"RadioAns{i + 1}");
                if(isAnswered  && answerRadio.IsVisible)
                {
                    if (((List<QuestionAnswer>)_universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].Question.QuestionAnswers)[i].Id == _universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].ChosenAnswerId)
                    {
                        answerRadio.IsChecked = true;
                    }
                }
                else if (_universalTestViewModel.CurrentQuestionIndex == 0)
                {
                    var answerState = (Label)this.FindName($"stateQuestion{_universalTestViewModel.CurrentQuestionIndex}");
                    answerState.Content = "Answered";

                }
                else
                {
                    answerRadio.IsChecked = false;
                }
            }
        }

        private void Answer_Checked(object sender, RoutedEventArgs e)
        {
            var answerState = (Label)this.FindName($"stateQuestion{_universalTestViewModel.CurrentQuestionIndex}");
            answerState.Content = "Answered";
            _universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].IsAnswered = true;
            _universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].ChosenAnswerId = ((List<QuestionAnswer>)_universalTestViewModel.Questions[_universalTestViewModel.CurrentQuestionIndex].Question.QuestionAnswers)[(int)(sender as RadioButton).Content.ToString()[0] - 65].Id;   //(int)(sender as RadioButton).Content.ToString()[0] - 65;
        }
        private void Answer_Unchecked(object sender, RoutedEventArgs e)
        {
            // for future
        }

        #endregion

        #region Methods prevButton and nextButton

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            _universalTestViewModel.PrevQuestionIndex = _universalTestViewModel.CurrentQuestionIndex;
            _universalTestViewModel.CurrentQuestionIndex--;
            UpdateWindow();
        }
        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_universalTestViewModel.CurrentQuestionIndex==-1)
            {
                _universalTestViewModel.ChangeBtnToAnswered(infoButton);
                _universalTestViewModel.EnableButtons(buttons);
                infoButton.Click -= changeQuestionButton_Click;
                navButton.IsEnabled = true;
               // infoButton.IsEnabled = false;
                endSectionButton.IsEnabled = true;
                toolsButton.IsEnabled = true;
                if (_universalTestViewModel.TestIsTimed())
                {
                    _universalTestViewModel.SetTimer(timerTextBlock,this,timerProgressBar,_resultsWindow);
                }
            }
          //  else
          //  {
                _universalTestViewModel.PrevQuestionIndex = _universalTestViewModel.CurrentQuestionIndex ;
                _universalTestViewModel.CurrentQuestionIndex++;
         //   }
            UpdateWindow();
        }

        #endregion
        
        #region Methods which are called only at the beginning once
        private void LoadInfo(Section section) { 
             _universalTestViewModel.Converter.ConvertToParagraph(questionPassageParagraph, _universalTestViewModel.GetInfo(section.Name),17);
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
            navPanels = _universalTestViewModel.CreateNavButtons(borders, this);
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
                ColumnDefinition gridCol3 = new ColumnDefinition();
                gridCol3.Width = GridLength.Auto;
                gridAns.ColumnDefinitions.Add(gridCol1);
                gridAns.ColumnDefinitions.Add(gridCol2);
                gridAns.ColumnDefinitions.Add(gridCol3);
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
                radioAns.Checked += Answer_Checked;
                radioAns.Unchecked += Answer_Unchecked;
                radioAns.Content = $"{(char)(65 + i)}.";
                RegisterName($"RadioAns{i + 1}", radioAns);

                Button elimButton = new Button();
                elimButton.SetValue(Grid.ColumnProperty, 2);
                elimButton.Name = $"ElimButton{i + 1}";
                elimButton.VerticalContentAlignment = VerticalAlignment.Center;
                elimButton.Margin = new Thickness(5);
                elimButton.Height = 30;
                elimButton.Width = 30;
                elimButton.FontSize = 17;
                elimButton.FontWeight = FontWeights.DemiBold;
                elimButton.Background = new SolidColorBrush(Colors.DarkRed);
                elimButton.Visibility = Visibility.Collapsed;
                elimButton.Click += EliminatorButtonClick;
                var elimButtonStyle = new Style
                {
                    TargetType = typeof(Border),
                    Setters = { new Setter { Property = Border.CornerRadiusProperty, Value = new CornerRadius(5) } }
                };
                elimButton.Resources.Add(elimButtonStyle.TargetType, elimButtonStyle);
                RegisterName($"ElimButton{i + 1}", elimButton);

                Border gridEliminator = new Border();
                Panel.SetZIndex(gridEliminator, 1);
                gridEliminator.BorderBrush=new SolidColorBrush(Colors.Black);
                gridEliminator.BorderThickness = new Thickness(1,1,1,1);
                gridEliminator.CornerRadius = new CornerRadius(10);
                gridEliminator.Name = $"GridEliminator{i + 1}";
                gridEliminator.SetValue(Grid.ColumnProperty, 1);
                gridEliminator.Background = new SolidColorBrush(Colors.DarkGray);
                gridEliminator.Opacity = 0.96;
                gridEliminator.Margin = new Thickness(8);
                gridEliminator.Visibility = Visibility.Collapsed;
                gridEliminator.MouseDown += eliminatedAnswer_MouseDown;
                RegisterName($"GridEliminator{i + 1}", gridEliminator);

                FlowDocumentScrollViewer bodyScroll = new FlowDocumentScrollViewer();
                bodyScroll.Name = $"BodyScroll{i + 1}";
                bodyScroll.SetValue(Grid.ColumnProperty, 1);
                Panel.SetZIndex(bodyScroll, 0);
                bodyScroll.IsMouseCapturedChanged += questionPassageFlowDocument_IsMouseCapturedChanged;
                bodyScroll.HorizontalAlignment = HorizontalAlignment.Stretch;
                bodyScroll.VerticalAlignment = VerticalAlignment.Center;
                bodyScroll.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                bodyScroll.Margin = new Thickness(10);
                RegisterName($"BodyScroll{i + 1}", bodyScroll);

                FlowDocument bodyFlowDoc = new FlowDocument();
                bodyFlowDoc.MouseDown += notEliminatedAnswer_MouseDown;
                bodyFlowDoc.Name = $"BodyFlowDoc{i + 1}";
                RegisterName($"BodyFlowDoc{i + 1}", bodyFlowDoc);

                Paragraph bodyAns = new Paragraph();
                bodyAns.Name = $"BodyAns{i + 1}";
                bodyAns.FontSize = 17;
                bodyAns.MouseDown += notEliminatedAnswer_MouseDown;
                RegisterName($"BodyAns{i + 1}", bodyAns);
                //added image container to each answer
                BlockUIContainer imageContainer = new BlockUIContainer();
                
                imageContainer.Name = $"imageContainer{i + 1}";
                RegisterName($"imageContainer{i + 1}", imageContainer);

                gridAns.Children.Add(radioAns);
                bodyFlowDoc.Blocks.Add(bodyAns);
                bodyFlowDoc.Blocks.Add(imageContainer);
                bodyScroll.Document = bodyFlowDoc;
                gridAns.Children.Add(bodyScroll);
                gridAns.Children.Add(gridEliminator);
                gridAns.Children.Add(elimButton);
                AnswersGrid.Children.Add(gridAns);
            }
        }

        #endregion

        #region Methods for NAVIGATION PANEL
        private void navQuestion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (mainGrid.FindResource("navPanelClosing") as Storyboard).Begin();
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
                if((sp.Children[1] as Label).Content.ToString() == "Highlighter") ClearHighlight();
            }
            else l.Visibility = Visibility.Visible;


            //==============================================================================================

            // Enable and Disable Highlight
            if (sp.Name == "highlightOption")
            {
                _universalTestViewModel.IsHighlightEnabled = !_universalTestViewModel.IsHighlightEnabled;
                clearHighlightsButton.IsEnabled = !clearHighlightsButton.IsEnabled;
            }
            // Enable and Disable Eliminator
            else if (sp.Name == "eliminatorOption")
            {
                _universalTestViewModel.IsEliminatorEnabled = !_universalTestViewModel.IsEliminatorEnabled;
                if(_universalTestViewModel.IsEliminatorEnabled)
                {
                    ShowEliminatorButtons();
                    UnEliminateAll();
                }
                else
                {
                    HideEliminatorButtons();
                    UnEliminateAll();
                }
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
            ExamEnded = true;
            if (MessageBox.Show("Do you want to finish the exam?", "Exit", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _universalTestViewModel.SendResultAndExitWindow(this,_resultsWindow);
               
            }
        }

        #endregion

        #region Methods Highlighter

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
            }
        }

        private void clearHighlightsButton_Click(object sender, RoutedEventArgs e)
        {
            ClearHighlight();
            clearHighlightsButton.IsEnabled = !clearHighlightsButton.IsEnabled;
            highlightIdentifierLabel.Visibility = Visibility.Collapsed;
            _universalTestViewModel.IsHighlightEnabled = false;
        }

        #endregion

        #region Methods Eliminator
        private void eliminatedAnswer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Border).Visibility = Visibility.Collapsed;
        }
        private void notEliminatedAnswer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(_universalTestViewModel.IsEliminatorEnabled)
            {
                string num = String.Empty;
                if (sender.GetType().Name == "Paragraph")
                {
                    num = (sender as Paragraph).Name.ToString();
                }
                else if (sender.GetType().Name == "FlowDocument")
                {
                    num = (sender as FlowDocument).Name.ToString();
                }
                var eliminatedAnswer = (Border)this.FindName($"GridEliminator{num[num.Length - 1]}");
                eliminatedAnswer.Visibility = Visibility.Visible;
            }
        }
        void EliminatorButtonClick(object sender, RoutedEventArgs e)
        {
            if (_universalTestViewModel.IsEliminatorEnabled)
            {
                string num = (sender as Button).Name.ToString();
                var eliminatedAnswer = (Border)this.FindName($"GridEliminator{num[num.Length - 1]}");
                
                if(eliminatedAnswer.Visibility == Visibility.Visible)
                {
                    eliminatedAnswer.Visibility = Visibility.Collapsed;
                }
                else
                {
                    eliminatedAnswer.Visibility = Visibility.Visible;
                }
            }
        }
        private void EliminateAll()
        {
            for(int i=0;i<answersPerQuestion;i++)
            {
                var eliminatedAnswer = (Border)this.FindName($"GridEliminator{i+1}");
                eliminatedAnswer.Visibility = Visibility.Visible;
            }
        }
        private void UnEliminateAll()
        {
            for (int i = 0; i < answersPerQuestion; i++)
            {
                var eliminatedAnswer = (Border)this.FindName($"GridEliminator{i + 1}");
                eliminatedAnswer.Visibility = Visibility.Collapsed;
            }
        }
        private void ShowEliminatorButtons()
        {
            for (int i = 0; i < answersPerQuestion; i++)
            {
                var eliminatorButton = (Button)this.FindName($"ElimButton{i + 1}");
                eliminatorButton.Visibility = Visibility.Visible;
            }
        }
        private void HideEliminatorButtons()
        {
            for (int i = 0; i < answersPerQuestion; i++)
            {
                var eliminatorButton = (Button)this.FindName($"ElimButton{i + 1}");
                eliminatorButton.Visibility = Visibility.Collapsed;
            }
        }
        #endregion
    }
}

