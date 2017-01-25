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
    
    public partial class Shift
    {
        public Shift()
        {
            this.Orders = new HashSet<Order>();
            this.Payments = new HashSet<Payment>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public decimal DrawerStart { get; set; }
        public bool IsComplete { get; set; }
        public System.DateTime DateStamp { get; set; }
        public System.Guid UserId { get; set; }
        public int OpenDrawerCount { get; set; }
        public bool IsLocked { get; set; }
        public System.Guid LastTerminalId { get; set; }
        public int MyDrawerOwnership { get; set; }
        public Nullable<System.Guid> MyDrawerOwnerTermId { get; set; }
        public bool IsClockedIn { get; set; }
        public bool IsOnBreak { get; set; }
        public System.Guid BusinessDayId { get; set; }
        public Nullable<System.Guid> WorkCenterId { get; set; }
        public string Notes { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
    
        public virtual BusinessDay BusinessDay { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual TimePunch TimePunch { get; set; }
    }
}