using Feedback.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback.Domain
{
    public class FeedbackContext : DbContext
    {

        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<FeedBack> Feedbacks { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Teacher>().HasData(
            new Teacher
            {
                Id = 1,
                FirstName = "Alin",
                LastName = "Bradut",
                Email = "ab@feedback.com"
            },
             new Teacher
             {
                 Id = 2,
                 FirstName = "Larisa",
                 LastName = "Costache",
                 Email = "lc@feedback.com"
             },
            new Teacher
            {
                Id = 3,
                FirstName = "George",
                LastName = "Trifan",
                Email = "gt@feedback.com"
            },
             new Teacher
             {
                 Id = 4,
                 FirstName = "Ovidiu",
                 LastName = "Netoiu",
                 Email = "on@feedback.com"
             }
        );

            modelBuilder.Entity<Course>().HasData(
        new Course
        {
            CourseId = 1,
            CourseName = "Java",
            TeacherId = 1
        },
         new Course
         {
             CourseId = 2,
             CourseName = "Python",
             TeacherId = 2
         }, new Course
         {
             CourseId = 3,
             CourseName = "Javascrip",
             TeacherId = 3
         }, new Course
         {
             CourseId = 4,
             CourseName = "PHP",
             TeacherId = 4
         }
         );


            modelBuilder.Entity<FeedBack>().HasData(
            new FeedBack
            {
                FeedbackId = 1,
                CourseId = 1,
                FeedbackWriterName = "Bogdan Tudorica",
                TheFeedback = "Totul a fost bine",
                FeedbackWriterEmail = "a@a.com",
            },
             new FeedBack
             {
                 FeedbackId = 2,
                 CourseId = 1,
                 FeedbackWriterName = "Jan Constatin",
                 TheFeedback = "Nu totul a fost bine",
                 FeedbackWriterEmail = "b@b.com",
             },
             new FeedBack
             {
                 FeedbackId = 3,
                 CourseId = 2,
                 FeedbackWriterName = "Lili Horinca",
                 TheFeedback = "Totul a fost bine",
                 FeedbackWriterEmail = "c@c.com",
             },
             new FeedBack
             {
                 FeedbackId = 4,
                 CourseId = 2,
                 FeedbackWriterName = "Bogdan Sava",
                 TheFeedback = "Nu totul a fost bine",
                 FeedbackWriterEmail = "d@d.com",
             },
             new FeedBack
             {
                 FeedbackId = 5,
                 CourseId = 3,
                 FeedbackWriterName = "Ioana Constatin",
                 TheFeedback = "Nu totul a fost bine",
                 FeedbackWriterEmail = "c@c.com",
             }
               );
        }


    }
}
