using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace IsraelGeoDataCodeFirst
{
    [Table("LishkotMana")]
    public partial class Lishka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lishka()
        {
            Cities = new HashSet<City>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int lishkat_mana_code { get; set; }

        //[Required]
        [StringLength(50)]
        public string lishka { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<City> Cities { get; set; }
    }
}
