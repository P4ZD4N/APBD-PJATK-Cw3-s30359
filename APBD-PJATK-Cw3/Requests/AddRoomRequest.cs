using System.ComponentModel.DataAnnotations;

namespace APBD_PJATK_Cw3.Requests;

public record AddRoomRequest(
    [Required] 
    [MinLength(2)]
    [MaxLength(50)]
    string Name,
    
    [Required] 
    [MinLength(1)]
    [MaxLength(1)]
    string BuildingCode,
    
    [Range(1, int.MaxValue)]
    int Floor,
    
    [Range(1, int.MaxValue)]
    int Capacity,
    
    bool HasProjector,
    bool IsActive
);