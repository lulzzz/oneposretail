using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;

namespace OnePos.Message
{
    public class CreateTaxConfigurationRequest : Request
    {
        public TaxConfiguration TaxConfiguration { get; set; }
    }

    public class CreateTaxConfigurationResponse : Response
    {
        public Guid TaxConfigurationID { get; set; }
    }

   
}
