using Microsoft.AspNetCore.Mvc;

public class EmpleadosController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(int id)
    {
        ViewData["EmpleadoId"] = id;
        return View();
    }
}