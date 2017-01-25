using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; 
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using OnePos.DataCollector;
using OnePos.Domain;
using OnePos.Domain.Encryption;
using OnePos.Message;
using OnePos.Persistance;
using OnePos.ServiceInterface; 
using System.ServiceModel.Activation;
using System.IO;
using OnePos.Framework.ServiceModel;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Hosting;
using OnePos.API.Models;
using OnePos.Framework;
using OnePos.Message.Model;

namespace OnePos.API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ManageProduct" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ManageProduct.svc or ManageProduct.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(
     RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    public class ManageProduct : IManageProduct
    {
        public string DoWork()
        {
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);
            CreateProductHandler createProductHandler = new CreateProductHandler(dFactory, OnePosEntities);

            
            return "";
        }
    }
}
