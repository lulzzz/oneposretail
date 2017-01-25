using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel.Server;
using OnePos.Message;
using OnePos.Persistance;
using OnePos.Framework.ServiceModel;
using OnePos.Domain;


namespace OnePos.ServiceInterface
{
    public class UpdateStoreHandler : IRequestHandler<UpdateStoreRequest, UpdateStoreResponse>
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;

        public UpdateStoreHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public UpdateStoreResponse Handle(UpdateStoreRequest request)
        {
            var response = new UpdateStoreResponse();

            var storeInfo = _onePosEntities.OnePosStores.FirstOrDefault(x => x.ID == request.Store.ID);

            storeInfo.StoreName = request.Store.StoreName;
            storeInfo.StoreOwnerName = request.Store.StoreOwnerName;
            //storeInfo.StoreUniqueKey = request.Store.StoreUniqueKey;
            storeInfo.StoreAddress = request.Store.StoreAddress;
            storeInfo.PhoneNumber = request.Store.PhoneNumber;
            storeInfo.LicenseExpiry = request.Store.LicenseExpiry;
            //storeInfo.AdminUsername = request.Store.AdminUsername;
            //storeInfo.AdminPassword = request.Store.AdminPassword;
            storeInfo.EmailId = request.Store.EmailId;
            storeInfo.IsActive = request.Store.IsActive;

            _onePosEntities.SaveChanges();

            return response;
        }
    }
}
