using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Entities;
using StudentManagementSystem.Entities.E_mail;
namespace StudentManagementSystem
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Timetable> Timetables { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<OTP> OTPs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role { ID = Guid.NewGuid(), RoleName = "administrator"},
                new Role { ID = Guid.NewGuid(), RoleName = "staff" },
                new Role { ID = Guid.NewGuid(), RoleName = "teacher"},
                new Role { ID = Guid.NewGuid(), RoleName = "student"}
                );

            //modelBuilder.Entity<UserRole>()
            //    .HasKey(ur => new { ur.UserID, ur.RoleID });

            //modelBuilder.Entity<UserRole>()
            //    .HasOne(ur => ur.User)
            //    .WithMany(u => u.UserRoles)
            //    .HasForeignKey(ur => ur.UserID);

            //modelBuilder.Entity<UserRole>()
            //    .HasOne(ur => ur.Role)
            //    .WithMany(r => r.UserRoles)
            //    .HasForeignKey(ur => ur.RoleID);


        }

    }
}

