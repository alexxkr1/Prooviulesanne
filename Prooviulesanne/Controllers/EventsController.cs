using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> CreateEvent([Bind("Id,EventName,StartTime,StartingPlace,Details")] Event events )
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(events);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
        
            var @event = await _context.Event
                .Include(e => e.Citizens)
                .Include(e => e.Enterprises)
                .FirstOrDefaultAsync(m => m.Id == id);

            foreach (var enterprise in @event.Enterprises)
            {
                _context.Company.Remove(enterprise);
            }
            foreach (var citizen in @event.Citizens)
            {
                _context.Employee.Remove(citizen);
            }
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
