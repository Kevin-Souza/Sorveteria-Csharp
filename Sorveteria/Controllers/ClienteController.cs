using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sorveteria.Controllers
{
    public class ClienteController : Controller
    {
        private readonly Sorveteria.Data.AppCont _appCont;

        public ClienteController(Sorveteria.Data.AppCont appCont)
        {
            _appCont = appCont;
        }

        public async Task <IActionResult> Index()
        {
            var todosClientes = await _appCont.Clientes.ToListAsync();
            return View(todosClientes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
