using System.ComponentModel;

namespace OnePos.Domain
{
    public enum AccessModulesEnum
    {
        [Description("Inventory Module")]
        Inventory = 1,
        [Description("Product Management")]
        ProductManagement = 2,
        [Description("Reports Access")]
        ReportsAccess = 3,
        [Description("User Management")]
        UserManagement = 4 
    }
}
