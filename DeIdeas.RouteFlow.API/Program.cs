
using AutoMapper;
using DeIdeas.RouteFlow.API.DAL.Context;
using DeIdeas.RouteFlow.API.DAL.Interfaces;
using DeIdeas.RouteFlow.API.DAL.Repositories;
using DeIdeas.RouteFlow.API.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DeIdeas.RouteFlow.API
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

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAutoMapper(cfg => { }, typeof(AutoMapperProfile));

            // Database connection string handling
            // 1) Loaded from User Secrets in Development or Azure Key Vault in Production when configured
            // 2) Enforce security constraints for production
            var conn = builder.Configuration.GetConnectionString("DefaultConnection");
            var legacyConn = builder.Configuration.GetConnectionString("LegacyConnection") ?? conn;

            // Contexto legacy (solo lectura, sin migraciones)
            builder.Services.AddDbContext<LegacyContext>(opts => opts.UseSqlServer(conn));

            // Contexto de app (Code-First, con migraciones)
            builder.Services.AddDbContext<AppDbContext>(opts =>
                opts.UseSqlServer(conn, sql => sql.MigrationsAssembly("DeIdeas.RouteFlow.API.DAL"))
            );

            // CORS policy to allow Angular dev app (origin path parts like /starter are ignored by CORS)
            /*
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularStarter", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                });
            });*/

            var app = builder.Build();

            // Enable CORS policy ***********************************************************************
            app.UseCors("AllowAngularStarter");

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
