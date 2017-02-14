using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;



namespace OnePos.Message
{
    public class GetAccessLevelsRequest : Request
    {
    }

    public class GetAccessLevelsResponse : Response
    {
        public IList<AccessLevel> AccessLevels { get; set; }
    }
}
