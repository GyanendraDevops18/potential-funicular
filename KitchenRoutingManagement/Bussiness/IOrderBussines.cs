using KitchenRoutingManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.Bussiness
{
    public interface IOrderBussines
    {
        Task<IEnumerable<cartlineitemdetails>> getOrdersCollection();
    }
}
