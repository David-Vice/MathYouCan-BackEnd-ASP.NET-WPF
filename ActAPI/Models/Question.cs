using System;
using System.Collections.Generic;

namespace ActAPI.Models
{
    public partial class Question
    {
        public Question()
        {
            QuestionAnswers = new HashSet<QuestionAnswer>();
        }

        public int Id { get; set; }
        public int Type { get; set; }
        public string? QuestionContent { get; set; }
        public string? Text { get; set; }
        public string? PhotoName { get; set; }
        public int? SectionId { get; set; }

        public virtual Section? Section { get; set; }
        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
