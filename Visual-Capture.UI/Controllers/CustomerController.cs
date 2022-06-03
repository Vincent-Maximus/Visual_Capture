using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Visual_Capture.BLL.Entities;
using Visual_Capture.BLL.Manager;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IManagerDal<CustomerDTO> _customer;

        public CustomerController(IManagerDal<CustomerDTO> customer)
        {
            _customer = customer;
        }

        public IActionResult Index()
        {
            CustomerManager customerManager = new CustomerManager(_customer);

            var customers = customerManager.GetAll().Select(customer => new Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
            }).ToList();

            return View(customers);
        }


        //GET
        public IActionResult Create()
        {
            return View();
        }
        //GET
        [HttpPost]
        public IActionResult Create(CustomerDTO obj)
        {
            CustomerManager customerManager = new CustomerManager(_customer);
            customerManager.Create(obj);

            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Edit(Guid id)
        {
            CustomerManager customerManager = new CustomerManager(_customer);
            
            var obj = customerManager.GetOne(id);
            
            //quick check (just in case it got deleted at the same time 
            if (obj == null)
            {
                return NotFound();
            }
            
            //transfer object 
            var customer = new Customer()
            {
                Id = obj.Id,
                Name = obj.Name,
                Email = obj.Email,
                PhoneNumber = obj.PhoneNumber,
            };

            return View(customer);
        }
        
        //GET
        [HttpPost]
        public IActionResult Edit(CustomerDTO obj)
        {
            CustomerManager customerManager = new CustomerManager(_customer);
            customerManager.Edit(obj);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            CustomerManager customerManager = new CustomerManager(_customer);
            customerManager.Delete(id);

            return RedirectToAction("Index");
        }
    }
}