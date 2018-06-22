//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DealershipInc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            this.CarSalesForms = new HashSet<CarSalesForm>();
        }
    
        public string VIN { get; set; }
        public byte Type { get; set; }
        public int Price { get; set; }
        public string isNewFlag { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public System.DateTime DateAdded { get; set; }
        public int ManufacturerID { get; set; }
        public int BranchID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarSalesForm> CarSalesForms { get; set; }
        public virtual DealerBranch DealerBranch { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}