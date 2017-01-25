using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace OnePos.Message.Model
{
    interface IAuditable
    {
        string CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
