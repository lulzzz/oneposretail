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
    
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            this.TerminalPrinterMaps = new HashSet<TerminalPrinterMap>();
            this.Menus = new HashSet<Menu>();
            this.ProfitCenters = new HashSet<ProfitCenter>();
            this.ProfitCenters1 = new HashSet<ProfitCenter>();
            this.ExceptionModifierGroups = new HashSet<ExceptionModifierGroup>();
            this.PriceIntervalDiscounts = new HashSet<PriceIntervalDiscount>();
            this.Products = new HashSet<Product>();
        }
    
        public System.Guid Id { get; set; }
        public string ProductgroupColor { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public int MenuPosition { get; set; }
        public bool CanDiscountGroup { get; set; }
        public bool UseDriversAgeVerification { get; set; }
        public bool ApplyGroupPrice { get; set; }
        public decimal GroupPrice { get; set; }
        public bool OrderMenuItemsByWeight { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<TerminalPrinterMap> TerminalPrinterMaps { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<ProfitCenter> ProfitCenters { get; set; }
        public virtual ICollection<ProfitCenter> ProfitCenters1 { get; set; }
        public virtual ICollection<ExceptionModifierGroup> ExceptionModifierGroups { get; set; }
        public virtual ICollection<PriceIntervalDiscount> PriceIntervalDiscounts { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}