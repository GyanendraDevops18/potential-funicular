using KitchenRoutingManagement.DataProvider.CartService;
using KitchenRoutingManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.DataProvider.Repository
{
    public class KitchenRepository : IKitchent
    {
        private readonly EntityContext db;
        public KitchenRepository(EntityContext _db)
        {
            db = _db;
        }

        public async Task<IEnumerable<kitchenlineitems>> GetAllAsync()
        {
            var result =
               await db.kitchenlineitems.FromSqlRaw(
                          @"SELECT orderlineitemid AS orderid, lineitemstatus, 
                            producttype, productname, quantity 
                            FROM [dbo].[orderlineitemstatus]
                            WHERE lineitemstatus <> 'served'
                            GROUP BY orderlineitemid, lineitemstatus, producttype, productname, quantity
                            ORDER BY producttype").ToListAsync();

            return result;
        }
    }
}