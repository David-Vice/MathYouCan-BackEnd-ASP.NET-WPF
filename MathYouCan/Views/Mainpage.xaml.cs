using MathYouCan.Models;
using MathYouCan.Models.Exams;
using MathYouCan.Services.Concrete;
using MathYouCan.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Section = MathYouCan.Models.Exams.Section;
namespace MathYouCan.Views
{
    /// <summary>
    /// Interaction logic for Mainpage.xaml
    /// </summary>
    public partial class Mainpage : Window
    {
        private OfflineExam _exam;
        private UserCredentials _userCredentials;
        public Mainpage(OfflineExam exam,UserCredentials userCredentials)
        {
            InitializeComponent();
            _exam = exam;
            examName.Content = exam.Name;
            _userCredentials=userCredentials;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //time check and so on
            List<UniversalTestWindow> windows = new List<UniversalTestWindow>();
            Close();

            ResultsWindow resultsWindow = new ResultsWindow(_userCredentials);
            List<Section> sections = SortSections();
            StaticValues.SectionsCount = sections.Count;
            SetTotalQuestionsNumber(resultsWindow, sections);
            InitializeResultsWindow(sections,resultsWindow);
            SetIncorrectQuestions(resultsWindow);
            for (int i = 0; i < sections.Count; i++)
            {
                windows.Add(new UniversalTestWindow(sections.ElementAt(i), resultsWindow));
                if (i == 2&&sections.Count == 4)
                {
                    PauseWindow pauseWindow = new PauseWindow();
                    pauseWindow.ShowDialog();

                }
                windows[i].ShowDialog();

                if (windows[i].ExamEnded)
                {
                    break;
                }

            }

            resultsWindow.ShowDialog();


        }
        private void InitializeResultsWindow(List<Section> sections,ResultsWindow resultsWindow)
        {
            DataHandlerService dataHandlerService = new DataHandlerService();
            foreach (var _section in sections)
            {
                if (_section.Name == "English Section")
                {

                    resultsWindow.ExamResults.EnglishGrade = dataHandlerService.GetExamGrade(_section.Id, 0);
                }
                else if (_section.Name == "Math Section")
                {

                    resultsWindow.ExamResults.MathGrade = dataHandlerService.GetExamGrade(_section.Id, 0);
                }
                else if (_section.Name == "Reading Section")
                {

                    resultsWindow.ExamResults.ReadingGrade = dataHandlerService.GetExamGrade(_section.Id, 0);
                }
                else if (_section.Name == "Science Section")
                {
                    resultsWindow.ExamResults.ScienceGrade = dataHandlerService.GetExamGrade(_section.Id, 0);
                }
            }
           
        }
        //Change if he wants to create not full test
        private List<Section> SortSections()
        {
            return _exam.Sections.ToList().OrderBy(x => x.Name).ToList();
        }
        private void SetTotalQuestionsNumber(ResultsWindow resultsWindow, List<Section> sections)
        {
            for (int i = 0; i < sections.Count; i++)
            {

                if (sections[i].Name == "English Section")
                {
                    resultsWindow.ExamResults.EnglishTotalNumber = sections[i].Questions.Count();
                }
                else if (sections[i].Name == "Math Section")
                {
                    resultsWindow.ExamResults.MathTotalNumber = sections[i].Questions.Count();
                }
                else if (sections[i].Name == "Reading Section")
                {
                    resultsWindow.ExamResults.ReadingTotalNumber = sections[i].Questions.Count();
                }
                else if (sections[i].Name == "Science Section")
                {
                    resultsWindow.ExamResults.ScienceTotalNumber = sections[i].Questions.Count();
                }
            }
        }

        // Sets all questions to incorrect
        // IF USER STARTS SECTION INCORRECT QUESTIONS WILL BE REINITIALIZED
        // THIS METHOD MUST BE USED AFTER "SetTotalQuestionsNumber"
        private void SetIncorrectQuestions(ResultsWindow resultsWindow)
        {
            for (int i = 1; i <= resultsWindow.ExamResults.EnglishTotalNumber; i++)
                resultsWindow.ExamResults.EnglishIncorrectQuestionNumbers.Add(i);

            for (int i = 1; i <= resultsWindow.ExamResults.MathTotalNumber; i++)
                resultsWindow.ExamResults.MathIncorrectQuestionNumbers.Add(i);

            for (int i = 1; i <= resultsWindow.ExamResults.ReadingTotalNumber; i++)
                resultsWindow.ExamResults.ReadingIncorrectQuestionNumbers.Add(i);

            for (int i = 1; i <= resultsWindow.ExamResults.ScienceTotalNumber; i++)
                resultsWindow.ExamResults.ScienceIncorrectQuestionNumbers.Add(i);
        }

    }
}
