using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using student.Configurations;
using student.Data;
using student.Data.Repository;
using student.Models;
using System.Text;

namespace student
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Thêm các dịch vụ vào container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(op =>
            {
                op.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                op.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            builder.Services.AddDbContext<ClollegeDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
            });
            builder.Services.AddScoped<APIResponse>();
            builder.Services.AddAutoMapper(typeof(AutomapperConfig));
            builder.Services.AddScoped(typeof(IColeggeRepository<>), typeof(CollegeRepository<>));
            builder.Services.AddScoped<IStudentRepostitory, StudentRepository>();

            builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWTSecrret"]!)),
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["LocalIssuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["LocalAudience"]
                };
            });
            var app = builder.Build();
            var dbInitializer = new DatabaseInitializer(app.Services);
            dbInitializer.ApplyMigrations();

            // Cấu hình pipeline xử lý yêu cầu HTTP.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //thiếu cái này
            app.UseCors();
            app.MapControllers();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            
            app.UseAuthorization();
            app.Run();
        }
    }
}
