
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
// using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.BLL.Entities;


public class Reservation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; } = Guid.NewGuid();
    //navigation properties 
    public List<Customer>? Customers { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime DateTime { get; set; }
    public int AmountPeople { get; set; }
    
    
    public ICollection<ReservationPhotographer> reservationPhotographer { get; set; }

    public Guid TypeReservationId { get; set; }
    public List<TypeReservation>? TypeReservation { get; set; } 
    
    
    // private readonly IDal<ReservationDTO> _ReservationDal;
    //
    // //GET
    // [HttpPost]
    // public void Edit(ReservationDTO obj)
    // {
    //     _ReservationDal.Edit(obj);
    // }
}


