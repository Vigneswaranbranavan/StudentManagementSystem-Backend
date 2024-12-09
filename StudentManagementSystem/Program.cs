
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StudentManagementSystem.Entities.E_mail;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Repository;
using StudentManagementSystem.Services;
using System;
using System.Text;

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

            // Register EmailConfig
            builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("EmailConfig"));

            // Register Email services
            builder.Services.AddScoped<SendMailService>();
            builder.Services.AddScoped<SendMailRepository>();
            builder.Services.AddScoped<EmailServiceProvider>();

        


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

            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
            builder.Services.AddScoped<INotificationService, NotificationService>();

            builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            builder.Services.AddScoped<IFeedbackService, FeedbackService>();

            builder.Services.AddScoped<IClassRepository, ClassRepository>();
            builder.Services.AddScoped<IClassService, ClassService>();

            builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            builder.Services.AddScoped<IAttendanceService, AttendanceService>();

            builder.Services.AddScoped<IStaffRepository, StaffRepository>();
            builder.Services.AddScoped<IStaffService, StaffService>();

            builder.Services.AddScoped<ITokenRepository, TokenRepository>();



            //builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            // JWT Authentication Configuration
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });




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


            // Ensure EmailConfig is available as a singleton if needed
            builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<EmailConfig>>().Value);
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

            // Use authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
