using System;


namespace OnePos.Message.Model
{
    public class AccessLevel
    {
        //public AccessLevel()
        //{
        //    Id = Guid.NewGuid();
        //    IsDeleted = false;
        //}

        public bool CanViewReports { get; set; }
        public bool CanApplyCompToItem { get; set; }
        public bool CanOrder { get; set; }
        public bool CanAccessSystemConfig { get; set; }
        public bool CanSetMagStripe { get; set; }
        public bool RequireMagcardLogin { get; set; }
        public bool CanCaptureElectronicPayments { get; set; }
        public bool CanSearchAllPayments { get; set; }
        public bool CanTransferOrder { get; set; }
        public bool CanApplyAdditionalSurcharge { get; set; }
        public bool CanNoSale { get; set; }
        public bool CanReopenOrder { get; set; }
        public bool CanSeeOtherUsersOrders { get; set; }
        public bool CanCloseHouse { get; set; }
        public bool CanBatchPayments { get; set; }
        public bool CanPromoCheck { get; set; }
        public bool CanApplyVoidToItem { get; set; }
        public bool CanVoidPayment { get; set; }
        public bool CanApplyHousePayment { get; set; }
        public bool CanPayIn { get; set; }
        public bool CanPayOut { get; set; }
        public bool CanTaxFree { get; set; }
        public bool CanForceUnlockTerminal { get; set; }

        //public Guid? ExtendedBoolTableId { get; set; }
        //public Guid? ExtendedStringTableId { get; set; }
        //public Guid? ExtendedDecimalTableId { get; set; }
        //public Guid? ExtendedIntTableId { get; set; }
        //public Guid? ExtendedLinkTable1Id { get; set; }
        //public Guid? ExtendedLinkTable2Id { get; set; }

        public bool GrowthBool1 { get; set; }
        public bool GrowthBool2 { get; set; }
        public bool GrowthBool3 { get; set; }
        public bool GrowthBool4 { get; set; }
        public bool GrowthBool5 { get; set; }
        public bool GrowthBool6 { get; set; }
        public bool GrowthBool7 { get; set; }
        public bool GrowthBool8 { get; set; }
        public bool GrowthBool9 { get; set; }
        public bool GrowthBool10 { get; set; }


        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Byte[] TimeStamp { get; set; }
        public string Name { get; set; }

       
        public bool Master { get; set; }
        public bool Sales { get; set; }
        public bool Discounts { get; set; }
        public bool Payroll { get; set; }
        public bool Checkouts { get; set; }
        public bool Onetouch { get; set; }
        public bool Employee { get; set; }
    }
}
