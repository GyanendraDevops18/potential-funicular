using System.ComponentModel.DataAnnotations;

namespace KitchenRoutingManagement.Models
{
    public class orderstatus
    {
        [Key]
        [Required(ErrorMessage = "{0} is required")]
        public string orderid { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ordercheckincode { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string status { get; set; }
    }
}
