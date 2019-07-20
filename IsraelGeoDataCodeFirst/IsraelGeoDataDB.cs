using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IsraelGeoDataCodeFirst
{
    class IsraelGeoDataDB : DbContext
    {
        public IsraelGeoDataDB() : base("DbConnection")
        { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Lishka> Lishkot { get; set; }
        public DbSet<Muaca> Muacot { get; set; }
        public DbSet<Street> Streets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Streets)
                .WithRequired(e => e.Cities)
                .WillCascadeOnDelete(false);
        }
    }
}
