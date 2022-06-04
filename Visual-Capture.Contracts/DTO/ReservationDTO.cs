using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visual_Capture.Contracts.DTO;

public class ReservationDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CustomerId { get; set; }
    public DateTime DateTime { get; set; }
    public int AmountPeople { get; set; }
    
    //navigation properties 
    public List<CustomerDTO>? Customer { get; set; }

    
    public ICollection<ReservationPhotographerDTO> reservationPhotographer { get; set; }

    public Guid TypeReservationId { get; set; }
    public TypeReservationDTO? TypeReservation { get; set; } 
}

