using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ActAPI.Models
{
    public partial class db_a8aa44_actdbContext : DbContext
    {
        public db_a8aa44_actdbContext()
        {
        }

        public db_a8aa44_actdbContext(DbContextOptions<db_a8aa44_actdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OfflineExam> OfflineExams { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SQL8004.site4now.net;Initial Catalog=db_a8aa44_actdb;User Id=db_a8aa44_actdb_admin;Password=actdb2022");
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
