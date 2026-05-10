using APBD_PJATK_Cw3.Requests;
using APBD_PJATK_Cw3.Responses;

namespace APBD_PJATK_Cw3.Services;

public interface IRoomsService
{
    public List<RoomResponse> GetRooms(int? minCapacity, bool? hasProjector, bool? isActive);
    public RoomResponse GetRoom(long id);
    public List<RoomResponse> GetByBuildingCode(string buildingCode);
    public RoomResponse AddRoom(AddRoomRequest request);
    public RoomResponse UpdateRoom(UpdateRoomRequest request, long id);
    public void DeleteRoom(long id);
}