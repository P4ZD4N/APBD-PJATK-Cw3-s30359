using APBD_PJATK_Cw3.Mappers;
using APBD_PJATK_Cw3.Models;
using APBD_PJATK_Cw3.Requests;
using APBD_PJATK_Cw3.Responses;
using APBD_PJATK_Cw3.Utils;

namespace APBD_PJATK_Cw3.Services;

public class RoomsService(IRoomsMapper roomsMapper) : IRoomsService
{
    public List<RoomResponse> GetRooms(int? minCapacity, bool? hasProjector, bool? isActive)
    {
        return ExampleDataUtil.Rooms
            .Where(r => 
                (!minCapacity.HasValue || r.Capacity >= minCapacity) &&
                (!hasProjector.HasValue || r.HasProjector == hasProjector) &&
                (!isActive.HasValue || r.IsActive == isActive))
            .Select(roomsMapper.MapRoomToResponse)
            .ToList();
    }

    public RoomResponse GetRoom(int id)
    {
        return roomsMapper.MapRoomToResponse(FindAndGetRoom(id));
    }

    public List<RoomResponse> GetByBuildingCode(string buildingCode)
    {
        return ExampleDataUtil.Rooms
            .Where(r => r.BuildingCode == buildingCode)
            .Select(roomsMapper.MapRoomToResponse)
            .ToList();
    }

    public RoomResponse AddRoom(AddRoomRequest request)
    {
        var room = new Room(
            ExampleDataUtil.Rooms.Max(r => r.Id) + 1, 
            request.Name, 
            request.BuildingCode,
            request.Floor, 
            request.Capacity, 
            request.HasProjector, 
            request.IsActive);
        
        ExampleDataUtil.Rooms.Add(room);

        return roomsMapper.MapRoomToResponse(room);
    }

    public RoomResponse UpdateRoom(UpdateRoomRequest request, int id)
    {
        var room = FindAndGetRoom(id);
        
        if (request.Name != null)
            room.Name = request.Name;
        
        if (request.BuildingCode != null)
            room.BuildingCode = request.BuildingCode;
        
        if (request.Floor.HasValue)
            room.Floor = request.Floor.Value;
        
        if (request.Capacity.HasValue)
            room.Capacity = request.Capacity.Value;
        
        if (request.HasProjector.HasValue)
            room.HasProjector = request.HasProjector.Value;
        
        if (request.IsActive.HasValue)
            room.IsActive = request.IsActive.Value;
        
        return roomsMapper.MapRoomToResponse(room);
    }

    public void DeleteRoom(int id)
    {
        ExampleDataUtil.Rooms.Remove(FindAndGetRoom(id));
    }

    private Room FindAndGetRoom(int id)
    {
        var room = ExampleDataUtil.Rooms.FirstOrDefault(r => r.Id == id);
        return room ?? throw new KeyNotFoundException($"Room with ID {id} was not found in database!");
    }
}