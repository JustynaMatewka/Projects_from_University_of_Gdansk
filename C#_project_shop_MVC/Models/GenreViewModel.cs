using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace project_shop_MVC.Models
{
    public class SeasonalCount
    {
        public string Season { get; set; }
        public int Count { get; set; }
    }

    public class GenreViewModel
    {
        public List<Shoes>? Shoe { get; set; }
        //public List<Sales>? Sale { get; set; }
        public SelectList? Materials { get; set; }
        public string? ShoeMaterial { get; set; }
        public string? SearchString { get; set; }
        public decimal MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool SearchSale { get; set; }

        [Display(Name = "Sale description")]
        public string? SaleDescription { get; set; }

        public int TotalShoes { get; set; }
        public int TotalSales { get; set; }
        public SelectList? SeasonsQuery { get; set; }
        public List<SeasonalCount> SeasonalCounts { get; set; }


        /*public int TotalShoesSpring { get; set; }
        public int TotalShoesSummer { get; set; }
        public int TotalShoesAutumn { get; set; }
        public int TotalShoesWinter { get; set; }
*/

    }
}
