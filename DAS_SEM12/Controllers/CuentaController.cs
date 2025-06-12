using DAS_SEM12.Data;
using DAS_SEM12.Models;
using DAS_SEM12.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAS_SEM12.Controllers
{
    public class CuentaController : Controller
    {
        private readonly AppDBContext _appDBContext;

        public CuentaController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM) {
            Usuario? usuario_encontrado = await _appDBContext.Usuarios.Where(
                u => u.correo == loginVM.Correo && u.password == loginVM.Password).FirstOrDefaultAsync();
            if (usuario_encontrado == null) {
                ViewData["mensaje"] = "Credenciales incorrectas, intente nuevamente.";
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Registro()
        {
            ViewBag.Roles = _appDBContext.Roles.ToList();
            return View();
        }
    }
}
