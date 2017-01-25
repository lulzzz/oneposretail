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
    
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            this.InvoiceLineItems = new HashSet<InvoiceLineItem>();
            this.PurchaseChildOrders = new HashSet<PurchaseChildOrder>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public Nullable<System.DateTime> PurchaseOrderDate { get; set; }
        public System.Guid Vendor_Id { get; set; }
        public decimal TotPOApprPrice { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsNew { get; set; }
        public byte[] TimeStamp { get; set; }
        public System.Guid UserId { get; set; }
        public bool IsForwardToRetailer { get; set; }
        public string Remarks { get; set; }
        public string Name { get; set; }
        public System.DateTime EnteredOn { get; set; }
        public Nullable<System.Guid> StoreId_Id { get; set; }
        public Nullable<System.Guid> VendorId_Id { get; set; }
    
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
        public virtual ICollection<PurchaseChildOrder> PurchaseChildOrders { get; set; }
        public virtual StoreLocation StoreLocation { get; set; }
        public virtual VendorAccount VendorAccount { get; set; }
    }
}
