using System;
using System.Collections.Generic;
using KitchenRoutingManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.DataProvider.CartService
{
    public interface Icart
    {
        Task<IEnumerable<cartlineitemdetails>> GetAllAsync();

        void Insert(orderstatus _orderstatus, orderlineitemstatus _orderlineitemstatus);

        void Insert(orderstatus _product);

        void Insert(orderlineitemstatus _product);

        void Delete(string id);

        void Update(string id, string nextStatus, string checkincode);

        orderstatus Count();

        void checkoutcart();

        void Save();
    }
}