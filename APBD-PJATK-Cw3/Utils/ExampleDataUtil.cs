using APBD_PJATK_Cw3.Models;

namespace APBD_PJATK_Cw3.Utils;

public static class ExampleDataUtil
{
    public static List<Room> Rooms = new List<Room>();
    public static List<Reservation> Reservations = new List<Reservation>();

    public static void InitializeData()
    {
        InitializeRooms();
    }

    private static void InitializeRooms()
    {
        Rooms.Add(new Room(1, "Sala wykładowa A1", "A", 1, 150, true, true));
        Rooms.Add(new Room(2, "Laboratorium komputerowe 102", "A", 1, 25, true, true));
        Rooms.Add(new Room(3, "Pokój konsultacyjny", "B", 0, 5, false, true));
        Rooms.Add(new Room(4, "Sala ćwiczeniowa 205", "C", 2, 30, true, true));
        Rooms.Add(new Room(5, "Audytorium Max", "A", 0, 300, true, true));
        Rooms.Add(new Room(6, "Sala archiwalna", "B", -1, 10, false, false));
    }
}