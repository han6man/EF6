//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IsraelGeoDataWPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public City()
        {
            this.Streets = new HashSet<Street>();
        }
    
        public int city_code { get; set; }
        public string city_name { get; set; }
        public string city_name_foreign { get; set; }
        public Nullable<int> region_code { get; set; }
        public Nullable<int> lishkat_mana_code { get; set; }
        public Nullable<int> muaca_ezorit_code { get; set; }
    
        public virtual Lishka LishkotMana { get; set; }
        public virtual Muaca Muacot { get; set; }
        public virtual Region Region { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Street> Streets { get; set; }
    }
}