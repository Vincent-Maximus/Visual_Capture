using Microsoft.AspNetCore.Mvc;
using Visual_Capture.BLL.Entities;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.BLL.Manager;

public class CategoryManager
{
    private readonly IManagerDal<CategoryDTO> _categoryManagerDal;

        public CategoryManager(IManagerDal<CategoryDTO> categoryManagerDal)
        {
            _categoryManagerDal = categoryManagerDal;
        }

        
        //Get Single data 
        public CategoryDTO? GetOne(Guid? id)
        {
            CategoryDTO? obj = _categoryManagerDal.Get(id);
            return obj;
        }


        //Get All data 
        public List<CategoryDTO> GetAll()
        {
            List<CategoryDTO> obj = _categoryManagerDal.GetAll();
            return obj;
        }
        
        //GET
        [HttpPost]
        public void Create(CategoryDTO obj)
        {
            _categoryManagerDal.Create(obj);
        }

        //GET
        [HttpPost]
        public void Edit(CategoryDTO obj)
        {
            _categoryManagerDal.Edit(obj);
        }

        public bool Delete(Guid id)
        {
            //get object
            var categoryFromDb = _categoryManagerDal.Delete(id);

            if (categoryFromDb)
            {
                return true;
            }

            return false;
            // return RedirectToAction("Index");
        }
}