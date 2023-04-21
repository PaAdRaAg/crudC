using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
    }
}