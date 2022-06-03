using Microsoft.AspNetCore.Mvc;
using Visual_Capture.BLL.Entities;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.BLL.Manager;

public class PhotographerManager
{
    private readonly IManagerDal<PhotographerDTO> _photographerManagerDal;

        public PhotographerManager(IManagerDal<PhotographerDTO> photographerManagerDal)
        {
            _photographerManagerDal = photographerManagerDal;
        }

        
        //Get Single data 
        public PhotographerDTO? GetOne(Guid? id)
        {
            PhotographerDTO? obj = _photographerManagerDal.Get(id);
            return obj;
        }


        //Get All data 
        public List<PhotographerDTO> GetAll()
        {
            List<PhotographerDTO> obj = _photographerManagerDal.GetAll();
            return obj;
        }
        
        //GET
        [HttpPost]
        public void Create(PhotographerDTO obj)
        {
            _photographerManagerDal.Create(obj);
        }

        //GET
        [HttpPost]
        public void Edit(PhotographerDTO obj)
        {
            _photographerManagerDal.Edit(obj);
        }

        public bool Delete(Guid id)
        {
            //get object
            var photographerFromDb = _photographerManagerDal.Delete(id);

            if (photographerFromDb)
            {
                return true;
            }

            return false;
            // return RedirectToAction("Index");
        }
}