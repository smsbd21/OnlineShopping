using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Areas.Admin
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        ApplicationDbContext db;
        public ProductTypesController(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View(db.ProductTypes.ToList());
        }
        //Create Get Action Method
        public ActionResult Create()
        {
            return View();
        }
        //Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if(ModelState.IsValid)
            {
                db.ProductTypes.Add(productTypes);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }
    }
}
