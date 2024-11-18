
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Repository;
using StudentManagementSystem.Services;
using System;

namespace StudentManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Avoids circular reference errors , Reduces payload size , Increases readability of the JSON response
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            });

            // Register DbContext before building the application
            builder.Services.AddDbContext<AppDbContext>(opt =>
                 opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
            builder.Services.AddScoped<ISubjectService, SubjectService>();

            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
            builder.Services.AddScoped<ITeacherService, TeacherService>();

            builder.Services.AddScoped<ITimeTableRepository, TimeTableRepository>();
            builder.Services.AddScoped<ITimeTableService, TimeTableService>();

            builder.Services.AddScoped<IClassRepository, ClassRepository>();
            builder.Services.AddScoped<IClassService, ClassService>();

            builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            builder.Services.AddScoped<IAttendanceService, AttendanceService>();


            //builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            // CORS policy setup
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                  name: "CORSOpenPolicy",
                  builder =>
                  {
                      builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                  });
            });

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Api security
            app.UseCors("CORSOpenPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
