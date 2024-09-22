
using Itinerary_Management.BLL;
using Itinerary_Management.DAL;
using Itinerary_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Itinerary_Management {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //register DbContext
            builder.Services.AddDbContext<ItineraryDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //register DAL and BLL Services
            builder.Services.AddScoped<ItineraryDAL>();
            builder.Services.AddScoped<ItineraryService>(); 
            builder.Services.AddScoped<StayDAL>();
            builder.Services.AddScoped<StayService>(); 
            builder.Services.AddScoped<FlightDAL>();
            builder.Services.AddScoped<FlightService>(); 
            builder.Services.AddScoped<ActivityDAL>();
            builder.Services.AddScoped<ActivityService>();

            // autoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
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
