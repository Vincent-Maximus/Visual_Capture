using Microsoft.AspNetCore.Mvc;
using Visual_Capture.BLL.Entities;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.BLL.Manager;

public class CategoryManager
{
    private readonly IDal<CategoryDTO> _categoryDal;

        public CategoryManager(IDal<CategoryDTO> categoryDal)
        {
            _categoryDal = categoryDal;
        }

        
        //Get Single data 
        public CategoryDTO? GetOne(Guid? id)
        {
            CategoryDTO? obj = _categoryDal.Get(id);
            return obj;
        }


        //Get All data 
        public List<CategoryDTO> GetAll()
        {
            List<CategoryDTO> obj = _categoryDal.GetAll();
            return obj;
        }
        
        //GET
        [HttpPost]
        public void Create(CategoryDTO obj)
        {
            _categoryDal.Create(obj);
        }


        // //GET
        // public IActionResult Edit(Guid id)
        // {
        //     var categoryFromDb = _categoryDal.Edit(id);
        //
        //     //just in case someone deleted at the same time.
        //     if (categoryFromDb == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return View(categoryFromDb);
        // }

        //GET
        [HttpPost]
        public void Edit(CategoryDTO obj)
        { 
            _categoryDal.Update(obj);
            
            // if (obj.Name == obj.DisplayOrder.ToString())
            // {
            //     ModelState.AddModelError("name", "The displayOrder Cannot exactly match the name.");
            // }
            //
            // if (ModelState.IsValid)
            // {
            
            //     return RedirectToAction("Index");
            // }
        }

        public void Delete(Guid id)
        {
            //get object
            var categoryFromDb = _categoryDal.Delete(id);

            // return RedirectToAction("Index");
        }
}