using KitchenRoutingManagement.DataProvider.CartService;
using KitchenRoutingManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.Bussiness
{
    internal class KitchentBussines : IKitchentBussines
    {
        private readonly IKitchent IKitchent;

        public KitchentBussines(IKitchent _IKitchent)
        {
            IKitchent = _IKitchent;
        }

        public async Task<IEnumerable<kitchenlineitems>> getKitchentCollection()
        {
            var result = await IKitchent.GetAllAsync();
            return result;
        }
    }
}
