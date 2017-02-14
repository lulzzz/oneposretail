using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;


namespace OnePos.Message
{

    public class CreateJobCodeRequest : Request
    {
      
        public JobCode JobCode { get; set; }
    }

    public class CreateJobCodeResponse : Response
    {
        public Guid JobID { get; set; }
    }

}
