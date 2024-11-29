using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_shop_MVC.Data;
using project_shop_MVC.Models;
using System.Threading.Tasks;

namespace project_shop_MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly project_shop_MVC_Context _context;

        public ContactController(project_shop_MVC_Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Pobierz liczbę artykułów w sklepie
            var totalShoes = await _context.Shoes.CountAsync();

            // Przygotuj dane do widoku
            var model = new GenreViewModel
            {
                TotalShoes = totalShoes
            };

            return View(model);
        }
    }
}