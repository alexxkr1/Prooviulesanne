using Microsoft.AspNetCore.Mvc;
using Proov.Data;
using Prooviulesanne.Models.Domain;

namespace Prooviulesanne.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateEvent()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEvent([Bind("Id,EventName,StartTime,StartingPlace,Details")] Event events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(events);
        }
    }
}
