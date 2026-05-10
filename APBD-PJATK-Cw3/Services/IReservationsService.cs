using APBD_PJATK_Cw3.Enums;
using APBD_PJATK_Cw3.Requests;
using APBD_PJATK_Cw3.Responses;

namespace APBD_PJATK_Cw3.Services;

public interface IReservationsService
{
    public List<ReservationResponse> GetReservations(DateOnly? date, ReservationStatus? status, long? roomId);
    public ReservationResponse GetReservation(long id);
    public ReservationResponse AddReservation(AddReservationRequest request);
    public ReservationResponse UpdateReservation(UpdateReservationRequest request, long id);
    public void DeleteReservation(long id);
}