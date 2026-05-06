namespace APBD_PJATK_Cw3.Models;

public class Room(long id, string name, string buildingCode, int floor, int capacity, bool hasProjector, bool isActive)
{
    public long Id { get; } = id;
    public string Name { get; set; } = name;
    public string BuildingCode { get; set; } = buildingCode;
    public int Floor { get; set; } = floor;
    public int Capacity { get; set; } = capacity;
    public bool HasProjector { get; set; } = hasProjector;
    public bool IsActive { get; set; } = isActive;
}