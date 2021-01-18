using System.ComponentModel.DataAnnotations;

namespace KitchenRoutingManagement.Models
{
    public class cartlineitemdetails
    {
        [Key]
        public string orderid { get; set; }
        public string ordercheckincode { get; set; }
        public string productname { get; set; }
        public int? quantity { get; set; }
        public decimal? price { get; set; }
        public decimal? totalsum { get; set; }
        public decimal? totalPrice { get; set; }        
        public string producttype { get; set; }
        public string lineitemstatus { get; set; }
    }
}
