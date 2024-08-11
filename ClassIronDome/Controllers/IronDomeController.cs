using ClassIronDome.Contexts;
using ClassIronDome.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
namespace ClassIronDome.Controllers
{
    public class IronDomeController : Controller
    {
        private readonly IronDomeDbContext _context; // Holds the DB context
        private readonly ILogger<IronDomeController> _logger; // Hold logger to log stuff
        private static ConcurrentDictionary<string, CancellationTokenSource> _attack =
            new ConcurrentDictionary<string, CancellationTokenSource>(); // Hold Dictionary to hold threads and thier cancelion token
       
        public IronDomeController(IronDomeDbContext context, ILogger<IronDomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult ManagmentScreen()
        {
            List<DefenceAmmunition> defAmmo = _context.DefenceAmmunitions.ToList();
            return View(defAmmo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateManagmentScreen([FromForm] List<DefenceAmmunition> defenceAmmunitions) {
            foreach (var ammo in defenceAmmunitions)
            {
                //Find the existing record in the database
                var existingAmmo = _context.DefenceAmmunitions.Find(ammo.Id);
                if (existingAmmo != null)
                {
                    existingAmmo.Amount = ammo.Amount;
                }
                else
                {
                    TempData["ErrorMessage"] = "Data was not updated successfully";
                    return RedirectToAction("ManagmentScreen");
                }
                _context.SaveChanges();
                _logger.LogInformation("Update Ammo Succssesfully");
                TempData["SuccessMessage"] = "Data updated Succssesfully!";
            }


            return RedirectToAction("ManagmentScreen");
        }
    }
}
