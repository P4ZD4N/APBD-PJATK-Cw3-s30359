using APBD_PJATK_Cw3.Enums;

namespace APBD_PJATK_Cw3.Responses;

public record ReservationResponse(
    long Id,
    long RoomId,
    string OrganizerName,
    string Topic,
    DateOnly Date,
    TimeOnly StartTime,
    TimeOnly EndTime,
    ReservationStatus Status
);