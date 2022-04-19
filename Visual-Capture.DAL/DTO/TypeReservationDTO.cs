using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visual_Capture.DAL.DTO;

public class TypeReservationDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public double Price { get; set; }
    public int MinPeople { get; set; }
    
    // Navigation Properties
    public List<ReservationDTO>? Reservations { get; set; }
}