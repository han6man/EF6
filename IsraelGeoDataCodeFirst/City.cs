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
    public partial class City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public City()
        {
            Streets = new HashSet<Street>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int city_code { get; set; }

        [Required]
        [StringLength(50)]
        public string city_name { get; set; }

        //[Required]
        [StringLength(50)]
        public string city_name_foreign { get; set; }

        public int? region_code { get; set; }
        //public string Region_name { get; set; }
        public int? lishkat_mana_code { get; set; }
        //public string Lishka_Name { get; set; }
        public int? muaca_ezorit_code { get; set; }
        //public string Muaca_Izorit_Name { get; set; }
        //public string Table { get; set; }

        public virtual Lishka LishkotMana { get; set; }

        public virtual Muaca Muacot { get; set; }

        public virtual Region Regions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Street> Streets { get; set; }
    }
}
