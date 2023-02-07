global using System.Threading.Tasks;
global using System.Collections.Generic;
using TestInvoiceAPI.DataBase_Handler;

namespace TestInvoiceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Dependency Injection
            builder.Services.AddScoped<ISqlServerHandler>((x) =>
                new SqlServerHandler(builder.Configuration.GetConnectionString("SQL-SERVER")));

            builder.Services.AddScoped((x) =>
                builder.Configuration.GetSection("DbQuerys"));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();



            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}