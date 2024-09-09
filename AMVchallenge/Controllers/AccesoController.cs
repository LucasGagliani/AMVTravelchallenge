using AMVchallenge.Models;
using AMVchallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AMVchallenge.Filters;
using AMVchallenge.Permisos;


namespace AMVchallenge.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly LoginService _loginService;

        public UsuarioController()
        {
            _loginService = new LoginService();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (_loginService.Authenticate(username, password))
            {
                HttpContext.Session.SetString("Usuario", username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Usuario o contraseña incorrectos.";
                return View();
            }
        }

        [HttpGet]
        [ValidarSession]
        public IActionResult Index()
        {
            return View();
        }
    }
}