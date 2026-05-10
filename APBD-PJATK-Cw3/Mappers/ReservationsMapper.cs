using APBD_PJATK_Cw3.Models;
using APBD_PJATK_Cw3.Responses;

namespace APBD_PJATK_Cw3.Mappers;

public class ReservationsMapper : IReservationsMapper
{
    public ReservationResponse MapReservationToResponse(Reservation reservation)
    {
        return new ReservationResponse(
            reservation.Id,
            reservation.RoomId,
            reservation.OrganizerName,
            reservation.Topic,
            reservation.Date,
            reservation.StartTime,
            reservation.EndTime,
            reservation.Status);
    }
}