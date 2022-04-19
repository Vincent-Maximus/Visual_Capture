
namespace Visual_Capture.DAL.DTO;

public class ReservationPossibilitiesDTO
{
    public List<TypeReservationDTO> TypeReservations { get; set;  }
    public List<DateTime> AvailableDateTimes { get; set; }
}