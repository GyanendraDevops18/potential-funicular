using System;
using System.ComponentModel.DataAnnotations;

namespace KitchenRoutingManagement.Models
{
    public class orderlineitemstatus
    {
        [Key]
        [Required(ErrorMessage = "{0} is required")]
        public string orderlineitemid { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ordercheckincode { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string productname { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int quantity { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string producttype { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string lineitemstatus { get; set; }
    }
}
