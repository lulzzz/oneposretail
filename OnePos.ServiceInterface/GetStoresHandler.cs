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

            response.Stores = _onePosEntities.OnePosStores.Select(x => new Store
            {
                ID = x.ID,
                StoreName = x.StoreName,
                StoreOwnerName = x.StoreOwnerName,
                StoreUniqueKey = x.StoreUniqueKey,
                StoreAddress = x.StoreAddress,
                PhoneNumber = x.PhoneNumber,
                LicenseExpiry = x.LicenseExpiry,
                AdminUsername = x.AdminUsername,
                AdminPassword = x.AdminPassword,
                EmailId = x.EmailId,
                IsActive = (bool)x.IsActive,
                StoreStatusId = (int)x.StoreStatus
            }).ToList();

            return response;
        }

    }
}
