using APBD_PJATK_Cw3.Models;
using APBD_PJATK_Cw3.Responses;

namespace APBD_PJATK_Cw3.Mappers;

public interface IReservationsMapper
{
    public ReservationResponse MapReservationToResponse(Reservation reservation);
}