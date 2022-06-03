
namespace Visual_Capture.BLL.Entities;

public class ReservationPossibilities
{
    public List<Reservation>? Reservations { get; set;  }
    public List<Customer>? Customers { get; set;  }
    public List<Photographer>? Photographers { get; set;  }
    public List<TypeReservation>? TypeReservations { get; set;  }
}