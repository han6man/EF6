using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsraelGeoDataCodeFirst
{
    public partial class Street
    {
        //public int street_code { get; set; }
        //public string street_name { get; set; }
        //public string street_name_status { get; set; }
        //public int official_code { get; set; }
        //public int city_code { get; set; }
        //public string City_name { get; set; }
        //public int RegionId { get; set; }
        //public string Region_name { get; set; }               
        //public string Table { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int street_code { get; set; }

        [Required]
        [StringLength(50)]
        public string street_name { get; set; }

        [Required]
        [StringLength(50)]
        public string street_name_status { get; set; }

        public int official_code { get; set; }

        public int city_code { get; set; }

        public virtual City Cities { get; set; }
    }
}
