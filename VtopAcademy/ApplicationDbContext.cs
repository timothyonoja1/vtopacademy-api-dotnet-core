using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VtopAcademy.accounts;
using VtopAcademy.exams;
using VtopAcademy.kclasses;
using VtopAcademy.schools;
using VtopAcademy.subjects;

namespace VtopAcademy
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        // Add Database tables here

        public DbSet<School> Schools { get; set; } = null!;
        public DbSet<Exam> Exams { get; set; } = null!;
        public DbSet<Kclass> Kclasses { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

