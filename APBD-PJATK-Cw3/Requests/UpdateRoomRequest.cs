namespace APBD_PJATK_Cw3.Requests;

public record UpdateRoomRequest(
    string? Name,
    string? BuildingCode,
    int? Floor,
    int? Capacity,
    bool? HasProjector,
    bool? IsActive
);