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
    
    public partial class TenderType
    {
        public TenderType()
        {
            this.Payments = new HashSet<Payment>();
            this.Transactions = new HashSet<Transaction>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public bool AssumePaysInFull { get; set; }
        public bool OpensCashDrawer { get; set; }
        public bool PrintsReceipt { get; set; }
        public int ReceiptCount { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
        public bool IsOther { get; set; }
        public bool IsCreditOther { get; set; }
        public bool IsAccount { get; set; }
        public bool IsRoom { get; set; }
        public bool IsComp { get; set; }
        public bool IsCheck { get; set; }
        public bool IsDomesticCurrency { get; set; }
        public bool PromptForCrossReference { get; set; }
        public bool IsGift { get; set; }
        public bool ClosesCheck { get; set; }
        public bool IsBuiltIn { get; set; }
        public bool IsAmex { get; set; }
        public bool IsDiscover { get; set; }
        public bool DinersClub { get; set; }
        public bool IsJcb { get; set; }
        public bool IsMasterCard { get; set; }
        public bool IsVisa { get; set; }
        public bool IsVoid { get; set; }
    
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
