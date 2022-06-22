using System;
using System.Collections.Generic;

namespace ActAPI.Models
{
    public partial class QuestionAnswer
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string? Text { get; set; }
        public string? PhotoName { get; set; }
        public int? QuestionId { get; set; }

        public virtual Question? Question { get; set; }
    }
}
