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
    
    public partial class ExceptionModifierGroup
    {
        public ExceptionModifierGroup()
        {
            this.ExceptionModifiers = new HashSet<ExceptionModifier>();
            this.ProductGroups = new HashSet<ProductGroup>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public bool ApplyGroupPrice { get; set; }
        public decimal GroupPrice { get; set; }
        public int MenuPosition { get; set; }
        public bool OrderMenuItemsByWeight { get; set; }
        public Nullable<System.Guid> ExceptionModOnExceptionModGroupId { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<ExceptionModifier> ExceptionModifiers { get; set; }
        public virtual ICollection<ProductGroup> ProductGroups { get; set; }
    }
}