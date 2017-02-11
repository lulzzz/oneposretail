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
        private string _dataSourceName;
        private string _databaseName;

        public UpdateStoreHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities, string dataSourceName=null, string databaseName=null)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
            _dataSourceName = dataSourceName;
            _databaseName = databaseName;
        }

        public UpdateStoreResponse Handle(UpdateStoreRequest request)
        {
            var response = new UpdateStoreResponse(); 
            var storeInfo = _onePosEntities.UpdateStore(new Store
            {
                 ID=request.Store.ID,
                StoreName = request.Store.StoreName,
                StoreOwnerName = request.Store.StoreOwnerName,
                //StoreUniqueKey = request.Store.StoreUniqueKey,
                StoreAddress = request.Store.StoreAddress,
                PhoneNumber = request.Store.PhoneNumber,
                LicenseExpiry = request.Store.LicenseExpiry,
                //AdminUsername = request.Store.AdminUsername,
                //AdminPassword = request.Store.AdminPassword,
                EmailId = request.Store.EmailId,
                IsActive = request.Store.IsActive,
                //IsFirstLogin = request.Store.IsFirstLogin,
                //StoreStatusId = request.Store.StoreStatusId
            });

            if (storeInfo == false)
            {
                response.ExceptionType = ExceptionType.Unknown;
                response.Exception = new ExceptionInfo(new Exception("Store update failed."));
            }

            return response;
        }
    }
}
