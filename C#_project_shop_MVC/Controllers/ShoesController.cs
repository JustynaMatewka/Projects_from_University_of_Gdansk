using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project_shop_MVC.Data;
using project_shop_MVC.Models;

namespace project_shop_MVC.Controllers
{
    public class ShoesController : Controller
    {
        private readonly project_shop_MVC_Context _context;

        public ShoesController(project_shop_MVC_Context context)
        {
            _context = context;
        }

        // GET: Shoes
        public async Task<IActionResult> Index(string shoeMaterial, string searchString, decimal? minPrice, decimal? maxPrice, bool? searchSale)
        {
            if (_context.Shoes == null)
            {
                return Problem("Entity set 'project_shop_MVC.Shoes' is null.");
            }

            IQueryable<string> genreQuery = from m in _context.Shoes
                                            orderby m.Material
                                            select m.Material;

            var shoes = from m in _context.Shoes.Include(s => s.Sales)
                        select m;

            var totalShoes = await _context.Shoes.CountAsync();


            if (!string.IsNullOrEmpty(searchString))
            {
                shoes = shoes.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(shoeMaterial))
            {
                shoes = shoes.Where(x => x.Material == shoeMaterial);
            }

            if (minPrice.HasValue && maxPrice.HasValue && maxPrice >= minPrice)
            {
                shoes = shoes.Where(x => x.Price >= minPrice && x.Price <= maxPrice);
            }

            if (searchSale.HasValue && searchSale.Value)
            {
                shoes = shoes.Where(x => x.SaleId != 1);
            }

            var shoeGenre = new GenreViewModel
            {
                Materials = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Shoe = await shoes.ToListAsync(),
                MinPrice = minPrice ?? 0,
                MaxPrice = maxPrice ?? 1000,
                SearchSale = searchSale.HasValue && searchSale.Value,
                TotalShoes = totalShoes
            };

            return View(shoeGenre);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Shoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoes = await _context.Shoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoes == null)
            {
                return NotFound();
            }

            return View(shoes);
        }

        // GET: Shoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SaleId,Name,Price,Season,Material,Description")] Shoes shoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoes);
        }

        // GET: Shoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoes = await _context.Shoes.FindAsync(id);
            if (shoes == null)
            {
                return NotFound();
            }
            return View(shoes);
        }

        // POST: Shoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SaleId,Name,Price,Season,Material,Description")] Shoes shoes)
        {
            if (id != shoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoesExists(shoes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shoes);
        }

        // GET: Shoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoes = await _context.Shoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoes == null)
            {
                return NotFound();
            }

            return View(shoes);
        }

        // POST: Shoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoes = await _context.Shoes.FindAsync(id);
            if (shoes != null)
            {
                _context.Shoes.Remove(shoes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoesExists(int id)
        {
            return _context.Shoes.Any(e => e.Id == id);
        }
    }
}
