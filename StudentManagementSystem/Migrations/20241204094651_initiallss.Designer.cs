﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagementSystem;

#nullable disable

namespace StudentManagementSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241204094651_initiallss")]
    partial class initiallss
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentManagementSystem.Entities.Attendance", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ClassID");

                    b.HasIndex("StudentID");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Class", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Feedback", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedbackType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Notification", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.OTP", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("OTPs");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Role", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = new Guid("b1a783a8-cafe-4195-a131-d51655fb2157"),
                            RoleName = "administrator"
                        },
                        new
                        {
                            ID = new Guid("f56eafdb-8a81-43b3-a530-fa40abc532dd"),
                            RoleName = "staff"
                        },
                        new
                        {
                            ID = new Guid("f438115a-0345-4cbb-a756-dbf6da347e15"),
                            RoleName = "teacher"
                        },
                        new
                        {
                            ID = new Guid("7c19b075-df7f-4dfb-a507-f260e77f9fe3"),
                            RoleName = "student"
                        });
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Student", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IntexNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("gender")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClassID");

                    b.HasIndex("UserID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Subject", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Teacher", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("SubjectID");

                    b.HasIndex("UserID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Timetable", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SubjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeacherID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ClassID");

                    b.HasIndex("SubjectID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Timetables");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.UserRole", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Attendance", b =>
                {
                    b.HasOne("StudentManagementSystem.Entities.Class", null)
                        .WithMany("Attendances")
                        .HasForeignKey("ClassID");

                    b.HasOne("StudentManagementSystem.Entities.Student", "Student")
                        .WithMany("Attendances")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Feedback", b =>
                {
                    b.HasOne("StudentManagementSystem.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Notification", b =>
                {
                    b.HasOne("StudentManagementSystem.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.OTP", b =>
                {
                    b.HasOne("StudentManagementSystem.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Staff", b =>
                {
                    b.HasOne("StudentManagementSystem.Entities.User", "User")
                        .WithMany("Staffs")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Student", b =>
                {
                    b.HasOne("StudentManagementSystem.Entities.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementSystem.Entities.User", "User")
                        .WithMany("Students")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Teacher", b =>
                {
                    b.HasOne("StudentManagementSystem.Entities.Subject", "Subject")
                        .WithMany("Teachers")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementSystem.Entities.User", "User")
                        .WithMany("Teachers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Timetable", b =>
                {
                    b.HasOne("StudentManagementSystem.Entities.Class", "Class")
                        .WithMany("Timetables")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementSystem.Entities.Subject", null)
                        .WithMany("Timetables")
                        .HasForeignKey("SubjectID");

                    b.HasOne("StudentManagementSystem.Entities.Teacher", "Teacher")
                        .WithMany("Timetables")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.UserRole", b =>
                {
                    b.HasOne("StudentManagementSystem.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementSystem.Entities.User", "User")
                        .WithOne("UserRole")
                        .HasForeignKey("StudentManagementSystem.Entities.UserRole", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Class", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Students");

                    b.Navigation("Timetables");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Student", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Subject", b =>
                {
                    b.Navigation("Teachers");

                    b.Navigation("Timetables");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.Teacher", b =>
                {
                    b.Navigation("Timetables");
                });

            modelBuilder.Entity("StudentManagementSystem.Entities.User", b =>
                {
                    b.Navigation("Staffs");

                    b.Navigation("Students");

                    b.Navigation("Teachers");

                    b.Navigation("UserRole")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
