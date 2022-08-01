using System;
using System.Collections.Generic;

namespace ActAPI.Models
{
    public partial class OfflineExam
    {
        public OfflineExam()
        {
            Sections = new HashSet<Section>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public long? StartTime { get; set; }
        public long? EndTime { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }
}
