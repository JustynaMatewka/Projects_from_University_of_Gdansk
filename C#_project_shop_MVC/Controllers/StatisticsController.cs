using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project_shop_MVC.Data;
using project_shop_MVC.Models;
using System.Linq;

public class StatisticsController : Controller
{
    private readonly project_shop_MVC_Context _context;

    public StatisticsController(project_shop_MVC_Context context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {

        var seasonalCounts = await _context.Shoes
            .GroupBy(s => s.Season)
            .Select(g => new SeasonalCount { Season = g.Key, Count = g.Count() })
            .ToListAsync();

        var totalShoes = await _context.Shoes.CountAsync();

        var shoeGenre = new GenreViewModel
        {
            TotalShoes = totalShoes,
            SeasonalCounts = seasonalCounts,
            SeasonsQuery = new SelectList(seasonalCounts.Select(s => s.Season).Distinct().ToList())
        };

        return View(shoeGenre);
    }
}