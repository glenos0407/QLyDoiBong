using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QLDoiBongDbContext : DbContext
    {
        
        public QLDoiBongDbContext() : base("QLDoiBongConnectionString") { }

        public DbSet<DoiBong> DoiBongs { get; set; }
        public DbSet<CauThu> CauThus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
