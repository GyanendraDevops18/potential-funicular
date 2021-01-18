using Microsoft.EntityFrameworkCore;
using KitchenRoutingManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRoutingManagement.DataProvider
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {

        }

        public DbSet<orderstatus> orderstatus { get; set; }
        public DbSet<orderlineitemstatus> orderlineitemstatus { get; set; }
        public DbSet<cartlineitemdetails> cartlineitemdetails { get; set; }
        public DbSet<kitchenlineitems> kitchenlineitems { get; set; }
    }
}
