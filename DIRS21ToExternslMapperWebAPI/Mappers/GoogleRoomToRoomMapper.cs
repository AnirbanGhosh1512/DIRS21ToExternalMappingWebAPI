using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.MapperInterface;
using DIRS21ToExternalMapperSystem.Models.DIRS21Models;
using DIRS21ToExternalMapperSystem.Models.DTO;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;

namespace DIRS21ToExternalMapperSystem.Mappers
{
    public class GoogleRoomToRoomMapper : IMapperStrategy
    {
        public object Map(object source)
        {
            // Cast the source object to GoogleRoom
            var _googleRoom = source as GoogleRoom;

            // Validate the input object
            if (_googleRoom == null)
            {
                throw new InvalidMappingException("Expected GoogleRoom object but received something else.",
                    source?.GetType().Name, "Room");
            }

            // Perform the mapping from GoogleRoom to Room
            return new Room
            {
                RoomId = _googleRoom.GoogleRoomId,
                RoomType = _googleRoom.RoomCategory,
                Capacity = _googleRoom.MaxOccupancy
            };
        }
    }

}

