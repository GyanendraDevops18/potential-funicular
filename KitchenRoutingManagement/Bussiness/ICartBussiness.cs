using KitchenRoutingManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.Bussiness
{
    public interface ICartBussiness
    {
        Task<IEnumerable<cartlineitemdetails>> getCartItemCollection();

        void AddCartItem(MenuItem _item);        

        void DeleteItem(string _item);

        void Update(string id, string nextStatus, string checkincode);

        void checkoutcart();
    }
}
