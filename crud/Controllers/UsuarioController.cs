using Microsoft.AspNetCore.Mvc;
using crud.Data;

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
            if(ModelState.IsValid && usuario.Nombre is not null)
            {
                _context.CrearUsuario(usuario.Nombre, usuario.Apellido, usuario.Edad, usuario.Email);
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
            if(ModelState.IsValid && usuario.Nombre is not null && usuario.Id_Usuario > 0)
            {
                _context.ActualizarUsuario(usuario.Id_Usuario, usuario.Nombre, usuario.Apellido, usuario.Edad, usuario.Email);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Eliminar(int id)
        {
            var usuario = _context.EliminarUsuario(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Eliminar(Usuario usuario)
        {
            if(usuario.Id_Usuario > 0)
            {
                _context.EliminarUsuario(usuario.Id_Usuario);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}