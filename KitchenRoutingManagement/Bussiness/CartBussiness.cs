using KitchenRoutingManagement.DataProvider.CartService;
using KitchenRoutingManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.Bussiness
{
    internal class CartBussiness : ICartBussiness
    {
        private readonly Icart Icart;
        private readonly orderstatus orderstatus;
        private readonly orderlineitemstatus orderlineitemstatus;
        public CartBussiness(Icart _Icart,
            orderstatus _orderstatus,
            orderlineitemstatus _orderlineitemstatus
            )
        {
            Icart = _Icart;
            orderstatus = _orderstatus;
            orderlineitemstatus = _orderlineitemstatus;
        }
        public void AddCartItem(MenuItem _item)
        {
            var orderStatus = Icart.Count();
            if (orderStatus == null)
            {
                orderstatus.orderid = Guid.NewGuid().ToString();
                orderstatus.ordercheckincode = RandomNumber.getRandomCode();
                orderstatus.status = StatusCodeMetadata.Checkout;
            }
            

            orderlineitemstatus.orderlineitemid = Guid.NewGuid().ToString();
            orderlineitemstatus.ordercheckincode = orderStatus == null 
                    ? orderstatus.ordercheckincode : orderStatus.ordercheckincode; 
            orderlineitemstatus.productname = _item.name;
            orderlineitemstatus.producttype = _item.type;
            orderlineitemstatus.price = _item.price;
            orderlineitemstatus.quantity = _item.qty;
            orderlineitemstatus.lineitemstatus = StatusCodeMetadata.Checkout;

            Icart.Insert(orderstatus, orderlineitemstatus);
            Icart.Save();
        }

        public async Task<IEnumerable<cartlineitemdetails>> getCartItemCollection() 
        {
            var result = await Icart.GetAllAsync();
            return result;
        }

        public void DeleteItem(string _item)
        {
            Icart.Delete(_item);
            Icart.Save();
        }

        public void Update(string id, string nextStatus, string checkincode) 
            => Icart.Update(id, nextStatus, checkincode);

        public void checkoutcart()
        {
            Icart.checkoutcart();
            Icart.Save();
        }
    }
}
