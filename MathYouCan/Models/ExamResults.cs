using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathYouCan.Models
{
    public class ExamResults
    {
        public int MathCorrectNumber { get; set; } = 0;
        public int ScienceCorrectNumber { get; set; } = 0;
        public int ReadingCorrectNumber { get; set; } = 0;
        public int EnglishCorrectNumber { get; set; } = 0;



        public int MathTotalNumber { get; set; } = 0;
        public int ScienceTotalNumber { get; set; } = 0;
        public int ReadingTotalNumber { get; set; } = 0;
        public int EnglishTotalNumber { get; set; } = 0;



        public IList<int> MathIncorrectQuestionNumbers { get; set; } = new List<int>();
        public IList<int> ReadingIncorrectQuestionNumbers { get; set; } = new List<int>();
        public IList<int> ScienceIncorrectQuestionNumbers { get; set; } = new List<int>();
        public IList<int> EnglishIncorrectQuestionNumbers { get; set; } = new List<int>();



        public string EnglishGrade { get; set; } = "Grade not provided";
        public string MathGrade { get; set; } = "Grade not provided";
        public string ReadingGrade { get; set; } = "Grade not provided";
        public string ScienceGrade { get; set; } = "Grade not provided";


    }
}
