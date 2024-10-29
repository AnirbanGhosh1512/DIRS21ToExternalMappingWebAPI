using Microsoft.AspNetCore.Mvc;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;
using DIRS21ToExternalMapperSystem.Models.DIRS21Models;
using DIRS21ToExternalMapperSystem.Handler;
using DIRS21ToExternalMapperSystem.Mappers;
using Serilog;
using DIRS21ToExternslMapperWebAPI.Registry;

[ApiController]
[Route("api/[controller]")]
public class MappingController : ControllerBase
{
    private readonly MapHandler _mapHandler;
    private readonly MapperRegistry _mapperRegistry; // For debugging purposes

    public MappingController(MapHandler mapHandler, MapperRegistry mapperRegistry)
    {
        _mapHandler = mapHandler;
        _mapperRegistry = mapperRegistry;
    }

    [HttpPost("map-room-to-google-room")]
    public ActionResult<GoogleRoom> MapRoomToGoogleRoom([FromBody] Room room)
    {
        try
        {
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            // This will get current filePath for logs
            string filepathLOG = Path.Combine(projectDirectory, "logs", "mappinglog.txt");
            // Configure Serilog to log to console and file
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(filepathLOG, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application Starting...");
            Log.Information("Attempting to map Room to GoogleRoom");
            // Automatically resolve the strategy using the registry
            var _googleRoom = _mapHandler.Map(room, "Room", "GoogleRoom") as GoogleRoom;

            if (_googleRoom == null)
            {
                Log.Information("Mapping from Room to GoogleRoom failed.");
                return BadRequest("Failed to map Room to GoogleRoom.");
            }

            Log.Information("Mapping from Room to GoogleRoom successful.");
            Log.Information("Application Ending...");
            return Ok(_googleRoom);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("map-google-room-to-room")]
    public ActionResult<Room> MapGoogleRoomToRoom([FromBody] GoogleRoom googleRoom)
    {
        try
        {
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            // This will get current filePath for logs
            string filepathLOG = Path.Combine(projectDirectory, "logs", "mappinglog.txt");
            // Configure Serilog to log to console and file
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(filepathLOG, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application Starting...");
            Log.Information("Attempting to map GoogleRoom to room");
            // Automatically resolve the strategy using the registry
            var _room = _mapHandler.Map(googleRoom, "GoogleRoom", "Room") as Room;

            if (_room == null)
            {
                Log.Information("Mapping from GoogleRoom to room failed.");
                return BadRequest("Failed to map GoogleRoom to room.");
            }

            Log.Information("Mapping from GoogleRoom to Room successful.");
            Log.Information("Application Ending...");
            return Ok(_room);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("map-reservation-to-google-reservation")]
    public ActionResult<GoogleReservation> MapReservationToGoogleReservation([FromBody] Reservation reservation)
    {
        try
        {
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            // This will get current filePath for logs
            string filepathLOG = Path.Combine(projectDirectory, "logs", "mappinglog.txt");
            // Configure Serilog to log to console and file
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(filepathLOG, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application Starting...");
            Log.Information("Attempting to map Reservation to GoogleReservation");
            // Automatically resolve the strategy using the registry
            var _googleReservation = _mapHandler.Map(reservation, "Reservation", "GoogleReservation") as GoogleReservation;

            if (_googleReservation == null)
            {
                Log.Information("Mapping from Reservation to GoogleReservation failed.");
                return BadRequest("Failed to map Reservation to GoogleReservation.");
            }

            Log.Information("Mapping from Reservation to GoogleReservation successful.");
            Log.Information("Application Ending...");
            return Ok(_googleReservation);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("map-google-reservation-to-reservation")]
    public ActionResult<Reservation> MapGoogleReservationToReservation([FromBody] GoogleReservation googleReservation)
    {
        try
        {
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            // This will get current filePath for logs
            string filepathLOG = Path.Combine(projectDirectory, "logs", "mappinglog.txt");
            // Configure Serilog to log to console and file
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(filepathLOG, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application Starting...");
            Log.Information("Attempting to map GoogleReservation to Reservation");
            // Automatically resolve the strategy using the registry
            var _reservation = _mapHandler.Map(googleReservation, "GoogleReservation", "Reservation") as Reservation;

            if (_reservation == null)
            {
                Log.Information("Mapping from GoogleReservation to Reservation failed.");
                return BadRequest("Failed to map GoogleReservation to Reservation.");
            }

            Log.Information("Mapping from GoogleReservation to Reservation successful.");
            Log.Information("Application Ending...");
            return Ok(_reservation);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}



