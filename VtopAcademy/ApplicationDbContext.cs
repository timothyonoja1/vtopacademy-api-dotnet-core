using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VtopAcademy.Accounts;
using VtopAcademy.Exams;
using VtopAcademy.Kclasses;
using VtopAcademy.KclassSubjects;
using VtopAcademy.SchoolKclasses;
using VtopAcademy.Schools;
using VtopAcademy.Subjects;
using VtopAcademy.SubTopics;
using VtopAcademy.Topics;
using VtopAcademy.Videos;

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
        public DbSet<Topic> Topics { get; set; } = null!;
        public DbSet<SubTopic> SubTopics { get; set; } = null!;
        public DbSet<Video> Videos { get; set; } = null!;

        public DbSet<SchoolKclass> SchoolKclasses { get; set; } = null!;
        public DbSet<KclassSubject> KclassSubjects { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

