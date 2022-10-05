using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proov.Data;
using Prooviulesanne.Models;
using System.Diagnostics;

namespace Prooviulesanne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Event.ToListAsync());
        }

        public ActionResult Details([Bind(Prefix = "id")] int EventId)
        {
            var model = _context.Event
                .Include(e => e.Enterprises)
                .Include(e => e.Citizens)
                .FirstOrDefault(r => r.Id == EventId);
            if (model == null)
            {
                return NotFound();

            }
            return View(model);
        }

        public ActionResult DetailsPast([Bind(Prefix = "id")] int EventId)
        {
            var model = _context.Event
                .Include(e => e.Enterprises)
                .Include(e => e.Citizens)
                .FirstOrDefault(r => r.Id == EventId);
            if (model == null)
            {
                return NotFound();

            }
            return View(model);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}