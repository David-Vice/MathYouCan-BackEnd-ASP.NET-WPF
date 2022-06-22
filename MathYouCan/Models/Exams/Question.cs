using MathYouCan.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathYouCan.Models.Exams
{
    public class Question
    {
        public int Id { get; set; }
        public QuestionType Type { get; set; }
        public string QuestionContent { get; set; } = null;
        public string Text { get; set; } = null;
        public string PhotoName { get; set; } = null;
        public IEnumerable<QuestionAnswer> Answers { get; set; }
    
    }
}
