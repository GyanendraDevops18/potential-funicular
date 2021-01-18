using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.DataProvider
{
    public class Provider : IProvider
    {
        private readonly EntityContext context;

        public Provider(EntityContext context)
        {
            this.context = context;
        }
    }
}
