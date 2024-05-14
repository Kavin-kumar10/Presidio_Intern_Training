using Microsoft.EntityFrameworkCore;
using RequestTrackerAPIApp.Context;
using RequestTrackerAPIApp.Interfaces;
using RequestTrackerAPIApp.Modals;
using RequestTrackerAPIApp.Repositories;
using RequestTrackerAPIApp.Services;

namespace RequestTrackerAPIApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<RequestTrackerContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
            );

            builder.Services.AddScoped<IRepository<int, Employee>, EmployeeRepository>();

            builder.Services.AddScoped<IEmployeeService, EmployeeBasicService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

        }
    }
}
