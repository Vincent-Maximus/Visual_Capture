
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
// using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.BLL.Entities;


public class ReservationPhotographerView
{
    // [Key]
    // public Guid Id { get; set; } = Guid.NewGuid();
    //navigation properties 
    public List<Customer>? Customers { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime DateTime { get; set; }
    public int AmountPeople { get; set; }
    
    // public List<Photographer> Photographers { get; set; }

    private readonly List<Photographer> _photographers = new List<Photographer>();
    public ICollection<Photographer> Photographers => _photographers.AsReadOnly();

    public Guid TypeReservationId { get; set; }

    public ReservationPhotographerView(List<Photographer> photographers)
    {
            _photographers.AddRange(photographers);
    }
}


