using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// using Visual_Capture.Contracts.DTO;

namespace Visual_Capture.BLL.Entities;

public class ReservationPhotographer
{
    // Navigation Properties
    public Guid PhotographerId { get; set; }
    public Photographer? Photographer { set; get; }
    
    // [Key]
    public Guid ReservationsId { get; set; }
    public Reservation Reservations { get; set; }
}