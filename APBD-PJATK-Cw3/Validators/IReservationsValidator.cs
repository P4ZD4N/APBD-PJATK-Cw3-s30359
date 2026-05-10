using APBD_PJATK_Cw3.Models;
using APBD_PJATK_Cw3.Requests;

namespace APBD_PJATK_Cw3.Validators;

public interface IReservationsValidator
{
    public void ValidateAddReservationRequest(AddReservationRequest request);
    public void ValidateUpdateReservationRequest(UpdateReservationRequest request, Reservation reservation);
}