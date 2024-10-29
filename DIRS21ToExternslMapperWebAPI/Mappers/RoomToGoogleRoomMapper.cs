using System;
using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.MapperInterface;
using DIRS21ToExternalMapperSystem.Models.DIRS21Models;
using DIRS21ToExternalMapperSystem.Models.DTO;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;

namespace DIRS21ToExternalMapperSystem.Mappers
{
    public class RoomToGoogleRoomMapper : IMapperStrategy
    {
        public object Map(object source)
        {
            // Cast the source object to Room
            var _room = source as Room;

            // Validate the input object
            if (_room == null)
            {
                throw new InvalidMappingException("Invalid source object. Expected Room.");
            }

            // Directly map Room properties to GoogleRoom
            return new GoogleRoom
            {
                GoogleRoomId = _room.RoomId,            // Assuming RoomId maps to GoogleRoom.GoogleRoomId
                RoomCategory = _room.RoomType,          // Assuming RoomType maps to GoogleRoom.RoomCategory
                MaxOccupancy = _room.Capacity           // Assuming Capacity maps to GoogleRoom.MaxOccupancy
            };
        }
    }
}

