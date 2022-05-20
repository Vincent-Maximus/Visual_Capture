using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
// using Visual_Capture.BLL.Controllers;
using Visual_Capture.BLL.Entities;


namespace Visual_Capture.UI.Controllers;

public class ContentManagementSystemController : Controller
{
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
}