using System.ComponentModel.DataAnnotations;

namespace project_shop_MVC.Models
{
    public class Sales
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Sale in %")]
        public int SalePercent { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Sale starting date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Sale ending date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public string? Description { get; set; }


        //Relationship - Shoes
        public List<Shoes> Shoes { get; set; }
    }
}
