using System.ComponentModel.DataAnnotations;

namespace KitchenRoutingManagement.Models
{
    public class kitchenlineitems
    {
        [Key]
        public string orderid { get; set; }
        public string lineitemstatus { get; set; }
        public string productname { get; set; }
        public int quantity { get; set; }
        public string producttype { get; set; }
    }
}
