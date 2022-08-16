using ActAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ActAPI.Data
{
    public interface IDataContext
    {
        DbSet<OfflineExam> OfflineExams { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        DbSet<Section> Sections { get; set; }
        DbSet<Result> Results { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<Student> Students { get; set; }

    }
}
