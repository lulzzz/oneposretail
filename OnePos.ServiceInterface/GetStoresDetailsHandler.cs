using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel.Server;
using OnePos.Message;
using OnePos.Message.Model;
using OnePos.Persistance;
using OnePos.Framework.ServiceModel; 
using System.Data;

namespace OnePos.ServiceInterface
{
    public class GetStoreDetailsHandler : IRequestHandler<GetStoreDetailsRequest, GetStoreDetailsResponse>
    { 
        private readonly IOnePosEntities _onePosEntities;
        public GetStoreDetailsHandler(IOnePosEntities onePosEntities)
        { 
            _onePosEntities = onePosEntities;
        }

        public GetStoreDetailsResponse Handle(GetStoreDetailsRequest request)
        {
            var response = new GetStoreDetailsResponse();

            if (!string.IsNullOrEmpty(request.UserName) && !string.IsNullOrEmpty(request.Password))
            {
                response.StoreDetails = _onePosEntities.GetOnePosStores().AsEnumerable().Where(x => (x["AdminUsername"].ToString() == request.UserName) & (x["AdminPassword"].ToString() == request.Password) & ((int)x["StoreStatus"] == (int)Domain.OnePosStoreStatusEnum.SetupCompleted)).Select(x => new Store
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
                    StoreStatusId = (int)x["StoreStatus"]
                }).FirstOrDefault();
            }
            else if (!string.IsNullOrEmpty(request.UniqueKey))
            {
                response.StoreDetails = _onePosEntities.GetOnePosStores().AsEnumerable().Where(x => (x["StoreUniqueKey"].ToString() == request.UniqueKey) & ((int)x["StoreStatus"] == (int)Domain.OnePosStoreStatusEnum.SetupCompleted)).Select(x => new Store
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
                    StoreStatusId = (int)x["StoreStatus"]
                }).FirstOrDefault();
            }
            else {
                return null;
            }
            return response;
        }

    }
}
