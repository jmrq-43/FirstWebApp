using FirstWepApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWepApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly GasServicesContext _context;

        public ClientController(GasServicesContext context)
        {
            _context = context;
        }
        // GET: Employe
        public async Task<ActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

    }
}
