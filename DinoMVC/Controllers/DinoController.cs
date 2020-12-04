using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DinoMVC.Controllers
{
    public class DinoController : Controller
    {
        private readonly DinoDbContext _db;
        
        [BindProperty]
        public Dino Dino { get; set; }
        
        public DinoController(DinoDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewDino(int id)
        {
            Dino = _db.Dino.FirstOrDefault(d => d.Id == id);
            if (Dino == null)
            {
                return NotFound();
            }
            return View(Dino);
        }

        public IActionResult Upsert(int? id)
        {
            Dino = new Dino();
            if (id == null)
            {
                return View(Dino);
            }
            Dino = _db.Dino.FirstOrDefault(d => d.Id == id);
            if (Dino == null)
            {
                return NotFound();
            }
            return View(Dino);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            //Dino = new Dino();
            if (ModelState.IsValid)
            {
                if (Dino.Id == 0)
                {
                    _db.Dino.Add(Dino);
                }
                else
                {
                    _db.Dino.Update(Dino);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Dino);
        }
        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Dino.ToListAsync() });
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var D = await _db.Dino.FirstOrDefaultAsync(d => d.Id == id);
            if (D != null)
            {
                return Json(new { data = await _db.Dino.FirstOrDefaultAsync(d => d.Id == id)});
            }
            return Json(new { success = false, message = "Error getting Dino with id: "+id });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var D = await _db.Dino.FirstOrDefaultAsync(d => d.Id == id);
            if (D != null)
            {
                _db.Dino.Remove(D);
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "Delete successful" });
            }
            return Json(new { success = false, message = "Error while Deleting" });
        }
        #endregion

    }
}
