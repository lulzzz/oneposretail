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
    
    public partial class DiscountClone
    {
        public System.Guid Id { get; set; }
        public int TypeOfDiscount { get; set; }
        public bool UsesCouponApi { get; set; }
        public string CouponReference { get; set; }
        public string CouponAuthCode { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public decimal Rate { get; set; }
        public decimal CorrectedAmount { get; set; }
        public bool IsCorrected { get; set; }
        public bool CanCombine { get; set; }
        public System.Guid AuthorizedById { get; set; }
        public System.Guid SaleOwnerId { get; set; }
        public string Explanation { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> Sale_Id { get; set; }
    
        public virtual Sale Sale { get; set; }
    }
}