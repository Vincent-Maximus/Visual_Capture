using Microsoft.AspNetCore.Mvc;
using Visual_Capture.BLL.Entities;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.BLL.Manager;

public class TypeReservationManager
{
    private readonly IManagerDal<TypeReservationDTO> _typeReservationManagerDal;

        public TypeReservationManager(IManagerDal<TypeReservationDTO> typeReservationManagerDal)
        {
            _typeReservationManagerDal = typeReservationManagerDal;
        }

        
        //Get Single data 
        public TypeReservationDTO? GetOne(Guid? id)
        {
            TypeReservationDTO? obj = _typeReservationManagerDal.Get(id);
            return obj;
        }


        //Get All data 
        public List<TypeReservationDTO> GetAll()
        {
            List<TypeReservationDTO> obj = _typeReservationManagerDal.GetAll();
            return obj;
        }
        
        //GET
        [HttpPost]
        public void Create(TypeReservationDTO obj)
        {
            _typeReservationManagerDal.Create(obj);
        }

        //GET
        [HttpPost]
        public void Edit(TypeReservationDTO obj)
        {
            _typeReservationManagerDal.Edit(obj);
        }

        public bool Delete(Guid id)
        {
            //get object
            var typeReservationFromDb = _typeReservationManagerDal.Delete(id);

            if (typeReservationFromDb)
            {
                return true;
            }

            return false;
            // return RedirectToAction("Index");
        }
}