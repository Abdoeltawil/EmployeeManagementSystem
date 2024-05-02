using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Application.Services.Department;
using Infrastructure.UnitOfWork;
using Application.Services.Employee;
using Infrastructure.Repositories.Employee;

namespace EmployeeManagmentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DatabaseContext>(
               dbContextOptionBuilder =>
               {
                   var connectionString = builder.Configuration.GetConnectionString("Database");
                   dbContextOptionBuilder.UseSqlServer(connectionString).LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                   .EnableDetailedErrors(true).EnableSensitiveDataLogging(true);
               });
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DatabaseContext>();
                context.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(policy=> policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200/"));
            app.MapControllers();

            app.Run();
        }
    }
}
