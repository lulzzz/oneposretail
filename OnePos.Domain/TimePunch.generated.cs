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
    
    public partial class TimePunch
    {
        public TimePunch()
        {
            this.Breaks = new HashSet<Break>();
            this.Users = new HashSet<User>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public System.DateTime ClockedIn { get; set; }
        public Nullable<System.DateTime> ClockedOut { get; set; }
        public System.Guid ClockedInDaypartId { get; set; }
        public Nullable<System.Guid> ClockedOutDaypartId { get; set; }
        public System.Guid RoleId { get; set; }
        public System.Guid ClockedInTerminalId { get; set; }
        public Nullable<System.Guid> ClockedOutTerminalId { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid ProfitCenterId { get; set; }
        public decimal CashTipsClaimed { get; set; }
        public bool WasAutoClockedOut { get; set; }
        public Nullable<System.Guid> SpecialPayId { get; set; }
        public System.Guid ShiftId { get; set; }
        public string PayGradeName { get; set; }
        public decimal WageRate { get; set; }
        public decimal TipTaxRate { get; set; }
        public bool IsSalaried { get; set; }
        public bool OtAppliedByDayHours { get; set; }
        public decimal WageRateOnOverTime { get; set; }
        public bool BreaksArePaid { get; set; }
        public decimal OtHoursThreshold { get; set; }
        public bool IsEligibleForOvertimePay { get; set; }
        public int JobType { get; set; }
        public string JobCodeName { get; set; }
        public string RoleName { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Break> Breaks { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual SpecialPay SpecialPay { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
