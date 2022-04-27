using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sorveteria.Models;

namespace Sorveteria.Controllers
{
    public class ClienteController : Controller
    {
        private readonly Sorveteria.Data.AppCont _appCont;

        public ClienteController(Sorveteria.Data.AppCont appCont)
        {
            _appCont = appCont;
        }

        public async Task<IActionResult> Index()
        {
            var todosClientes = await _appCont.Clientes.ToListAsync();
            return View(todosClientes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            _appCont.Clientes.Add(cliente);
            _appCont.SaveChanges();
            return RedirectToAction("Index");
        }

        //criar edit

        //criar details

        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = await _appCont.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return BadRequest();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var cliente = await _appCont.Clientes.FindAsync(id);
            _appCont.Clientes.Remove(cliente);
            await _appCont.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
