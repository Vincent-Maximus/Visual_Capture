using Microsoft.AspNetCore.Mvc;
using Visual_Capture.BLL.Entities;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.BLL.Manager;

public class ReservationPhotographerManager
{
    private readonly IManagerDal<ReservationPhotographerDTO> _reservationphotographerManagerDal;

        public ReservationPhotographerManager(IManagerDal<ReservationPhotographerDTO> reservationphotographerManagerDal)
        {
            _reservationphotographerManagerDal = reservationphotographerManagerDal;
        }

        
        //Get Single data 
        public ReservationPhotographerDTO? GetOne(Guid? id)
        {
            ReservationPhotographerDTO? obj = _reservationphotographerManagerDal.Get(id);
            return obj;
            
        }


        //Get All data 
        public List<ReservationPhotographerDTO> GetAll()
        {
            List<ReservationPhotographerDTO> obj = _reservationphotographerManagerDal.GetAll();
            return obj;
        }
        
        //GET
        [HttpPost]
        public void Create(ReservationPhotographerDTO obj)
        {
            _reservationphotographerManagerDal.Create(obj);
        }
        
        
        //GET
        [HttpPost]
        public void Edit(ReservationPhotographerDTO obj)
        {
            _reservationphotographerManagerDal.Edit(obj);
        }

        public bool Delete(Guid id)
        {
            //get object
            var ReservationPhotographerFromDb = _reservationphotographerManagerDal.Delete(id);

            if (ReservationPhotographerFromDb)
            {
                return true;
            }

            return false;
            // return RedirectToAction("Index");
        }
}