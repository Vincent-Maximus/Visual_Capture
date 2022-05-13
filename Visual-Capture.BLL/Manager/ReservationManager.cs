using Microsoft.AspNetCore.Mvc;
using Visual_Capture.BLL.Entities;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.BLL.Manager;

public class ReservationManager
{
    private readonly IDal<ReservationDTO> _reservationDal;

    public ReservationManager(IDal<ReservationDTO> reservationDal)
    {
        _reservationDal = reservationDal;
    }

    //Get Single data 
    public ReservationDTO? GetOne(Guid? id)
    {
        ReservationDTO? obj = _reservationDal.Get(id);
        return obj;
    }


    //Get All data 
    public List<ReservationDTO> GetAllReservationDTO()
    {
        List<ReservationDTO> obj = _reservationDal.GetAll();
        return obj;
    }

    //GET
    [HttpPost]
    public void Create(ReservationDTO obj)
    {
        _reservationDal.Create(obj);
    }

    [HttpPost]
    public void Create(ReservationPossibilitiesDTO model)
    {
        //  check model.EmployeeId 
        //  to do : Save and redirect 
    }
}