//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Housing.Data.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class HousingData
    {
        public int HousingDataId { get; set; }
        public string HousingDataAltId { get; set; }
        public Nullable<int> AssociateId { get; set; }
        public Nullable<int> HousingUnitId { get; set; }
        public System.DateTime MoveInDate { get; set; }
        public System.DateTime MoveOutDate { get; set; }
        public bool Active { get; set; }
    
        public virtual Associate Associate { get; set; }
        public virtual HousingUnit HousingUnit { get; set; }
    }
}
