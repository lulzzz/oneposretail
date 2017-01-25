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
    
    public partial class InventoryCountLog
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public Nullable<System.Guid> BatchId { get; set; }
        public string BatchNo { get; set; }
        public long ReceivedQty { get; set; }
        public long OnHandQty { get; set; }
        public long ClaimQty { get; set; }
        public long IntransitQty { get; set; }
        public long OnOrderQty { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal MRPPerUnit { get; set; }
        public decimal DiscountPricePerUnit { get; set; }
        public Nullable<System.DateTime> ProdMfgDate { get; set; }
        public System.DateTime ProdReceiveDate { get; set; }
        public System.DateTime ProdExpiryDate { get; set; }
        public System.Guid UserId { get; set; }
        public Nullable<System.Guid> InvoiceId { get; set; }
        public Nullable<System.Guid> ProductId { get; set; }
        public Nullable<System.Guid> StoreId { get; set; }
        public string StorageLocation { get; set; }
        public string Notes { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> InvoiceLineItem_Id { get; set; }
        public Nullable<System.Guid> StoreLocation_Id { get; set; }
    
        public virtual InvoiceLineItem InvoiceLineItem { get; set; }
        public virtual Product Product { get; set; }
        public virtual StoreLocation StoreLocation { get; set; }
    }
}