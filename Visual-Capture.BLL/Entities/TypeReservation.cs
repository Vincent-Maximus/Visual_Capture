using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visual_Capture.BLL.Entities;

public class TypeReservation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public double Price { get; set; }
    public int MinPeople { get; set; }
    
    // Navigation Properties
    // public List<Reservation>? Reservations { get; set; }

    private readonly List<Reservation> _reservations = new List<Reservation>();
    public ICollection<Reservation> Reservations => _reservations.AsReadOnly();
}