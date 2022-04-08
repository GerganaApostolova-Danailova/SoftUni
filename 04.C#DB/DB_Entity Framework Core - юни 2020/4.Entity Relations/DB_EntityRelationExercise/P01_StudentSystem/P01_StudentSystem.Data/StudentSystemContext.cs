using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Resource> Resources { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                .IsRequired(false)
                .IsUnicode(false)
                .HasColumnType("CHAR(10)");

                entity.Property(e => e.RegisteredOn)
                .IsRequired(true);

                entity.Property(e => e.Birthday)
                .IsRequired(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(80);

                entity.Property(e => e.Description)
                .IsRequired(false)
                .IsUnicode();

                entity.Property(e => e.StartDate)
                    .IsRequired();

                entity.Property(e => e.EndDate)
                    .IsRequired();

                entity.Property(e => e.Price)
                    .IsRequired();
            });

            modelBuilder.Entity<Resource>(entity =>
           {
               entity.HasKey(e => e.ResourceId);

               entity.Property(e => e.Name)
               .IsRequired()
               .IsUnicode()
               .HasMaxLength(50);

               entity.Property(e => e.Url)
              .IsRequired()
              .IsUnicode(false);

               entity.Property(e => e.ResourceType)
              .IsRequired();

               entity.Property(e => e.ResourceType)
              .IsRequired();

               entity.HasOne(r => r.Course)
               .WithMany(c => c.Resources)
               .HasForeignKey(r => r.CourseId)
               .OnDelete(DeleteBehavior.Restrict);
           });

            modelBuilder.Entity<Homework>(entity =>
           {
               entity.HasKey(e => e.HomeworkId);

               entity.Property(e => e.Content)
               .IsRequired()
               .IsUnicode(false);

               entity.Property(e => e.ContentType)
               .IsRequired();

               entity.Property(e => e.SubmissionTime)
               .IsRequired();

               entity.HasOne(h => h.Student)
               .WithMany(s => s.HomeworkSubmissions)
               .HasForeignKey(h => h.StudentId)
               .OnDelete(DeleteBehavior.Restrict);

               entity.HasOne(h => h.Course)
               .WithMany(c => c.HomeworkSubmissions)
               .HasForeignKey(h => h.CourseId)
               .OnDelete(DeleteBehavior.Restrict);
           });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });

                entity.HasOne(e => e.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Course)
                .WithMany(s => s.StudentsEnrolled)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
