using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Web;
using DinoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DinoMVC.Controllers
{
    public class DinoGameController : Controller
    {
        private readonly DinoDbContext _db;

        [BindProperty]
        public Dino Dino { get; set; }
        public List<Dino> Dinos { get; set; }

        public DinoGameController(DinoDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //Dino = _db.Dino.FirstOrDefault(d => d.Id == 1);
            Dinos = _db.Dino.ToList();
            
            return View(Dinos);
        }
        public JsonResult GetAllDino()
        {
            Dinos = _db.Dino.ToList();
            return Json(Dinos);
        }
    }
}
