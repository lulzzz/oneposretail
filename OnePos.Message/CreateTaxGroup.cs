using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;

namespace OnePos.Message
{
  
    public class CreateTaxGroupRequest : Request
    {
        public TaxGroup TaxGroup { get; set; }
    }

    public class CreateTaxGroupResponse : Response
    {
        public Guid TaxGroupID { get; set; }
    }
}
