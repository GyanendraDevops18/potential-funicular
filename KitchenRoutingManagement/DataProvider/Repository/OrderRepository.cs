using KitchenRoutingManagement.DataProvider.CartService;
using KitchenRoutingManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.DataProvider.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly EntityContext db;
        public OrderRepository(EntityContext _db)
        {
            db = _db;
        }

        public async Task<IEnumerable<cartlineitemdetails>> GetAllAsync()
        {
            var result =
               await db.cartlineitemdetails.FromSqlRaw("EXEC dbo.OrdersList").ToListAsync();

            return result;
        }
    }
}