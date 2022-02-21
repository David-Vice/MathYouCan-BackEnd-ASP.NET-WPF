using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathYouCan.Models
{
    public class Question
    {
        public string QuestionTitle { get; set; }

        public string QuestionPassage { get; set; }

        public string QuestionContent { get; set; }


        public List<Answer> Answers { get; set; }

        public int CorrectAnswerIndex { get; set; }  // Undefined until the end of the test

        public bool IsAnswered { get; set; } = false; // True when question was answered/False otherwise

        public bool IsFlagged { get; set; } = false; // Shows if the question was flagged

        public Question()
        {
            Answers = new List<Answer>(); 
        }


    }
}
