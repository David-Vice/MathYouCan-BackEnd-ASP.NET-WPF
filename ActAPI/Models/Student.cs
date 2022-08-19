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
        public string? EnglishScore { get; set; }
        public string? MathScore { get; set; }
        public string? ReadingScore { get; set; }
        public string? ScienceScore { get; set; }
        public double? TotalScore { get; set; }
    }
}
