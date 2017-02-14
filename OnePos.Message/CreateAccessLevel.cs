using OnePos.Message.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnePos.Framework.ServiceModel;


namespace OnePos.Message
{
    public class CreateAccessLevelRequest : Request
    { 

        public AccessLevel AccessLevel { get; set; } 
    }

    public class CreateAccessLevelResponse : Response
    {
        public Guid AccessLevelID { get; set; }
    }
}
