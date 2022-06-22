using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visual_Capture.BLL.Entities;

public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [DataType(DataType.PhoneNumber)]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
    public string? PhoneNumber { get; set; }
    
    // Navigation Properties
    // public List<Reservation>? Reservations { get; set; }
    
    private readonly List<Reservation> _reservations = new List<Reservation>();
    public ICollection<Reservation> Reservations => _reservations.AsReadOnly();
}