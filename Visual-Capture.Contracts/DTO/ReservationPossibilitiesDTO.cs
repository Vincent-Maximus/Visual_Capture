
namespace Visual_Capture.Contracts.DTO;

public class ReservationPossibilitiesDTO
{
    public List<TypeReservationDTO> TypeReservations { get; set;  }
    public List<DateTime> AvailableDateTimes { get; set; }
}