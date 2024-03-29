﻿using MathYouCan.Models.Exams;
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
        public Mainpage(OfflineExam exam)
        {
            InitializeComponent();
            _exam = exam;
            examName.Content = exam.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //time check and so on
            List<UniversalTestWindow> windows = new List<UniversalTestWindow>();
            Close();

            ResultsWindow resultsWindow = new ResultsWindow();
            List<Section> sections = SortSections();
            SetTotalQuestionsNumber(resultsWindow, sections);
            for (int i = 0; i < sections.Count; i++)
            {
                windows.Add(new UniversalTestWindow(sections.ElementAt(i), resultsWindow));
                if (i == 2)
                {
                    PauseWindow pauseWindow = new PauseWindow();
                    pauseWindow.ShowDialog();

                }
                windows[i].ShowDialog();

                //windows[i].
                if (windows[i].ExamEnded)
                {
                    break;
                }

            }

            resultsWindow.ShowDialog();


        }
        //Change if he wants to create not full test
        private List<Section> SortSections()
        {

            List<Section> sectionsTmp = _exam.Sections.ToList();
            for (int i = 0; i < _exam.Sections.Count(); i++)
            {
                Section s = _exam.Sections.ElementAt(i);
                if (s.Name == "English Section")
                {
                    sectionsTmp[0] = s;
                }
                if (s.Name == "Math Section")
                {
                    sectionsTmp[1] = s;
                }
                if (s.Name == "Reading Section")
                {
                    sectionsTmp[2] = s;
                }
                if (s.Name == "Science Section")
                {
                    sectionsTmp[3] = s;
                }
            }
            return sectionsTmp;
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

    }
}
