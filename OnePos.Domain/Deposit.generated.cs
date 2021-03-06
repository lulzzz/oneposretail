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
    
    public partial class Deposit
    {
        public System.Guid Id { get; set; }
        public System.DateTime BusinessDate { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public System.Guid EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public Nullable<System.Guid> TerminalId { get; set; }
        public string Notes { get; set; }
        public int Type { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public System.Guid BusinessDayId { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
    
        public virtual BusinessDay BusinessDay { get; set; }
    }
}
