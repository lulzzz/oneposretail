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
    
    public partial class TaxConfiguration
    {
        public TaxConfiguration()
        {
            this.TaxGroups = new HashSet<TaxGroup>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public bool AlwaysRunTax { get; set; }
        public bool IsInclusiveTax { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public bool RunMonday { get; set; }
        public bool RunTuesday { get; set; }
        public bool RunWednesday { get; set; }
        public bool RunThursday { get; set; }
        public bool RunFriday { get; set; }
        public bool RunSaturday { get; set; }
        public bool RunSunday { get; set; }
        public decimal Rate { get; set; }
        public bool IsFlatFee { get; set; }
        public decimal FlatFee { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<TaxGroup> TaxGroups { get; set; }
    }
}