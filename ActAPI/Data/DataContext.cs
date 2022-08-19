using ActAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ActAPI.Data
{
    public partial class DataContext : DbContext, IDataContext
    {
        private readonly string? _connectionString;
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DataContext(IOptions<DbConnectionInfo> dbConnectionInfo)
        {
            _connectionString = dbConnectionInfo.Value.SqlContext;
        }
        public virtual DbSet<OfflineExam> OfflineExams { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(_connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OfflineExam>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK__Questions__Secti__4E88ABD4");
            });

            modelBuilder.Entity<QuestionAnswer>(entity =>
            {
                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__QuestionA__Quest__5165187F");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK__Results__Section__6FE99F9F");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.OfflineExam)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.OfflineExamId)
                    .HasConstraintName("FK__Sections__Offlin__4BAC3F29");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnglishScore)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ExamDate).HasColumnType("datetime");

                entity.Property(e => e.MathScore)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReadingScore)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ScienceScore)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
