
namespace CinemaApp.Web.Controllers;

using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using CinemaApp.Web.ViewModels;
public class HomeController : Controller
{
 
    public IActionResult Index()
    {
        ViewData["Title"] = "Home Page";
        ViewData["Message"] = "Wekcome to the Cinema Web App";
        return View();
    }

}