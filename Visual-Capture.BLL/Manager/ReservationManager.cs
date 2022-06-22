using Microsoft.AspNetCore.Mvc;
using Visual_Capture.BLL.Entities;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.BLL.Manager;

public class ReservationManager
{
    private readonly IManagerDal<ReservationDTO> _reservationManagerDal;

        public ReservationManager(IManagerDal<ReservationDTO> reservationManagerDal)
        {
            _reservationManagerDal = reservationManagerDal;
        }

        
        //Get Single data 
        public ReservationDTO? GetOne(Guid? id)
        {
            ReservationDTO? obj = _reservationManagerDal.Get(id);
            // Reservation? obj = _reservationManagerDal.Get(id);
            return obj;
        }


        //Get All data 
        public List<ReservationDTO> GetAll()
        {
            List<ReservationDTO> obj = _reservationManagerDal.GetAll();
            return obj;
        }
        
        //GET
        [HttpPost]
        public bool Create(ReservationDTO obj)
        {
            if (_reservationManagerDal.Create(obj) == false)
            {
                return false;
            }
            
            return true;
        }
        
        
        //GET
        [HttpPost]
        public void Edit(ReservationDTO obj)
        {
            _reservationManagerDal.Edit(obj);
        }

        public bool Delete(Guid id)
        {
            //get object
            var ReservationFromDb = _reservationManagerDal.Delete(id);

            if (ReservationFromDb)
            {
                return true;
            }

            return false;
            // return RedirectToAction("Index");
        }
}