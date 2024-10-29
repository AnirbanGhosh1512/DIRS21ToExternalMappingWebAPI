using DIRS21ToExternalMapperSystem.Handler;
using DIRS21ToExternalMapperSystem.Mappers;
using DIRS21ToExternslMapperWebAPI.Registry;

namespace DIRS21ToExternslMapperWebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register services with Dependency Injection (DI) here

        // Register Logger for Dependency Injection
        builder.Services.AddLogging();

        // Register MapperRegistry as Singleton with mappers pre-registered
        builder.Services.AddSingleton<MapperRegistry>(serviceProvider =>
        {
            var logger = serviceProvider.GetRequiredService<ILogger<MapperRegistry>>();
            var registry = new MapperRegistry(logger);

            // Register mappers before adding registry to DI container
            registry.RegisterMapper("Room", "GoogleRoom", new RoomToGoogleRoomMapper());
            registry.RegisterMapper("GoogleRoom", "Room", new GoogleRoomToRoomMapper());

            registry.RegisterMapper("Reservation", "GoogleReservation", new ReservationToGoogleReservationMapper());
            registry.RegisterMapper("GoogleReservation", "Reservation", new GoogleReservationToReservationMapper());

            logger.LogInformation("MapperRegistry created and mappers registered.");
            return registry;
        });

        // Register MapHandler as Scoped
        builder.Services.AddScoped<MapHandler>();

        // Add controllers and other services to the container
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Middleware setup for the HTTP request pipeline
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

