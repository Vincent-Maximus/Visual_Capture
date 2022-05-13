using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Visual_Capture.BLL.Entities;
using Visual_Capture.BLL.Manager;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IDal<CategoryDTO> _category;

        public CategoryController(IDal<CategoryDTO> category)
        {
            _category = category;
        }

        public IActionResult Index()
        {
            CategoryManager categoryManager = new CategoryManager(_category);
            // List<Category> obj = categoryManager.GetAll();
           var categories = categoryManager.GetAll().Select(category => new Category()
            {
                Id = category.Id,
                Name = category.Name,
                DisplayOrder = category.DisplayOrder,
                CreateDateTime = category.CreateDateTime,
            }).ToList();

            return View(categories);
            // return View(_categoryDal.GetCategories());
            // IEnumerable<Category> objCategoryList = _db.Categories;
            // return View(objCategoryList);
        }


        //GET
        public IActionResult Create()
        {
            return View();
        }

        //GET
        public IActionResult Edit(Guid id)
        {
            // var categoryFromDb = _categoryDal.Edit(id);
            //
            // //just in case someone deleted at the same time.
            // if (categoryFromDb == null)
            // {
            //     return NotFound();
            // }

            // return View(categoryFromDb);
            return View();
        }
        
        public IActionResult Delete(Guid id)
        {
            //get object
            // var categoryFromDb = _categoryDal.Delete(id);
            //
            return RedirectToAction("Index");
        }
    }
}