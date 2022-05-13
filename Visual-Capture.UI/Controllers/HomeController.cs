using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
// using Visual_Capture.BLL.Controllers;
using Visual_Capture.BLL.Entities;


namespace Visual_Capture.UI.Controllers;

public class HomeController : Controller
{
    // private readonly HomeBusiness _homeBLLl;

    // public HomeController(HomeBusiness homeBLLl)
    // {
    //     _homeBLLl = _homeBLLl;
    // }

    // public IActionResult Index()
    // {  
    //       return View();
    // }
    
    // GET
    public IActionResult Index()
    {
        ViewData["name"] = "test";
        return View();
    }
    
    
    //GET
    [HttpPost]
    [ValidateAntiForgeryToken] //auto inject valid key
    public IActionResult Create(Reservation obj)
    {
        
        //validate form
        if (ModelState.IsValid)
        {
            // _homeDal.Create(obj);
            return View("Book");
        }
    
        return View("Index");
        // return View(obj);
    }
    
    // [HttpPost]
    // public IActionResult Create(ReservationPossibilitiesDTO model)
    // {
    //     //  check model.EmployeeId 
    //     //  to do : Save and redirect 
    // }

    public IActionResult Book()
    {
        return View();
    }
    public IActionResult Reservations()
    {
        // return View(_homeDal.GetReservations());
        return View();
    }
}