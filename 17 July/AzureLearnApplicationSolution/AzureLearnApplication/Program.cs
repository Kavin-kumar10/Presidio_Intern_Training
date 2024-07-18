using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using AzureLearnApplication.Context;
using AzureLearnApplication.Interfaces;
using AzureLearnApplication.Models;
using AzureLearnApplication.Repository;
using AzureLearnApplication.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace AzureLearnApplication
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            try
            {


                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();


                const string secretName = "stringproductapi";
                var keyVaultName = "kavin-vault";
                var kvUri = $"https://{keyVaultName}.vault.azure.net";

                var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

                Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
                var secret = await client.GetSecretAsync(secretName);
                Console.WriteLine(secret.Value.Value);
                builder.Services.AddDbContext<DbProductContext>(options => options.UseSqlServer(secret.Value.Value));

                //Data source = 20.102.110.7; Integrated Security = true; Initial catalog = dbAzureLearn

                //Server = 20.102.110.7; Database = dbAzureLearn; User Id = kavin; Password = **********;

                //Data source = 20.102.110.7; Integrated Security = true; Initial catalog = dbEcommerce


                builder.Services.AddScoped<IRepository<int,Product>, ProductRepository>();
                builder.Services.AddScoped<IProductServices, ProductService>();


                builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
                {
                    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                }));


                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseCors("corspolicy");

                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);   
            }
        }
    }
}
