using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Visual_Capture.DAL;
using Visual_Capture.DAL.Data;
using Visual_Capture.BLL.Entities;

namespace Visual_Capture.BLL.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryDal _categoryDal;

        public CategoryController(CategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public IActionResult Index()
        {
            List<Category> obj = _categoryDal.Get();
            return View(obj);
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
        [ValidateAntiForgeryToken] //auto inject valid key
        public IActionResult Create(Category obj)
        {
            //custom validation
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The displayOrder Cannot exactly match the name.");
            }

            if (ModelState.IsValid)
            {
                _categoryDal.Create(obj);
            }

            return View(obj);
        }


        //GET
        public IActionResult Edit(Guid id)
        {
            var categoryFromDb = _categoryDal.Edit(id);

            //just in case someone deleted at the same time.
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //GET
        [HttpPost]
        [ValidateAntiForgeryToken] //auto inject valid key
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The displayOrder Cannot exactly match the name.");
            }

            if (ModelState.IsValid)
            {
                _categoryDal.Edit(obj);
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(Guid id)
        {
            //get object
            var categoryFromDb = _categoryDal.Delete(id);

            return RedirectToAction("Index");
        }
    }
}