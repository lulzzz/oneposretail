using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePos.Domain
{
    public class StoreAccessModules
    {
        public long AccessModuleId { get; set; }
        public bool IsInventoryAccess { get; set; }
        public bool IsUserManagementAccess { get; set; }
        public bool IsReportsAccess { get; set; }
        public bool IsTimeSheetManagementAccess { get; set; }
        public bool IsProductManagementAccess { get; set; }
        public long StoreId { get; set; }
        public int NumberOfBranchesAllow { get; set; }
    }
}
