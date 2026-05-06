namespace APBD_PJATK_Cw3.Responses;

public record RoomResponse(
    long Id,
    string Name,
    string BuildingCode,
    int Floor,
    int Capacity,
    bool HasProjector,
    bool IsActive
);