using APBD_PJATK_Cw3.Enums;
using APBD_PJATK_Cw3.Mappers;
using APBD_PJATK_Cw3.Models;
using APBD_PJATK_Cw3.Requests;
using APBD_PJATK_Cw3.Responses;
using APBD_PJATK_Cw3.Utils;
using APBD_PJATK_Cw3.Validators;

namespace APBD_PJATK_Cw3.Services;

public class ReservationsService(
    IReservationsMapper reservationsMapper, 
    IReservationsValidator reservationsValidator
) : IReservationsService
{
    public List<ReservationResponse> GetReservations(DateOnly? date, ReservationStatus? status, long? roomId)
    {
        return ExampleDataUtil.Reservations
            .Where(r => 
                (!date.HasValue || r.Date == date) &&
                (!status.HasValue || r.Status == status) &&
                (roomId == null || r.RoomId == roomId))
            .Select(reservationsMapper.MapReservationToResponse)
            .ToList();
    }

    public ReservationResponse GetReservation(long id)
    {
        return reservationsMapper.MapReservationToResponse(Reservation.FindAndGetReservation(id));
    }

    public ReservationResponse AddReservation(AddReservationRequest request)
    {
        reservationsValidator.ValidateAddReservationRequest(request);
        
        var reservation = new Reservation(
            request.RoomId,
            request.OrganizerName,
            request.Topic,
            request.Date,
            request.StartTime,
            request.EndTime,
            request.Status);
        
        ExampleDataUtil.Reservations.Add(reservation);

        return reservationsMapper.MapReservationToResponse(reservation);
    }

    public ReservationResponse UpdateReservation(UpdateReservationRequest request, long id)
    {
        var reservation = Reservation.FindAndGetReservation(id);
        
        reservationsValidator.ValidateUpdateReservationRequest(request, reservation);
        
        if (request.RoomId != null)
            reservation.RoomId = request.RoomId.Value;
        
        if (request.OrganizerName != null)
            reservation.OrganizerName = request.OrganizerName;

        if (request.Topic != null)
            reservation.Topic = request.Topic;

        reservation.Date = request.Date;
        reservation.StartTime = request.StartTime;
        reservation.EndTime = request.EndTime;
        
        if (request.Status.HasValue)
            reservation.Status = request.Status.Value;
        
        return reservationsMapper.MapReservationToResponse(reservation);
    }

    public void DeleteReservation(long id)
    {
        ExampleDataUtil.Reservations.Remove(Reservation.FindAndGetReservation(id));
    }
}