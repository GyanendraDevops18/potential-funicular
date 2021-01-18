using KitchenRoutingManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.DataProvider.CartService
{
    public interface IKitchent
    {
        Task<IEnumerable<kitchenlineitems>> GetAllAsync();
    }
}