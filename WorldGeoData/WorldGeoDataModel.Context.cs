﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldGeoData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WorldGeoDataDB : DbContext
    {
        public WorldGeoDataDB()
            : base("name=WorldGeoDataDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<City_Region> City_Regions { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Country_Region> Country_Regions { get; set; }
        public virtual DbSet<Country_Status> Country_Statuses { get; set; }
        public virtual DbSet<Lishkat_Mana> Lishkot_Mana { get; set; }
        public virtual DbSet<Regional_Council> Regional_Councils { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<UN_Member_Status> UN_Member_Statuses { get; set; }
        public virtual DbSet<World_Region> World_Regions { get; set; }
        public virtual DbSet<View_Cities> View_Cities { get; set; }
        public virtual DbSet<View_Streets> View_Streets { get; set; }
        public virtual DbSet<View_Streets_With_Synonyms> View_Streets_With_Synonyms { get; set; }
    }
}