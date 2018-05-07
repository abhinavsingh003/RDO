using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RdoCallLogger.Models
{
    public class RdoEntities : DbContext
    {
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Solution> Solutions { get; set; }
    }
}