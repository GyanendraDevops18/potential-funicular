using KitchenRoutingManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.DataProvider.CartService
{
    public interface IOrder
    {
        Task<IEnumerable<cartlineitemdetails>> GetAllAsync();
    }
}