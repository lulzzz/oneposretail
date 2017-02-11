using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel.Server;
using OnePos.Message;
using OnePos.Message.Model;
using OnePos.Persistance;
using OnePos.Framework.ServiceModel;
using OnePos.Domain;
using System.Data;

namespace OnePos.ServiceInterface
{
    public class GetStoresHandler : IRequestHandler<GetStoresRequest, GetStoresResponse>
    { 
        private readonly IOnePosEntities _onePosEntities;
        public GetStoresHandler(IOnePosEntities onePosEntities)
        { 
            _onePosEntities = onePosEntities;
        }

        public GetStoresResponse Handle(GetStoresRequest request)
        {
            var response = new GetStoresResponse();

            response.Stores = _onePosEntities.GetOnePosStores().AsEnumerable().Select(x => new Message.Model.Store
            {
                ID = (long)x["ID"],
                StoreName = x["StoreName"].ToString(),
                StoreOwnerName = x["StoreOwnerName"].ToString(),
                StoreUniqueKey = x["StoreUniqueKey"].ToString(),
                StoreAddress = x["StoreAddress"].ToString(),
                PhoneNumber = x["PhoneNumber"].ToString(),
                LicenseExpiry = x["LicenseExpiry"].ToString(),
                AdminUsername = x["AdminUsername"].ToString(),
                AdminPassword = x["AdminPassword"].ToString(),
                EmailId = x["EmailId"].ToString(),
                IsActive = (bool)x["IsActive"],
                StoreStatusId = (int)x["StoreStatus"],
                StoreTypeId=(int)x["StoreTypeId"],
                IsFirstLogin=(bool)x["IsFirstLogin"],
                StoreTypeName=x["StoreTypeName"].ToString()
            }).ToList(); 


            return response;
        }

    }
}
