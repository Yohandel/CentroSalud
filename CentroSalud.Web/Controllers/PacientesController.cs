using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentroSalud.Web.Controllers
{
    public class PacientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewData["PacienteId"] = id;
            return View();
        }

    }
}
