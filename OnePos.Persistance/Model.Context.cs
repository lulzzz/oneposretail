﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnePos.Persistance
{
    using System;
    using System.Data.Entity;
    using System.Data.EntityClient;
    using System.Data.Entity.Infrastructure;
    using OnePos.Domain;
    
    public partial class OnePosEntities : DbContext, IOnePosEntities
    {
        public OnePosEntities()
            : base("name=OnePosEntities")
        {
        }
    	
    	public OnePosEntities(string connectionString)
                : base(connectionString)
    	{
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public int? CommandTimeout
        {
            get { return  ((IObjectContextAdapter)this).ObjectContext.CommandTimeout; }
            set { ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = value; }
        }
    
        private bool _isDisposing = false;
        public event OnDisposedDelegate OnDisposed;
        protected override void Dispose(bool disposing)
        {
            if ( ! _isDisposing )
            {
                _isDisposing = true;
                base.Dispose(disposing);
                if (OnDisposed != null) OnDisposed(this, EventArgs.Empty);
            }
        }
    
        public IDbSet<AccessLevel> AccessLevels { get; set; }
        public IDbSet<AutoGratuity> AutoGratuities { get; set; }
        public IDbSet<AutoGratuityClone> AutoGratuityClones { get; set; }
        public IDbSet<Break> Breaks { get; set; }
        public IDbSet<BusinessDay> BusinessDays { get; set; }
        public IDbSet<CustomerOrder> CustomerOrders { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<DayPart> DayParts { get; set; }
        public IDbSet<Deposit> Deposits { get; set; }
        public IDbSet<DiscountClone> DiscountClones { get; set; }
        public IDbSet<Discount> Discounts { get; set; }
        public IDbSet<ExceptionModifierGroup> ExceptionModifierGroups { get; set; }
        public IDbSet<ExceptionModifier> ExceptionModifiers { get; set; }
        public IDbSet<ExtendedBoolTable> ExtendedBoolTables { get; set; }
        public IDbSet<ExtendedDecimalTable> ExtendedDecimalTables { get; set; }
        public IDbSet<ExtendedIntTable> ExtendedIntTables { get; set; }
        public IDbSet<ExtendedLinkTable> ExtendedLinkTables { get; set; }
        public IDbSet<ExtendedStringTable> ExtendedStringTables { get; set; }
        public IDbSet<FingerPassword> FingerPasswords { get; set; }
        public IDbSet<ForcedModifierGroup> ForcedModifierGroups { get; set; }
        public IDbSet<ForcedModifier> ForcedModifiers { get; set; }
        public IDbSet<GiftCardsSold> GiftCardsSolds { get; set; }
        public IDbSet<GlCode> GlCodes { get; set; }
        public IDbSet<HouseAccount> HouseAccounts { get; set; }
        public IDbSet<InclusiveTipRate> InclusiveTipRates { get; set; }
        public IDbSet<InventoryCountLog> InventoryCountLogs { get; set; }
        public IDbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
        public IDbSet<JobCode> JobCodes { get; set; }
        public IDbSet<LayoutObj> LayoutObjs { get; set; }
        public IDbSet<LocationLayout> LocationLayouts { get; set; }
        public IDbSet<MenuGroup> MenuGroups { get; set; }
        public IDbSet<Menu> Menus { get; set; }
        public IDbSet<NoSale> NoSales { get; set; }
        public IDbSet<OrderedRecipe> OrderedRecipes { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<PageLayoutStructure> PageLayoutStructures { get; set; }
        public IDbSet<PayGrade> PayGrades { get; set; }
        public IDbSet<PaymentReason> PaymentReasons { get; set; }
        public IDbSet<Payment> Payments { get; set; }
        public IDbSet<PayrollRun> PayrollRuns { get; set; }
        public IDbSet<PciLog> PciLogs { get; set; }
        public IDbSet<PriceIntervalDiscount> PriceIntervalDiscounts { get; set; }
        public IDbSet<PrinterExclusion> PrinterExclusions { get; set; }
        public IDbSet<PrinterGroup> PrinterGroups { get; set; }
        public IDbSet<Printer> Printers { get; set; }
        public IDbSet<ProcessorConfiguration> ProcessorConfigurations { get; set; }
        public IDbSet<ProductGroup> ProductGroups { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<ProfitCenter> ProfitCenters { get; set; }
        public IDbSet<PurchaseChildOrder> PurchaseChildOrders { get; set; }
        public IDbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public IDbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public IDbSet<RecipeProduct> RecipeProducts { get; set; }
        public IDbSet<Recipe> Recipes { get; set; }
        public IDbSet<RevenueType> RevenueTypes { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<Sale> Sales { get; set; }
        public IDbSet<Schedule> Schedules { get; set; }
        public IDbSet<Shift> Shifts { get; set; }
        public IDbSet<SMSConfiguration> SMSConfigurations { get; set; }
        public IDbSet<SpecialPay> SpecialPays { get; set; }
        public IDbSet<StoreLocation> StoreLocations { get; set; }
        public IDbSet<SurchargeConfigurationClone> SurchargeConfigurationClones { get; set; }
        public IDbSet<SurchargeConfiguration> SurchargeConfigurations { get; set; }
        public IDbSet<SurchargeGroup> SurchargeGroups { get; set; }
        public IDbSet<SysConfig> SysConfigs { get; set; }
        public IDbSet<TaxConfigurationClone> TaxConfigurationClones { get; set; }
        public IDbSet<TaxConfiguration> TaxConfigurations { get; set; }
        public IDbSet<TaxGroup> TaxGroups { get; set; }
        public IDbSet<TenderType> TenderTypes { get; set; }
        public IDbSet<TerminalPrinterMap> TerminalPrinterMaps { get; set; }
        public IDbSet<Terminal> Terminals { get; set; }
        public IDbSet<TimePunch> TimePunches { get; set; }
        public IDbSet<Transaction> Transactions { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<VendorAccount> VendorAccounts { get; set; }
        public IDbSet<VendorProduct> VendorProducts { get; set; }
        public IDbSet<WorkCenter> WorkCenters { get; set; }
    }
}
