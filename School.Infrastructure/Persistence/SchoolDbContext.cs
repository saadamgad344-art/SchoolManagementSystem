using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Persistence
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<School.Domain.Entities.School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<School.Domain.Entities.User> Users { get; set; }
        public DbSet<Grade> Grades => Set<Grade>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure School → Students relationship (One-to-Many)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.School)           // Navigation property in Student
                .WithMany(sch => sch.Students)   // Navigation property in School
                .HasForeignKey(s => s.SchoolId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure School → Teachers relationship (One-to-Many)
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.School)           // Navigation property in Teacher
                .WithMany(sch => sch.Teachers)   // Navigation property in School
                .HasForeignKey(t => t.SchoolId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<School.Domain.Entities.User>()
               .HasOne(u => u.UserSchool)
               .WithMany()
               .HasForeignKey(u => u.SchoolId)
               .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Grade>()
              .HasOne(g => g.Student)
              .WithMany(s => s.Grades)
              .HasForeignKey(g => g.StudentId)
              .OnDelete(DeleteBehavior.Cascade);

        }

        
    }
}
