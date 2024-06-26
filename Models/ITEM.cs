//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iCLOTHINGWebsite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ITEM()
        {
            this.CATEGORY_ITEMS = new HashSet<CATEGORY_ITEMS>();
            this.SHOPPINGCART = new HashSet<SHOPPINGCART>();
            this.SUBCATEGORY_ITEMS = new HashSet<SUBCATEGORY_ITEMS>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Brand { get; set; }
        public Nullable<int> Department { get; set; }
        public Nullable<double> Price { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual BRAND BRAND1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CATEGORY_ITEMS> CATEGORY_ITEMS { get; set; }
        public virtual DEPARTMENT DEPARTMENT1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHOPPINGCART> SHOPPINGCART { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBCATEGORY_ITEMS> SUBCATEGORY_ITEMS { get; set; }
    }
}
