using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Visual_Capture.BLL.Entities;
using Visual_Capture.BLL.Manager;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.UI.Controllers
{
    public class TypeReservationController : Controller
    {
        private readonly IManagerDal<TypeReservationDTO> _typeReservation;

        public TypeReservationController(IManagerDal<TypeReservationDTO> typeReservation)
        {
            _typeReservation = typeReservation;
        }

        public IActionResult Index()
        {
            TypeReservationManager typeReservationManager = new TypeReservationManager(_typeReservation);

            var typeReservations = typeReservationManager.GetAll().Select(typeReservation => new TypeReservation()
            {
                Id = typeReservation.Id,
                Name = typeReservation.Name,
                Price = typeReservation.Price,
                MinPeople = typeReservation.MinPeople,
            }).ToList();

            return View(typeReservations);
        }


        //GET
        public IActionResult Create()
        {
            return View();
        }
        //GET
        [HttpPost]
        public IActionResult Create(TypeReservationDTO obj)
        {
            TypeReservationManager typeReservationManager = new TypeReservationManager(_typeReservation);
            typeReservationManager.Create(obj);

            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Edit(Guid id)
        {
            TypeReservationManager typeReservationManager = new TypeReservationManager(_typeReservation);
            
            var obj = typeReservationManager.GetOne(id);
            
            //quick check (just in case it got deleted at the same time 
            if (obj == null)
            {
                return NotFound();
            }
            
            //transfer object 
            var typeReservation = new TypeReservation()
            {
                Id = obj.Id,
                Name = obj.Name,
                Price = obj.Price,
                MinPeople = obj.MinPeople,
            };

            return View(typeReservation);
        }
        
        //GET
        [HttpPost]
        public IActionResult Edit(TypeReservationDTO obj)
        {
            TypeReservationManager typeReservationManager = new TypeReservationManager(_typeReservation);
            typeReservationManager.Edit(obj);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            TypeReservationManager typeReservationManager = new TypeReservationManager(_typeReservation);
            typeReservationManager.Delete(id);

            return RedirectToAction("Index");
        }
    }
}