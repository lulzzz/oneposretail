using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;

namespace OnePos.Message
{
    public class GetStoreTypesRequest : Request
    {
    }

    public class GetStoreTypesResponse : Response
    {
        public IList<StoreType> StoreTypes { get; set; }
    }
}
