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
        Deleted = 5
    }
}
