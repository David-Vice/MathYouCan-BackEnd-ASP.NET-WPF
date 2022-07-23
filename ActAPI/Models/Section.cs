using System;
using System.Collections.Generic;

namespace ActAPI.Models
{
    public partial class Section
    {
        public Section()
        {
            Questions = new HashSet<Question>();
            Results = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Duration { get; set; }
        public int? OfflineExamId { get; set; }

        public virtual OfflineExam? OfflineExam { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
