//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Street
    {
        public int Street_Code { get; set; }
        public string Street_Name { get; set; }
        public string Street_Name_En { get; set; }
        public string Street_Name_Ru { get; set; }
        public string Street_Name_Status { get; set; }
        public int Street_Official_Code { get; set; }
        public int City_Code { get; set; }
        public Nullable<decimal> Street_Latitude { get; set; }
        public Nullable<decimal> Street_Longitude { get; set; }
    
        public virtual City City { get; set; }
    }
}