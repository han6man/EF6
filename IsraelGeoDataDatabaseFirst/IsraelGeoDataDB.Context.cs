﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IsraelGeoDataDatabaseFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IsraelGeoDataDB : DbContext
    {
        public IsraelGeoDataDB()
            : base("name=IsraelGeoDataDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Lishka> LishkotMana { get; set; }
        public virtual DbSet<Muaca> Muacot { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
    }
}
