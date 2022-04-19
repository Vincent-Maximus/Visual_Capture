using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visual_Capture.BLL.Entities;

public class Photographer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    
    // Navigation Properties
    public List<Reservation>? Reservations { get; set; }
}