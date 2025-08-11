using FluentValidation;
using FluentValidation.AspNetCore;
using LibreriaEcommerce.Api.Libro.Application;
using LibreriaEcommerce.Api.Libro.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibreriaEcommerce.Api.Libro
{
    public static class Startup
    {
        public static WebApplication InitApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString")));

            builder.Services.AddMediatR(typeof(Nuevo.Manejador).Assembly);

            //AutoMapper
            builder.Services.AddAutoMapper(typeof(Startup));

            //FluentValidation
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<Nuevo.Ejecuta>();

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }


        public static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

        }

    }
}
