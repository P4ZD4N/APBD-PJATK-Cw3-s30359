using APBD_PJATK_Cw3.Enums;

namespace APBD_PJATK_Cw3.Models;

public class Reservation
{
    private long Id { get; }
    private long RoomId { get; }
    private string OrganizerName { get; }
    private string Topic { get; }
    private DateOnly Date { get; }
    private TimeOnly StartTime { get; }
    private TimeOnly EndTime { get; }
    private ReservationStatus Status { get; }
}