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
    public class CreateStoreHandler : IRequestHandler<CreateStoreRequest, CreateStoreResponse>
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;
        public CreateStoreHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public CreateStoreResponse Handle(CreateStoreRequest request)
        {
            var response = new CreateStoreResponse();

            try
            {
                using (var context = _contextFactory.Create())
                {
                    var newStore = new OnePosStore()
                    {
                        StoreName = request.Store.StoreName,
                        StoreOwnerName = request.Store.StoreOwnerName,
                        StoreUniqueKey = request.Store.StoreUniqueKey,
                        StoreAddress = request.Store.StoreAddress,
                        PhoneNumber = request.Store.PhoneNumber,
                        LicenseExpiry = request.Store.LicenseExpiry,
                        AdminUsername = request.Store.AdminUsername,
                        AdminPassword = request.Store.AdminPassword,
                        EmailId = request.Store.EmailId,
                        IsActive = request.Store.IsActive,
                        StoreStatus = request.Store.StoreStatusId
                    };
                    context.OnePosStores.Add(newStore);
                    context.SaveChanges();
                    response.StoreId = newStore.ID;
                } 
            }
            catch (Exception ex)
            {
                response.ExceptionType = ExceptionType.Unknown;
                response.Exception = new ExceptionInfo(ex);

            }

            return response;
        }


    }
}
