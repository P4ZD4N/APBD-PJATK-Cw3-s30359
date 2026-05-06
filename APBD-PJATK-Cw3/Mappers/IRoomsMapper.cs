using APBD_PJATK_Cw3.Models;
using APBD_PJATK_Cw3.Responses;

namespace APBD_PJATK_Cw3.Mappers;

public interface IRoomsMapper
{
    public RoomResponse MapRoomToResponse(Room room);
}