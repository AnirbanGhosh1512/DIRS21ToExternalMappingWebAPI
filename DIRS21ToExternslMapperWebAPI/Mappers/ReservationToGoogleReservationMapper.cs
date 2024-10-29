using System;
using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.MapperInterface;
using DIRS21ToExternalMapperSystem.Models.DIRS21Models;
using DIRS21ToExternalMapperSystem.Models.DTO;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;

namespace DIRS21ToExternalMapperSystem.Mappers
{
    public class ReservationToGoogleReservationMapper : IMapperStrategy
    {
        public object Map(object source)
        {
            // Cast the source object to Reservation
            var _reservation = source as Reservation;

            // Validate the input object
            if (_reservation == null)
            {
                throw new InvalidMappingException("Expected Reservation object but received something else.",
                    source?.GetType().Name, "GoogleReservation");
            }

            // Directly map Reservation properties to GoogleReservation
            return new GoogleReservation
            {
                GoogleId = _reservation.ReservationId,
                UserName = _reservation.CustomerName,
                BookingDate = _reservation.ReservationDate
            };
        }
    }

}

