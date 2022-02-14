using CalificationAppWeb.Helpers;
using CalificationAppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Text;

namespace CalificationAppWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            var sesion = HttpContext.Session.GetString("Token") as string;
            

            if (sesion != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Index(User loginDataModel)
        {
            var user = HttpContext.Session.GetString("user") as string;
            var database = HttpContext.Session.GetString("database") as string;
            ViewData["user"] = user;
            ViewData["database"] = database;
            if (ModelState.IsValid)
            {
                // AQUÍ EL CÓDIGO DE VALIDACIÓN DEL USUARIO
                //return RedirectToAction("LoginOk");
                B1Session obj = LoginHelper.LoginB(loginDataModel, "https://192.168.1.5:50000/b1s/v1/");
                if (obj != null)
                {
                    HttpContext.Session.Set("Token", Encoding.ASCII.GetBytes(obj.SessionId));
                    HttpContext.Session.Set("database", Encoding.ASCII.GetBytes(loginDataModel.CompanyDB));
                    HttpContext.Session.Set("user", Encoding.ASCII.GetBytes(loginDataModel.UserName));


                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["user"] = "";
                    ViewData["erroLogin"] = "Credenciales incorrectas";
                    return View();
                }

            }
            else
            {
                ViewData["user"] = "";
                ViewData["erroLogin"] = "Ingrese los campos obligatorios";
                return View(loginDataModel);
            }
        }

        public IActionResult Logout()
        {
            // Helpers.Logout.LogoutApp();

            HttpContext.Session.Remove("Token");
            HttpContext.Session.Remove("database");
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Login");

        }
    }
}
