using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.ServiceModel.Activation;
using OnePos.Framework;
using OnePos.Framework.Domain;
using OnePos.Persistance;
using System.Globalization;
using System.Threading;

namespace OnePos.API
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly IDependencyContainer _container = DependencyContainer.Default;
        protected void Application_Start(object sender, EventArgs e)
        {
           // RouteTable.Routes.Add(new ServiceRoute("API/Products", new WebServiceHostFactory(), typeof(ManageProducts)));
            RouteTable.Routes.Add(new ServiceRoute("API/Stores", new WebServiceHostFactory(), typeof(ManageStores)));
           // RouteTable.Routes.Add(new ServiceRoute("API/Users", new WebServiceHostFactory(), typeof(ManageUsers)));
            RouteTable.Routes.Add(new ServiceRoute("API/Taxes", new WebServiceHostFactory(), typeof(ManageTaxes)));
            RegisterPersistence();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            newCulture.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            newCulture.DateTimeFormat.DateSeparator = "-";
            Thread.CurrentThread.CurrentCulture = newCulture;
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        private static void RegisterPersistence()
        {
            _container.Register<IUniqueIdentifierGenerator, GuidCombGenerator>();
            _container.RegisterInstance<IOnePosEntitiesFactory>(new OnePosEntitiesFactory(_container));
            _container.RegisterPerRequest<IOnePosEntities, OnePosEntities>(); 
        }
    }
}