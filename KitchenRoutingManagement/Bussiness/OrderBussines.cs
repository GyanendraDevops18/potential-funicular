using KitchenRoutingManagement.DataProvider.CartService;
using KitchenRoutingManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.Bussiness
{
    internal class OrderBussines : IOrderBussines
    {
        private readonly IOrder IOrder;

        public OrderBussines(IOrder _IOrder)
        {
            IOrder = _IOrder;
        }

        public async Task<IEnumerable<cartlineitemdetails>> getOrdersCollection()
        {
            var result = await IOrder.GetAllAsync();
            return result;
        }
    }
}



