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
    
    public partial class Sale
    {
        public Sale()
        {
            this.DiscountClones = new HashSet<DiscountClone>();
            this.Sales1 = new HashSet<Sale>();
            this.SurchargeConfigurationClones = new HashSet<SurchargeConfigurationClone>();
            this.TaxConfigurationClones = new HashSet<TaxConfigurationClone>();
            this.AutoGratuityClones = new HashSet<AutoGratuityClone>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public bool IsPersisted { get; set; }
        public bool IsSelected { get; set; }
        public System.Guid ProductId { get; set; }
        public System.Guid ProductsMainCatId { get; set; }
        public bool CountsAsSalesRevenue { get; set; }
        public decimal MenuPrice { get; set; }
        public decimal AdjustPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool IsForcedModifier { get; set; }
        public string ProductName { get; set; }
        public string NoteForPrint { get; set; }
        public Nullable<System.Guid> PrinterGroupingId { get; set; }
        public bool OnHold { get; set; }
        public bool IsForcedProduct { get; set; }
        public Nullable<System.Guid> PrintJobId { get; set; }
        public int OwningSeatNumber { get; set; }
        public int OwningCheckNumber { get; set; }
        public bool IsExceptionModifier { get; set; }
        public bool ProductIsDiscountable { get; set; }
        public string Sku { get; set; }
        public System.Guid UserId { get; set; }
        public string Ordermode { get; set; }
        public decimal CountOrdered { get; set; }
        public Nullable<System.DateTime> BumpbarPreparedTime { get; set; }
        public System.Guid ProfitCenterId { get; set; }
        public System.Guid DaypartId { get; set; }
        public System.Guid RevenueTypeId { get; set; }
        public bool IsWithout { get; set; }
        public string NoteForPrintBeforeHold { get; set; }
        public int HoldMinutes { get; set; }
        public System.DateTime FirstOrderedDateTime { get; set; }
        public System.DateTime LastOrderedDateTime { get; set; }
        public int CountPendingKitchenSend { get; set; }
        public int CheckSequenceNumber { get; set; }
        public int ModifierSequenceNumber { get; set; }
        public decimal InclusiveTipRate { get; set; }
        public decimal InclusiveTipFlatFee { get; set; }
        public string InclusiveTipRateName { get; set; }
        public string RevenueTypeName { get; set; }
        public int SeatSequenceNumber { get; set; }
        public string Notes { get; set; }
        public bool IsSeeServer { get; set; }
        public bool ApplyAutoGratToMenuPrice { get; set; }
        public bool IsGiftCardSale { get; set; }
        public System.Guid OrderId { get; set; }
        public Nullable<System.Guid> ParentSaleWhenModSaleId { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<DiscountClone> DiscountClones { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<Sale> Sales1 { get; set; }
        public virtual Sale Sale1 { get; set; }
        public virtual ICollection<SurchargeConfigurationClone> SurchargeConfigurationClones { get; set; }
        public virtual ICollection<TaxConfigurationClone> TaxConfigurationClones { get; set; }
        public virtual ICollection<AutoGratuityClone> AutoGratuityClones { get; set; }
    }
}
