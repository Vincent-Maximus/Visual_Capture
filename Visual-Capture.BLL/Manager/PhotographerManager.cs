using Microsoft.AspNetCore.Mvc;
using Visual_Capture.BLL.Entities;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.BLL.Manager;

public class PhotographerManager
{
    private readonly IDal<PhotographerDTO> _photographerDal;

        public PhotographerManager(IDal<PhotographerDTO> photographerDal)
        {
            _photographerDal = photographerDal;
        }

        
        //Get Single data 
        public PhotographerDTO? GetOne(Guid? id)
        {
            PhotographerDTO? obj = _photographerDal.Get(id);
            return obj;
        }


        //Get All data 
        public List<PhotographerDTO> GetAll()
        {
            List<PhotographerDTO> obj = _photographerDal.GetAll();
            return obj;
        }
        
        //GET
        [HttpPost]
        public void Create(PhotographerDTO obj)
        {
            _photographerDal.Create(obj);
        }

        //GET
        [HttpPost]
        public void Edit(PhotographerDTO obj)
        {
            _photographerDal.Update(obj);
        }

        public bool Delete(Guid id)
        {
            //get object
            var photographerFromDb = _photographerDal.Delete(id);

            if (photographerFromDb)
            {
                return true;
            }

            return false;
            // return RedirectToAction("Index");
        }
}