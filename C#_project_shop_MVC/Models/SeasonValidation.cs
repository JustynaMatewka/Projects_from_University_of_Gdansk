using System;
using System.ComponentModel.DataAnnotations;

namespace project_shop_MVC.Models
{
    public class SeasonValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                string seazonValue = value.ToString().ToLower();
                string[] allowedSeazons = { "spring2023", "summer2023", "fall2023", "winter2023", "spring2024", "summer2024", "fall2024", "winter2024" };

                return allowedSeazons.Contains(seazonValue);
            }

            return false;
        }
    }
}
