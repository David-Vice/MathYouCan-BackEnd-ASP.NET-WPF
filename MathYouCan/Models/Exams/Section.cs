using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathYouCan.Models.Exams
{
    public class Section
    {
        public string Name { get; set; }
        public int? Duration { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}
