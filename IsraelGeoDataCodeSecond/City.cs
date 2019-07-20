namespace IsraelGeoDataCodeSecond
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public City()
        {
            Streets = new HashSet<Street>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int city_code { get; set; }

        [Required]
        [StringLength(50)]
        public string city_name { get; set; }

        [StringLength(50)]
        public string city_name_foreign { get; set; }

        public int? region_code { get; set; }

        public int? lishkat_mana_code { get; set; }

        public int? muaca_ezorit_code { get; set; }

        public virtual LishkotMana LishkotMana { get; set; }

        public virtual Muacot Muacot { get; set; }

        public virtual Region Region { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Street> Streets { get; set; }
    }
}
