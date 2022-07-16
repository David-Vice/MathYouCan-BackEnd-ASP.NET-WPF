using MathYouCan.Models.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathYouCan.Models
{
    public class QuestionView
    {
        public Question Question { get; set; }

        public int ChosenAnswerId { get; set; }  // Undefined until the end of the test

        public bool IsAnswered { get; set; } = false; // True when question was answered/False otherwise

        public bool IsFlagged { get; set; } = false; // Shows if the question was flagged


    }
}
