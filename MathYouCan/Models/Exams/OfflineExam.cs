using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathYouCan.Models.Exams
{
    public class OfflineExam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public long? StartTime { get; set; }
        public long? EndTime { get; set; }
        public IEnumerable<Section> Sections { get; set; }
    }
}
