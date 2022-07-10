namespace ActAPI.Models.Dto
{
    public class OfflineExamDetails
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public long? StartTime { get; set; }
        public long? EndTime { get; set; }
    }
}
