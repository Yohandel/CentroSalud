using Microsoft.AspNetCore.Mvc;

public class MedicosController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(int id)
    {
        ViewData["MedicoId"] = id;
        return View();
    }
}