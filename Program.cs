using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Context.Repositories.Implementatios;
using WebApp.Context.Repositories.Interfaces;

namespace WebApp
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
			builder.Services.AddDbContext<AppDb>(op =>
			{
				op.UseSqlServer(builder.Configuration.GetConnectionString("default"));
			});
			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
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