using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visual_Capture.DAL.DTO;

public class ReservationDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    //TODO Change UserId to GUID
    // public Guid UserId { get; set; }
    public int UserId { get; set; }
    public DateTime DateTime { get; set; }
    public int AmountPeople { get; set; }
    
    //navigation properties 
    public List<UserDTO>? Users { get; set; }


    public Guid PhotographerId { get; set; }
    public PhotographerDTO? Photographer { set; get; }

    public Guid TypeReservationId { get; set; }
    public TypeReservationDTO? TypeReservation { get; set; } 
}

// public enum ReservationType
// {
//     COUPLES,
//     PORTRAITS,
//     WEDDINGS
// }

