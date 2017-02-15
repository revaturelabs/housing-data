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
    
    public partial class Associate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Associate()
        {
            this.HousingDatas = new HashSet<HousingData>();
        }
    
        public int AssociateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> GenderId { get; set; }
        public Nullable<int> BatchId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public bool HasCar { get; set; }
        public bool HasKeys { get; set; }
        public bool NeedsHousing { get; set; }
        public bool Active { get; set; }
    
        public virtual Batch Batch { get; set; }
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HousingData> HousingDatas { get; set; }
    }
}
