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
    
    public partial class SurchargeConfigurationClone
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public decimal Rate { get; set; }
        public decimal CorrectedAmount { get; set; }
        public bool IsFlatFee { get; set; }
        public decimal Fee { get; set; }
        public bool ApplyToGrossPrice { get; set; }
        public System.Guid AppliedByEmployeeId { get; set; }
        public bool IsCorrected { get; set; }
        public decimal TaxRate { get; set; }
        public decimal CorrectedTaxAmount { get; set; }
        public bool TaxIsCorrected { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> Sale_Id { get; set; }
    
        public virtual Sale Sale { get; set; }
    }
}
