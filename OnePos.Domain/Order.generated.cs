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
    
    public partial class Order
    {
        public Order()
        {
            this.CustomerOrders = new HashSet<CustomerOrder>();
            this.GiftCardsSolds = new HashSet<GiftCardsSold>();
            this.NoSales = new HashSet<NoSale>();
            this.Sales = new HashSet<Sale>();
            this.Transactions = new HashSet<Transaction>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public string HumanReadableOrderId { get; set; }
        public string BarCodeNumber { get; set; }
        public System.DateTime OpenDateStamp { get; set; }
        public System.Guid CreatorId { get; set; }
        public System.Guid CloserId { get; set; }
        public string TableName { get; set; }
        public System.DateTime ClosedDateStamp { get; set; }
        public System.DateTime ReservationTime { get; set; }
        public System.DateTime SitDownTime { get; set; }
        public System.DateTime FirstOrderTime { get; set; }
        public System.DateTime LastOrderTime { get; set; }
        public System.DateTime FirstPrintTime { get; set; }
        public System.DateTime FirstPayTime { get; set; }
        public Nullable<System.DateTime> LastPayTime { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid CustomerId { get; set; }
        public System.Guid TerminalWhereCreatedId { get; set; }
        public System.Guid ReopenByUserId { get; set; }
        public System.Guid BusinessDayId { get; set; }
        public System.Guid CardOnFileExtId { get; set; }
        public System.Guid RevenueCenterId { get; set; }
        public System.Guid ShiftId { get; set; }
        public long PrintCount { get; set; }
        public System.DateTime ReopenTime { get; set; }
        public bool IsBarSeat { get; set; }
        public string CustomerName { get; set; }
        public bool HasHeadOfTable { get; set; }
        public bool IsClosed { get; set; }
        public bool HasCardOnFile { get; set; }
        public bool HasTimedOut { get; set; }
        public System.DateTime LastAttentedToDateStamp { get; set; }
        public System.DateTime LastModifiedDateStamp { get; set; }
        public bool SplitBySeatHasBeenApplied { get; set; }
        public bool UserChangedCheckSinceSplitBySeat { get; set; }
        public bool EqualPayIsActive { get; set; }
        public int EqualPayCount { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
        public int Ptr_OrderId { get; set; }
    
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
        public virtual ICollection<GiftCardsSold> GiftCardsSolds { get; set; }
        public virtual ICollection<NoSale> NoSales { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}