using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Visual_Capture.BLL.Entities;
using Visual_Capture.BLL.Manager;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.UI.Controllers
{
    public class PhotographerController : Controller
    {
        private readonly IManagerDal<PhotographerDTO> _photographer;

        public PhotographerController(IManagerDal<PhotographerDTO> photographer)
        {
            _photographer = photographer;
        }

        public IActionResult Index()
        {
            PhotographerManager photographerManager = new PhotographerManager(_photographer);

            var photographers = photographerManager.GetAll().Select(photographer => new Photographer()
            {
                Id = photographer.Id,
                Name = photographer.Name,
            }).ToList();

            return View(photographers);
        }


        //GET
        public IActionResult Create()
        {
            return View();
        }
        //GET
        [HttpPost]
        public IActionResult Create(PhotographerDTO obj)
        {
            PhotographerManager photographerManager = new PhotographerManager(_photographer);
            photographerManager.Create(obj);

            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Edit(Guid id)
        {
            PhotographerManager photographerManager = new PhotographerManager(_photographer);
            
            var obj = photographerManager.GetOne(id);
            
            //quick check (just in case it got deleted at the same time 
            if (obj == null)
            {
                return NotFound();
            }
            
            //transfer object 
            var photographer = new Photographer()
            {
                Id = obj.Id,
                Name = obj.Name,
            };

            return View(photographer);
        }
        
        //GET
        [HttpPost]
        public IActionResult Edit(PhotographerDTO obj)
        {
            PhotographerManager photographerManager = new PhotographerManager(_photographer);
            photographerManager.Edit(obj);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            PhotographerManager photographerManager = new PhotographerManager(_photographer);
            photographerManager.Delete(id);

            return RedirectToAction("Index");
        }
    }
}