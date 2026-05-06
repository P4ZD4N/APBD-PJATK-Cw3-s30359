using APBD_PJATK_Cw3.Models;
using APBD_PJATK_Cw3.Responses;

namespace APBD_PJATK_Cw3.Mappers;

public class RoomsMapper : IRoomsMapper
{
    public RoomResponse MapRoomToResponse(Room room)
    {
        return new RoomResponse(
            room.Id, 
            room.Name, 
            room.BuildingCode, 
            room.Floor, room.Capacity, 
            room.HasProjector, 
            room.IsActive);
    }
}