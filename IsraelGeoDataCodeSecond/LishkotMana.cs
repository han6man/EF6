namespace IsraelGeoDataCodeSecond
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LishkotMana")]
    public partial class LishkotMana
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LishkotMana()
        {
            Cities = new HashSet<City>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int lishkat_mana_code { get; set; }

        [StringLength(50)]
        public string lishka { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<City> Cities { get; set; }
    }
}
