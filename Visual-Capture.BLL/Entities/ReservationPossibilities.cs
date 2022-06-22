
namespace Visual_Capture.BLL.Entities;

public class ReservationPossibilities
{
    // public List<Reservation>? Reservations { get; set;  }
    
    private readonly List<Reservation> _reservation = new List<Reservation>();
    public ICollection<Reservation> Reservation => _reservation.AsReadOnly();
    
    
    // public List<Customer>? Customers { get; set;  }
    private readonly List<Customer> _customers = new List<Customer>();
    public ICollection<Customer> Customers => _customers.AsReadOnly();
    
    
    // public List<Photographer>? Photographers { get; set;  }
    
    
    private readonly List<Photographer> _photographers = new List<Photographer>();
    public ICollection<Photographer> Photographers => _photographers.AsReadOnly();
    
    
    // public List<TypeReservation>? TypeReservations { get; set;  }
    
    
    private readonly List<TypeReservation> _typeReservations = new List<TypeReservation>();
    public ICollection<TypeReservation> TypeReservations => _typeReservations.AsReadOnly();
    
    
}