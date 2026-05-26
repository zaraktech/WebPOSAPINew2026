using APIDBFirst.Models;
using APIDBFirst.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

namespace APIDBFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "APIDBFirst",
                    Version = "v1"
                });

                c.ResolveConflictingActions(apiDescriptions =>
                    apiDescriptions.First());
            });

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(
                typeof(IGenericRepository<>),
                typeof(GenericRepository<>));


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazor",
                    policy =>
                    {
                        policy
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(
                        "/swagger/v1/swagger.json",
                        "API v1");
                });
            }
            
            app.UseHttpsRedirection();
            app.UseCors("AllowBlazor");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}