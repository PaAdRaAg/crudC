using Microsoft.AspNetCore.Mvc;
using crud.Data;
using crud.Models;

namespace crud.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DbCon _context;

        public UsuarioController(DbCon con)
        {
            _context = con;
        }

        public IActionResult Index()
        {
            var usuarios = _context.ObtenerUsuarios().ToList();
            return View(usuarios);
        }
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid && usuario.Nombre is not null && usuario.Apellido is not null && usuario.Email is not null)
            {
                _context.CrearUsuario(usuario.Nombre, usuario.Apellido,  usuario.Email, usuario.Edad);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Actualizar(int id)
        {
            var usuario = _context.ObtenerUsuario(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Actualizar(Usuario usuario)
        {
            if (ModelState.IsValid && usuario.Nombre is not null && usuario.Apellido is not null && usuario.Email is not null && usuario.Id_Usuario > 0)
            {
                _context.ActualizarUsuario(usuario.Id_Usuario, usuario.Nombre, usuario.Apellido, usuario.Email, usuario.Edad);
                return RedirectToAction("Index");
            }
            return View();
        }

        public void EliminarUsuario(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id_Usuario == id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        public IActionResult Eliminar(int id)
        {
            _context.EliminarUsuario(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(Usuario usuario)
        {
            if (usuario.Id_Usuario > 0)
            {
                _context.EliminarUsuario(usuario.Id_Usuario);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}