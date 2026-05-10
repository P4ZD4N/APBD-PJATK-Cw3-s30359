using APBD_PJATK_Cw3.Enums;
using APBD_PJATK_Cw3.Models;

namespace APBD_PJATK_Cw3.Utils;

public static class ExampleDataUtil
{
    public static List<Room> Rooms = new();
    public static List<Reservation> Reservations = new();

    public static void InitializeData()
    {
        InitializeRooms();
        InitializeReservations();
    }

    private static void InitializeRooms()
    {
        Rooms.Add(new Room("Sala wykładowa A1", "A", 1, 150, true, true));
        Rooms.Add(new Room("Laboratorium komputerowe 102", "A", 1, 25, true, true));
        Rooms.Add(new Room("Pokój konsultacyjny", "B", 0, 5, false, true));
        Rooms.Add(new Room("Sala ćwiczeniowa 205", "C", 2, 30, true, true));
        Rooms.Add(new Room("Audytorium Max", "A", 0, 300, true, true));
        Rooms.Add(new Room("Sala archiwalna", "B", -1, 10, false, false));
    }
    
    private static void InitializeReservations()
    {
        Reservations.Add(new Reservation(
            1,
            "Jan Kowalski",
            "Wykład z programowania",
            new DateOnly(2026, 5, 12),
            new TimeOnly(8, 0),
            new TimeOnly(10, 0),
            ReservationStatus.Confirmed
        ));

        Reservations.Add(new Reservation(
            2,
            "Anna Nowak",
            "Laboratoria z baz danych",
            new DateOnly(2026, 5, 12),
            new TimeOnly(10, 15),
            new TimeOnly(12, 0),
            ReservationStatus.Confirmed
        ));

        Reservations.Add(new Reservation(
            3,
            "Michał Wiśniewski",
            "Konsultacje projektowe",
            new DateOnly(2026, 5, 13),
            new TimeOnly(14, 0),
            new TimeOnly(15, 30),
            ReservationStatus.Planned
        ));

        Reservations.Add(new Reservation(
            5,
            "Katarzyna Zielińska",
            "Konferencja wydziałowa",
            new DateOnly(2026, 5, 14),
            new TimeOnly(9, 0),
            new TimeOnly(16, 0),
            ReservationStatus.Confirmed
        ));

        Reservations.Add(new Reservation(
            4,
            "Piotr Lewandowski",
            "Ćwiczenia z matematyki",
            new DateOnly(2026, 5, 15),
            new TimeOnly(11, 30),
            new TimeOnly(13, 0),
            ReservationStatus.Cancelled
        ));
    }
}