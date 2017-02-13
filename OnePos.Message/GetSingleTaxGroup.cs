using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;

namespace OnePos.Message
{
   

    public class GetSingleTaxGroupRequest : Request
    {
        public Guid Id { get; set; }
    }

    public class GetSingleTaxGroupResponse : Response
    {
        public TaxGroup TaxGroup { get; set; }
    }
}
