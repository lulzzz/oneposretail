using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;


namespace OnePos.Message
{
    class GetProductGroups
    {
    }

    public class GetProductGroupsRequest : Request
    {
        public Guid ProductGroupID { get; set; }
    }

    public class GetProductGroupsResponse : Response
    {
        public IList<ProductGroup> ProductGroup { get; set; }
    }
}
