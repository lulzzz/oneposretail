//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnePos.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.CustomerOrders = new HashSet<CustomerOrder>();
        }
    
        public System.Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
        public int IDType { get; set; }
        public string IDNumber { get; set; }
        public string DateofBirth { get; set; }
        public string ExpiredDate { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
