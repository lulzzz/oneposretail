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
    
    public partial class RecipeIngredient
    {
        public System.Guid Id { get; set; }
        public decimal Amount { get; set; }
        public int Count { get; set; }
        public System.Guid RecipeProductId { get; set; }
        public System.Guid RecipeId { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
    
        public virtual RecipeProduct RecipeProduct { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
