using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Context;
using Demo.PL.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<StockDbContext>( options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			builder.Services.AddScoped <IUnitOfWork,UnitOfWork> ();
			builder.Services.AddAutoMapper(typeof(ItemProfile));
			builder.Services.AddAutoMapper(typeof(StoreProfile));
            builder.Services.AddAutoMapper(typeof(ItemStockProfile));

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}