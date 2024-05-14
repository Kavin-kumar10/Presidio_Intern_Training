using DoctorClinicApplication.Context;
using DoctorClinicApplication.Interface;
using DoctorClinicApplication.Modals;
using DoctorClinicApplication.Repositories;
using DoctorClinicApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicApplication
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


            builder.Services.AddDbContext<DoctorClinicContext>(
                options => options.UseSqlServer("Data Source=CB66JX3\\DEMOINSTANCE;Initial Catalog=dbDoctorClinic14May2024;Integrated Security=true;")
            );

            builder.Services.AddScoped<IRepository<int, Doctor>, DoctorRepository>();
            builder.Services.AddScoped<IDoctorService, DoctorBasicService>();


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
