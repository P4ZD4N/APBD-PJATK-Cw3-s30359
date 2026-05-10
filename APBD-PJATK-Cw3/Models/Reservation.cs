using APBD_PJATK_Cw3.Enums;
using APBD_PJATK_Cw3.Utils;

namespace APBD_PJATK_Cw3.Models;

public class Reservation(
    long roomId, 
    string organizerName, 
    string topic, 
    DateOnly date, 
    TimeOnly startTime, 
    TimeOnly endTime, 
    ReservationStatus status)
{
    public long Id { get; } = ExampleDataUtil.Reservations
        .Select(r => r.Id)
        .DefaultIfEmpty(0)
        .Max() + 1;
    public long RoomId { get; set; } = roomId;
    public string OrganizerName { get; set; } = organizerName;
    public string Topic { get; set; } = topic;
    public DateOnly Date { get; set; } = date;
    public TimeOnly StartTime { get; set; } = startTime;
    public TimeOnly EndTime { get; set; } = endTime;
    public ReservationStatus Status { get; set; } = status;
    
    public static Reservation FindAndGetReservation(long id)
    {
        var reservation = ExampleDataUtil.Reservations.FirstOrDefault(r => r.Id == id);
        return reservation ?? throw new KeyNotFoundException($"Reservation with ID {id} was not found in database!");
    }
}