using System;
using System.Collections.Generic;

namespace MathYouCan.Models.Exams
{
    public partial class Result
    {
        public int Id { get; set; }
        public int? CorrectAnswers { get; set; }
        public int? Grade { get; set; }
        public int? SectionId { get; set; }

        public virtual Section Section { get; set; }
    }
}
