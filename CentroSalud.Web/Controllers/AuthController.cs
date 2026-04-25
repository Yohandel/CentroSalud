using Microsoft.AspNetCore.Mvc;

public class AuthController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string usuario, string password)
    {


        // 🔥 LOGIN FAKE
        if (!string.IsNullOrEmpty(usuario) && password == "admin1234" && usuario == "admin")
        {
            return RedirectToAction("Index", "Dashboard");
        }

        ViewBag.Error = "Credenciales inválidas";
        return View();
    }
}