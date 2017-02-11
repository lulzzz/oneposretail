using System.ComponentModel;

namespace OnePos.Domain
{
    public enum OnePosStoreStatusEnum
    {
        [Description("Store has been created and is queued to be procesed")]
        Queued = 1,
        [Description("Database is creating for the store")]
        DatabaseCreating = 2,
        [Description("Data is copying to store")]
        DataCopying = 3,
        [Description("Store setup has been completed")]
        SetupCompleted = 4,
        [Description("Store has been deleted")]
        Deleted = 5,
        [Description("Store setup failed")]
        Failed = 6,
        [Description("Customer enquiry")]
        Enquiry = 7,
        [Description("Enquiry process completed to the customer")]
        EnquiryComplete = 8,
        [Description("OnePOS system demo")]
        Demo = 9,
        [Description("Demo has been completed")]
        DemoComplete = 10,
        [Description("Customer has been satisfied")]
        Satisfied = 11,
        [Description("Customer has not been satisfied")]
        NotSatisfied = 12,
        [Description("Domain has been actived")]
        ActiveDomain = 13,
        [Description("Domain has been inactived")]
        InactiveDomain = 14,
        [Description("License has been expired")]
        LicenseExpired = 15,
        [Description("Order has been placed")]
        OrderPlaced = 16,
        [Description("Payment has been completed")]
        PaymentCompleted = 17,
        [Description("Payment has not been completed")]
        PaymentNotCompleted = 18
    }
}
