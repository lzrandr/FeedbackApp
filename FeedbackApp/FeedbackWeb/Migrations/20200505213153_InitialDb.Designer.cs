﻿// <auto-generated />
using Feedback.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FeedbackWeb.Migrations
{
    [DbContext(typeof(FeedbackContext))]
    [Migration("20200505213153_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Feedback.Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseName = "Java",
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 2,
                            CourseName = "Python",
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 3,
                            CourseName = "Javascrip",
                            TeacherId = 3
                        },
                        new
                        {
                            Id = 4,
                            CourseName = "PHP",
                            TeacherId = 4
                        });
                });

            modelBuilder.Entity("Feedback.Domain.Entities.FeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("FeedbackWriterEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedbackWriterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Feedbacks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Feedback = "Totul a fost bine",
                            FeedbackWriterEmail = "a@a.com",
                            FeedbackWriterName = "Bogdan Tudorica"
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            Feedback = "Nu totul a fost bine",
                            FeedbackWriterEmail = "b@b.com",
                            FeedbackWriterName = "Jan Constatin"
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 2,
                            Feedback = "Totul a fost bine",
                            FeedbackWriterEmail = "c@c.com",
                            FeedbackWriterName = "Lili Horinca"
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 2,
                            Feedback = "Nu totul a fost bine",
                            FeedbackWriterEmail = "d@d.com",
                            FeedbackWriterName = "Bogdan Sava"
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 3,
                            Feedback = "Nu totul a fost bine",
                            FeedbackWriterEmail = "c@c.com",
                            FeedbackWriterName = "Ioana Constatin"
                        });
                });

            modelBuilder.Entity("Feedback.Domain.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ab@feedback.com",
                            FirstName = "Alin",
                            LastName = "Bradut"
                        },
                        new
                        {
                            Id = 2,
                            Email = "lc@feedback.com",
                            FirstName = "Larisa",
                            LastName = "Costache"
                        },
                        new
                        {
                            Id = 3,
                            Email = "gt@feedback.com",
                            FirstName = "George",
                            LastName = "Trifan"
                        },
                        new
                        {
                            Id = 4,
                            Email = "on@feedback.com",
                            FirstName = "Ovidiu",
                            LastName = "Netoiu"
                        });
                });

            modelBuilder.Entity("Feedback.Domain.Entities.Course", b =>
                {
                    b.HasOne("Feedback.Domain.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Feedback.Domain.Entities.FeedBack", b =>
                {
                    b.HasOne("Feedback.Domain.Entities.Course", "Course")
                        .WithMany("FeedBacks")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
