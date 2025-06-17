using Microsoft.AspNetCore.Mvc;
using DAS_SEM12.Data;
using DAS_SEM12.Models;
using Microsoft.EntityFrameworkCore;
using DAS_SEM12.ViewModels;

namespace DAS_SEM12.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public UsuarioController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> Mostrar()
        {
            List<Usuario> usuarios = await _appDBContext.Usuarios
                .Include(u => u.rol)
                .ToListAsync();
            return View(usuarios);
        }

        [HttpGet]
        public async Task<IActionResult> Nuevo() {
            ViewBag.Roles = _appDBContext.Roles.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(RegistroVM model)
        {
            var usuario = new Usuario
            {
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                correo = model.Correo,
                password = model.Password,
                idRol = model.idRol
            };

            await _appDBContext.Usuarios.AddAsync(usuario);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Mostrar));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Usuario? usuario = await _appDBContext.Usuarios.FindAsync(id);
            ViewBag.Roles = _appDBContext.Roles.ToList();
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            _appDBContext.Usuarios.Update(usuario);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Mostrar));
        }
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var idUsuario = _appDBContext.Usuarios.Find(id);
            return View(idUsuario);
        }
        [HttpPost]
        public IActionResult ConfirmacionEliminar(int id)
        {
            var usuario = _appDBContext.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _appDBContext.Usuarios.Remove(usuario);
            _appDBContext.SaveChanges();

            return RedirectToAction(nameof(Mostrar));
        }
    }
}
