﻿// <auto-generated />
using System;
using Feedback.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FeedbackWeb.Migrations
{
    [DbContext(typeof(FeedbackContext))]
    [Migration("20200508194614_RemovedDate")]
    partial class RemovedDate
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
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CourseName = "Java",
                            TeacherId = 1
                        },
                        new
                        {
                            CourseId = 2,
                            CourseName = "Python",
                            TeacherId = 2
                        },
                        new
                        {
                            CourseId = 3,
                            CourseName = "Javascrip",
                            TeacherId = 3
                        },
                        new
                        {
                            CourseId = 4,
                            CourseName = "PHP",
                            TeacherId = 4
                        });
                });

            modelBuilder.Entity("Feedback.Domain.Entities.FeedBack", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("FeedbackWriterEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedbackWriterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TheFeedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.HasKey("FeedbackId");

                    b.HasIndex("CourseId");

                    b.ToTable("Feedbacks");

                    b.HasData(
                        new
                        {
                            FeedbackId = 1,
                            CourseId = 1,
                            FeedbackWriterEmail = "a@a.com",
                            FeedbackWriterName = "Bogdan Tudorica",
                            TheFeedback = "Totul a fost bine"
                        },
                        new
                        {
                            FeedbackId = 2,
                            CourseId = 1,
                            FeedbackWriterEmail = "b@b.com",
                            FeedbackWriterName = "Jan Constatin",
                            TheFeedback = "Nu totul a fost bine"
                        },
                        new
                        {
                            FeedbackId = 3,
                            CourseId = 2,
                            FeedbackWriterEmail = "c@c.com",
                            FeedbackWriterName = "Lili Horinca",
                            TheFeedback = "Totul a fost bine"
                        },
                        new
                        {
                            FeedbackId = 4,
                            CourseId = 2,
                            FeedbackWriterEmail = "d@d.com",
                            FeedbackWriterName = "Bogdan Sava",
                            TheFeedback = "Nu totul a fost bine"
                        },
                        new
                        {
                            FeedbackId = 5,
                            CourseId = 3,
                            FeedbackWriterEmail = "c@c.com",
                            FeedbackWriterName = "Ioana Constatin",
                            TheFeedback = "Nu totul a fost bine"
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
