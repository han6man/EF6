namespace IsraelGeoDataCodeSecond
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Street
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int street_code { get; set; }

        [Required]
        [StringLength(50)]
        public string street_name { get; set; }

        [Required]
        [StringLength(50)]
        public string street_name_status { get; set; }

        public int official_code { get; set; }

        public int city_code { get; set; }

        public virtual City City { get; set; }
    }
}
