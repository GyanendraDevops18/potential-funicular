using System;
using System.ComponentModel.DataAnnotations;

namespace KitchenRoutingManagement.Models
{
    public class MenuItem
    {
        [Key]
        public string productid { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string code { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string imagesrc { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string imagealt { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string type { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int qty { get; set; }
        public DateTime createddate { get; set; }
    }
}