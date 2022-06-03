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
        private readonly IManagerDal<CategoryDTO> _category;

        public CategoryController(IManagerDal<CategoryDTO> category)
        {
            _category = category;
        }

        public IActionResult Index()
        {
            CategoryManager categoryManager = new CategoryManager(_category);

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
        [HttpPost]
        public IActionResult Create(CategoryDTO obj)
        {
            CategoryManager categoryManager = new CategoryManager(_category);
            categoryManager.Create(obj);

            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Edit(Guid id)
        {
            CategoryManager categoryManager = new CategoryManager(_category);
            
            var obj = categoryManager.GetOne(id);
            
            //quick check (just in case it got deleted at the same time 
            if (obj == null)
            {
                return NotFound();
            }
            
            //transfer object 
            var category = new Category()
            {
                Id = obj.Id,
                Name = obj.Name,
                DisplayOrder = obj.DisplayOrder,
                CreateDateTime = obj.CreateDateTime,
            };

            return View(category);
        }
        
        //GET
        [HttpPost]
        public IActionResult Edit(CategoryDTO obj)
        {
            CategoryManager categoryManager = new CategoryManager(_category);
            categoryManager.Edit(obj);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            CategoryManager categoryManager = new CategoryManager(_category);
            var categoryFromManager = categoryManager.Delete(id);

            return RedirectToAction("Index");
        }
    }
}