using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Visual_Capture.BLL.Entities;
using Visual_Capture.BLL.Manager;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.UI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IManagerDal<ReservationDTO> _Reservation;
        private readonly IManagerDal<PhotographerDTO> _Photographer;
        private readonly IManagerDal<CustomerDTO> _Customer;

        private readonly IManagerDal<ReservationPhotographerDTO> _ReservationPhotographer;

        public ReservationController(IManagerDal<ReservationDTO> Reservation, IManagerDal<CustomerDTO> Customer,
            IManagerDal<PhotographerDTO> Photographer, IManagerDal<ReservationPhotographerDTO> ReservationPhotographer)
        {
            _Reservation = Reservation;
            _Customer = Customer;
            _Photographer = Photographer;
            _ReservationPhotographer = ReservationPhotographer;
        }

        public IActionResult Index()
        {
            ReservationManager ReservationManager = new ReservationManager(_Reservation);

            var Reservations = ReservationManager.GetAll().Select(Reservation => new Reservation()
            {
                Id = Reservation.Id,
                CustomerId = Reservation.CustomerId,
                DateTime = Reservation.DateTime,
                AmountPeople = Reservation.AmountPeople,
                TypeReservationId = Reservation.TypeReservationId,
            }).ToList();

            return View(Reservations);
        }

        //GET
        public IActionResult Create()
        {
            var _customer = new Reservation();

            CustomerManager customerManager = new CustomerManager(_Customer);

            _customer.Customers = customerManager.GetAll().Select(customer => new Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
            }).ToList();

            return View(_customer);
        }


        //GET
        [HttpPost]
        public IActionResult Create(ReservationDTO obj)
        {
            ReservationManager ReservationManager = new ReservationManager(_Reservation);
            ReservationManager.Create(obj);

            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Edit(Guid id)
        {
            ReservationManager ReservationManager = new ReservationManager(_Reservation);
            CustomerManager customerManager = new CustomerManager(_Customer);
            var _customer = new Reservation();

            var obj = ReservationManager.GetOne(id);

            //quick check (just in case it got deleted at the same time 
            if (obj == null)
            {
                return NotFound();
            }

            _customer.Customers = customerManager.GetAll().Select(customer => new Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
            }).ToList();

            //transfer object 
            var Reservation = new Reservation()
            {
                Id = obj.Id,
                CustomerId = obj.CustomerId,
                DateTime = obj.DateTime,
                AmountPeople = obj.AmountPeople,
                // PhotographerId = obj.PhotographerId,
                TypeReservationId = obj.TypeReservationId,
            };
            ViewBag.customers = _customer.Customers;

            return View(Reservation);
        }

        //GET
        [HttpPost]
        public IActionResult Edit(ReservationDTO obj)
        {
            ReservationManager ReservationManager = new ReservationManager(_Reservation);
            ReservationManager.Edit(obj);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            ReservationManager ReservationManager = new ReservationManager(_Reservation);
            ReservationManager.Delete(id);

            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Photographers(Guid id)
        {
            ReservationManager ReservationManager = new ReservationManager(_Reservation);
            PhotographerManager PhotographerManager = new PhotographerManager(_Photographer);
            ReservationPhotographerManager ReservationPhotographerManager = new ReservationPhotographerManager(_ReservationPhotographer);

            var obj = ReservationManager.GetOne(id);

            var Photographer = PhotographerManager.GetAll().Select(Photographer => new Photographer()
            {
                Id = Photographer.Id,
                Name = Photographer.Name,
            }).ToList();

            var ReservationPhotographer = ReservationPhotographerManager.GetAll().Select(ReservationPhotographer =>
                new ReservationPhotographer()
                {
                    PhotographerId = ReservationPhotographer.PhotographerId,
                    ReservationsId = ReservationPhotographer.ReservationId,
                }).ToList();


            List<Photographer> Photographers;
            
            // Create a list of photographer.
            List<Photographer> photographers = new List<Photographer>();


            foreach (var reservationPhotographer in ReservationPhotographer)
            {
                if (id == reservationPhotographer.ReservationsId)
                {
                    foreach (var photographer in Photographer)
                    {
                        if (photographer.Id == reservationPhotographer.PhotographerId)
                        {
                            photographers.Add(new Photographer() {Id = photographer.Id, Name = photographer.Name});
                        }
                    }
                }
            }

            //transfer object 
            var ReservationPhotographerView = new ReservationPhotographerView(photographers)
            {
                CustomerId = obj.CustomerId,
                DateTime = obj.DateTime,
                AmountPeople = obj.AmountPeople,
                TypeReservationId = obj.TypeReservationId,
            };

            return View(ReservationPhotographerView);
        }
    }
}