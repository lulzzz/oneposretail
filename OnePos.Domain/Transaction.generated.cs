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
    
    public partial class Transaction
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public Nullable<System.Guid> UserTimePunchId { get; set; }
        public string HumanReadableTranId { get; set; }
        public bool WasVoided { get; set; }
        public decimal Tax { get; set; }
        public decimal Base { get; set; }
        public string CustomerName { get; set; }
        public int TypeOfTransaction { get; set; }
        public string CrossReference { get; set; }
        public System.DateTime OpenDateStamp { get; set; }
        public bool WasAutoTipped { get; set; }
        public string TenderMemo { get; set; }
        public System.Guid PaidAtRevenueCenterId { get; set; }
        public Nullable<System.Guid> CustomerId { get; set; }
        public int OwningCheckNumber { get; set; }
        public System.DateTime LastModifiedDateStamp { get; set; }
        public System.Guid UserId { get; set; }
        public decimal Gratuity { get; set; }
        public decimal Change { get; set; }
        public Nullable<System.Guid> ExtId { get; set; }
        public System.Guid LastModifiedUserId { get; set; }
        public bool IsBatched { get; set; }
        public System.Guid BusinessDayId { get; set; }
        public decimal CreditCardTipFee { get; set; }
        public Nullable<System.Guid> TerminalId { get; set; }
        public System.Guid OrderId { get; set; }
        public Nullable<System.Guid> HouseAccountId { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> TenderType_Id { get; set; }
    
        public virtual HouseAccount HouseAccount { get; set; }
        public virtual Order Order { get; set; }
        public virtual TenderType TenderType { get; set; }
    }
}
