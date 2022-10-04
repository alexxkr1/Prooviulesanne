using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proov.Data;
using Prooviulesanne.Models.Domain;

namespace Prooviulesanne.Controllers
{
    public class CitizensController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CitizensController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult CreateCitizen(int EventId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCitizen(int EventId, Citizen participant)
        {
            if (ModelState.IsValid)
            {
                _context.Employee.Add(participant);
                _context.SaveChanges();
                return RedirectToAction("Details", "Home", new { id = participant.EventId });
                //return RedirectToAction("Index", "Home");
            }
            return View(participant);
            
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osaleja = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (osaleja == null)
            {
                return NotFound();
            }

            return View(osaleja);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var current = _context.Employee.Find(id);
            var participant = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(participant);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Home", new { id = current.EventId });
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.Employee.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, Citizen participant)
        {
            if (id != participant.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var current = _context.Employee.Find(id);
                current.FirstName = participant.FirstName;
                current.LastName = participant.LastName;
                current.IdentificationNumber = participant.IdentificationNumber;
                current.PaymentType = participant.PaymentType;
                current.Details = participant.Details;
                current.EventId = participant.EventId;
                _context.SaveChanges();
                return RedirectToAction("Details", "Home", new { id = current.EventId });
            }
            return View(participant);
        }
    }
}
