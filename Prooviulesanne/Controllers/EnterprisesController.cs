using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proov.Data;
using Prooviulesanne.Models.Domain;

namespace Prooviulesanne.Controllers
{
    public class EnterprisesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EnterprisesController(ApplicationDbContext context)
        {
            _context = context;
        }
   
        public ActionResult Index([Bind(Prefix = "id")] int EventId)
        {
            var model = _context.Event
                .Include(e => e.Enterprises)
                .FirstOrDefault(r => r.Id == EventId);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }





        [HttpGet]
        public ActionResult Create(int EventId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(int EventId, Enterprise participant)
        {
            if (ModelState.IsValid)
            {
                _context.Company.Add(participant);
                _context.SaveChanges();
                return RedirectToAction("Index", "Enterprises", new { id = participant.EventId });
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

            var osaleja = await _context.Company
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
            var current = _context.Company.Find(id);
            var participant = await _context.Company.FindAsync(id);
            _context.Company.Remove(participant);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Home", new { id = current.EventId });
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.Company.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, Enterprise participant)
        {
            if (id != participant.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var current = _context.Company.Find(id);
                current.EnterpriseName = participant.EnterpriseName;
                current.BusinessIdentificationNumber = participant.BusinessIdentificationNumber;
                current.AttendanceNumber = participant.AttendanceNumber;
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
