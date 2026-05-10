using APBD_PJATK_Cw3.Models;
using APBD_PJATK_Cw3.Requests;
using APBD_PJATK_Cw3.Utils;

namespace APBD_PJATK_Cw3.Validators;

public class ReservationsValidator : IReservationsValidator
{
    public void ValidateAddReservationRequest(AddReservationRequest request)
    {
        ValidateIfRoomExists(request.RoomId);
        ValidateIfRoomIsActive(request.RoomId);
        ValidateTimeRange(request.StartTime, request.EndTime);
        ValidateDateTimeOverlap(request.RoomId, request.Date, request.StartTime, request.EndTime);
    }

    public void ValidateUpdateReservationRequest(UpdateReservationRequest request, Reservation reservation)
    {
        if (request.RoomId.HasValue)
        {
            ValidateIfRoomExists(request.RoomId.Value);
            ValidateIfRoomIsActive(request.RoomId.Value);
        }

        ValidateTimeRange(request.StartTime, request.EndTime);
        ValidateDateTimeOverlap(request.RoomId ?? reservation.RoomId, request.Date, request.StartTime, request.EndTime, reservation.Id);
    }

    private void ValidateIfRoomExists(long roomId)
    {
        if (ExampleDataUtil.Rooms.All(r => r.Id != roomId))
        {
            throw new KeyNotFoundException(
                $"Room with ID {roomId} was not found in database!"
            );
        }
    }

    private void ValidateIfRoomIsActive(long roomId)
    {
        if (!ExampleDataUtil.Rooms.First(r => r.Id == roomId).IsActive)
        {
            throw new ArgumentException($"Room with ID {roomId} is not active!");
        }
    }
    

    private void ValidateTimeRange(TimeOnly start, TimeOnly end)
    {
        if (end <= start)
        {
            throw new ArgumentException("EndTime must be after StartTime!");
        }
    }

    private void ValidateDateTimeOverlap(
        long roomId, 
        DateOnly date, 
        TimeOnly start, 
        TimeOnly end, 
        long? ignoreReservationId = null)
    {
        var overlaps = ExampleDataUtil.Reservations
            .Where(r => r.RoomId == roomId && r.Date == date)
            .Where(r => !ignoreReservationId.HasValue || r.Id != ignoreReservationId.Value)
            .Any(r => start < r.EndTime && end > r.StartTime);

        if (overlaps)
        {
            throw new ArgumentException("Reservation date overlaps date and time of other reservation!");
        }
    }
}