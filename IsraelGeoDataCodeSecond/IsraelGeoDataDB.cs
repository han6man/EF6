namespace IsraelGeoDataCodeSecond
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IsraelGeoDataDB : DbContext
    {
        public IsraelGeoDataDB()
            : base("name=IsraelGeoDataDB")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<LishkotMana> LishkotManas { get; set; }
        public virtual DbSet<Muacot> Muacots { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Street> Streets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Streets)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);
        }
    }
}
