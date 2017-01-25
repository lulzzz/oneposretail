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
    
    public partial class Terminal
    {
        public Terminal()
        {
            this.PrinterExclusions = new HashSet<PrinterExclusion>();
            this.TerminalPrinterMaps = new HashSet<TerminalPrinterMap>();
            this.AutoGratuities = new HashSet<AutoGratuity>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
        public System.Guid ProfitCenterId { get; set; }
        public Nullable<System.Guid> ForceOrderProdId { get; set; }
        public Nullable<System.Guid> MenuGroupId { get; set; }
        public Nullable<System.Guid> ForceOrderProdGroupId { get; set; }
        public Nullable<System.Guid> LocalPrinterId { get; set; }
        public byte NumberOfCashDrawers { get; set; }
        public int FirstCashDrawerNumber { get; set; }
        public bool OpenDrawerOnPay { get; set; }
        public long SystemComFlags { get; set; }
        public bool CreateAutoSeats { get; set; }
        public bool PrintItemizedReceiptOnPay { get; set; }
        public bool PrintCashReceiptOnPay { get; set; }
        public bool UseProductGroupPrinterMapping { get; set; }
        public bool ForceCashDrop { get; set; }
        public Nullable<decimal> ForceCashDropAmount { get; set; }
        public bool PrintCreditReceiptOnPay { get; set; }
        public bool PrintGiftReceiptOnPay { get; set; }
        public byte NumberCashReceipts { get; set; }
        public byte NumberCreditReceipts { get; set; }
        public byte NumberGiftReceipts { get; set; }
        public bool IsQuickServiceMode { get; set; }
        public string CustomerDisplayLineOne { get; set; }
        public string CustomerDisplayLineTwo { get; set; }
        public string CustomerDisplayComport { get; set; }
        public string ScaleComport { get; set; }
        public bool EnableCustomerDisplay { get; set; }
        public bool UseOrderLabel { get; set; }
        public bool HasPaymentGateway { get; set; }
        public int ScreenSaverTimeoutSeconds { get; set; }
        public bool ShowMouseCursor { get; set; }
        public bool EnableCardLogin { get; set; }
        public bool ShowTerminalLockedOnCfd { get; set; }
        public string CustomPrintImagePath { get; set; }
        public string CustomScreenImagePath { get; set; }
        public string CustomLogoImagePath { get; set; }
        public bool RebootOnHouseClose { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> ProcessorConfiguration_Id { get; set; }
    
        public virtual ICollection<PrinterExclusion> PrinterExclusions { get; set; }
        public virtual ProcessorConfiguration ProcessorConfiguration { get; set; }
        public virtual ICollection<TerminalPrinterMap> TerminalPrinterMaps { get; set; }
        public virtual ICollection<AutoGratuity> AutoGratuities { get; set; }
    }
}