using APBD_PJATK_Cw3.Utils;

namespace APBD_PJATK_Cw3.Models;

public class Room(string name, string buildingCode, int floor, int capacity, bool hasProjector, bool isActive)
{
    public long Id { get; } = ExampleDataUtil.Rooms
        .Select(r => r.Id)
        .DefaultIfEmpty(0)
        .Max() + 1;
    public string Name { get; set; } = name;
    public string BuildingCode { get; set; } = buildingCode;
    public int Floor { get; set; } = floor;
    public int Capacity { get; set; } = capacity;
    public bool HasProjector { get; set; } = hasProjector;
    public bool IsActive { get; set; } = isActive;
    
    public static Room FindAndGetRoom(long id)
    {
        var room = ExampleDataUtil.Rooms.FirstOrDefault(r => r.Id == id);
        return room ?? throw new KeyNotFoundException($"Room with ID {id} was not found in database!");
    }
}