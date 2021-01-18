using KitchenRoutingManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.Bussiness
{
    public interface IKitchentBussines
    {
        Task<IEnumerable<kitchenlineitems>> getKitchentCollection();
    }
}
