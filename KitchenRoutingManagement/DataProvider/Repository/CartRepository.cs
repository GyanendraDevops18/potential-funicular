using KitchenRoutingManagement.Bussiness;
using KitchenRoutingManagement.DataProvider.CartService;
using KitchenRoutingManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.DataProvider.Repository
{
    public class CartRepository : Icart
    {
        private readonly EntityContext db;
        public CartRepository(EntityContext _db)
        {
            db = _db;
        }

        public orderstatus orderstatus { get => new orderstatus(); }
        public orderlineitemstatus orderlineitemstatus { get => new orderlineitemstatus(); }

        public void Delete(string id)
        {
            var cartItem = db.orderlineitemstatus.FirstOrDefault(c => c.orderlineitemid == id);
            if (cartItem == null) return;

            db.orderlineitemstatus.Remove(cartItem);
        }

        public async Task<IEnumerable<cartlineitemdetails>> GetAllAsync()
        {
            var result =
               await db.cartlineitemdetails.FromSqlRaw("EXEC dbo.CartLineItems").ToListAsync();

            return result;
        }

        public void Insert(orderstatus _orderstatus, orderlineitemstatus _orderlineitemstatus)
        {

            Insert(_orderstatus);
            Insert(_orderlineitemstatus);
        }

        public void Insert(orderstatus _product = null)
        {
            if (_product.ordercheckincode != null) db.orderstatus.Add(_product);
        }

        public orderstatus Count()
        {
            return db.orderstatus.FirstOrDefault(x => x.status == StatusCodeMetadata.Checkout);
        }

        public void Insert(orderlineitemstatus _product)
        {
            db.orderlineitemstatus.Add(_product);
        }

        public void Update(string id, string nextStatus, string checkincode)
        {
            var data = db.orderlineitemstatus.FirstOrDefault(x => x.orderlineitemid == id);
            if (data != null)
            {
                data.lineitemstatus = nextStatus;
                db.Update(data);
                Save();

                var orderServed = db.orderlineitemstatus
                        .Where(x => x.ordercheckincode == checkincode && x.lineitemstatus != StatusCodeMetadata.Served)
                        .Distinct().Count();
                if (orderServed == 0)
                {
                    var order = db.orderstatus.FirstOrDefault(x => x.ordercheckincode == checkincode);
                    order.status = StatusCodeMetadata.Completed;
                    db.Update(data);
                    Save();
                }
            }
        }

        public void checkoutcart()
        {
            var data = db.orderstatus.FirstOrDefault(x => x.status == StatusCodeMetadata.Checkout);
            data.status = StatusCodeMetadata.Inprogress;

            db.orderstatus.Update(data);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}