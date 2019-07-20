namespace IsraelGeoDataCodeSecond
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Muacot")]
    public partial class Muacot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Muacot()
        {
            Cities = new HashSet<City>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int muaca_ezorit_code { get; set; }

        [StringLength(50)]
        public string muaca_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<City> Cities { get; set; }
    }
}
