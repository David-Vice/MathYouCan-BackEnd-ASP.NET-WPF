using System;
using System.Collections.Generic;

namespace ActAPI.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateTime? ExamDate { get; set; }
        public int? EnglishScore { get; set; }
        public int? MathScore { get; set; }
        public int? ReadingScore { get; set; }
        public int? ScienceScore { get; set; }
        public int? TotalScore { get; set; }
    }
}
