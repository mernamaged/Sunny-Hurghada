using Microsoft.EntityFrameworkCore;
using Sunny_Hurghada.Managers;
using Sunny_Hurghada.Models;
using Sunny_Hurghada.Repositories;

namespace SunnyHurghada
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            // Register SunnyHurghadaContext with dependency injection
            builder.Services.AddDbContext<SunnyHurghadaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Use your connection string


            builder.Services.AddScoped<ContactRepository>();
            builder.Services.AddScoped<DestinationRepository>();
            builder.Services.AddScoped<TourTypeRepository>();
            builder.Services.AddScoped<SpotRepository>();
            builder.Services.AddScoped<GuestEmailRepository>();
            builder.Services.AddScoped<LayoutManager>();
            builder.Services.AddScoped<TransferReprository>();
            builder.Services.AddScoped<PaymentRepository>();
            builder.Services.AddScoped<LanguageRepository>();

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
