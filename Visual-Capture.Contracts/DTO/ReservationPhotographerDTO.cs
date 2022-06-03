using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Visual_Capture.Contracts.DTO;

public class ReservationPhotographerDTO
{
    // [Key]
    // Navigation Properties
    public Guid PhotographerId { get; set; }
    public PhotographerDTO? Photographer { set; get; }
    
    // [Key]
    public Guid ReservationId { get; set; }
    public ReservationDTO? Reservation { get; set; }
}