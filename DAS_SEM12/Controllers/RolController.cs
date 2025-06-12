using Microsoft.AspNetCore.Mvc;
using DAS_SEM12.Models;
using DAS_SEM12.Data;

namespace DAS_SEM12.Controllers
{
    public class RolController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public RolController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Roles = _appDBContext.Roles.ToList();
            return View(Roles);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Rol rol) { 
            _appDBContext?.Roles.Add(rol);
            _appDBContext?.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var Id = _appDBContext.Roles.Find(id);
            return View(Id);
        }
        [HttpPost]
        public IActionResult Editar(Rol rol) { 
            _appDBContext.Roles.Update(rol);
            _appDBContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Eliminar(int id) {
            var rolId = _appDBContext.Roles.Find(id);
            return View(rolId);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmacionEliminar(int id) { 
            var rol =  _appDBContext.Roles.Find(id);
                _appDBContext.Roles.Remove(rol);
                await _appDBContext.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
    }
}
