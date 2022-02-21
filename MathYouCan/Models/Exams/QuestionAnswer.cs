using MathYouCan.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathYouCan.Models.Exams
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public AnswerType Type { get; set; }
        public string Text { get; set; }
        public string PhotoName { get; set; }

    }
}
