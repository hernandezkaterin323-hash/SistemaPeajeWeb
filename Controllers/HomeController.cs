using Microsoft.AspNetCore.Mvc;

namespace SistemaPeajeWeb.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
