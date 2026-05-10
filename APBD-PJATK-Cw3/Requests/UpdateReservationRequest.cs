using System.ComponentModel.DataAnnotations;
using APBD_PJATK_Cw3.Enums;

namespace APBD_PJATK_Cw3.Requests;

public record UpdateReservationRequest(
    [Range(1, int.MaxValue)]
    long? RoomId,
    
    [MinLength(2)]
    [MaxLength(50)]
    string? OrganizerName,
    
    [MinLength(2)]
    [MaxLength(50)]
    string? Topic,
    
    [Required]
    DateOnly Date,
    
    [Required]
    TimeOnly StartTime,
    
    [Required]
    TimeOnly EndTime,
    
    ReservationStatus? Status
);