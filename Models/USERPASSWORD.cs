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
    
    public partial class USERPASSWORD
    {
        public int ID { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Password { get; set; }
        public Nullable<int> passwordExpiryTime { get; set; }
        public string passwordExpiryDate { get; set; }
    
        public virtual USERS USERS { get; set; }
    }
}
