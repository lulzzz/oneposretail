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
    
    public partial class PurchaseChildOrder
    {
        public PurchaseChildOrder()
        {
            this.VendorProducts = new HashSet<VendorProduct>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public int SequencyNo { get; set; }
        public System.Guid PurchaseOrder_Id { get; set; }
        public System.Guid Product_Id { get; set; }
        public long Qty { get; set; }
        public decimal ProcApprPrice { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public System.Guid Userid { get; set; }
        public string Remarks { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> PurchaseOrderNumber_Id { get; set; }
    
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual ICollection<VendorProduct> VendorProducts { get; set; }
    }
}
