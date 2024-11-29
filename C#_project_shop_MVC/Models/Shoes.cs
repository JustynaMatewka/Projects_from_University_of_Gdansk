using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_shop_MVC.Models
{
    public class Shoes
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Cena musi być z zakresu od 1 do 1000.")]
        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public int Price { get; set; }

        [Required]
        [SeasonValidation(ErrorMessage = "Wartość musi zawierać jedno z czterech słów (wiosna, lato, jesień, zima) połączone bez spacji z rokiem 2023 lub 2024.")]
        [StringLength(20)]
        public string? Season { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string? Material { get; set; }

        public string? Description { get; set; }


        //Relationship - Sales

        [ForeignKey("Sales")]
        [Display(Name = "Sale id")]
        public int SaleId { get; set; }

        public Sales Sales { get; set; }    

    }
}
