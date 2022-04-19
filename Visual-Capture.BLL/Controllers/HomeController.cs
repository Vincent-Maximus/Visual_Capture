using Microsoft.AspNetCore.Mvc;
using Visual_Capture.DAL.Data;
using Visual_Capture.BLL.Entities;


namespace Visual_Capture.BLL.Controllers;

public class HomeBusiness
{
    private readonly HomeDal _homeDal;

    public HomeBusiness(HomeDal homeDal)
    {
        _homeDal = homeDal;
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

    // public IActionResult Book()
    // {
    //     return View();
    // }
    public IActionResult GetReservations()
    {
        return _homeDal.GetReservations();
    }
}