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
        private string _dataSourceName;
        private string _databaseName;
        public CreateStoreHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities,string dataSourceName=null, string databaseName=null)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
            _dataSourceName = dataSourceName;
            _databaseName = databaseName;
        }

        public CreateStoreResponse Handle(CreateStoreRequest request)
        {
            var response = new CreateStoreResponse(); 
            try
            {
                var storeId = _onePosEntities.CreateStore(new Store {
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
                    IsFirstLogin = request.Store.IsFirstLogin,
                    StoreStatusId = request.Store.StoreStatusId,
                    StoreTypeId=request.Store.StoreTypeId
                });
                response.StoreId = storeId;
                if (storeId == 0)
                {
                    response.ExceptionType = ExceptionType.Unknown;
                    response.Exception = new ExceptionInfo(new Exception("Store creations failed."));
                }
                else {
                    var storeAccessModule = _onePosEntities.CreateStoreAccessModules(new StoreAccessModules
                    {
                        StoreId = storeId,
                        IsInventoryAccess = request.StoreAccessModules.IsInventoryAccess,
                        IsProductManagementAccess = request.StoreAccessModules.IsProductManagementAccess,
                        IsReportsAccess = request.StoreAccessModules.IsReportsAccess,
                        IsTimeSheetManagementAccess = request.StoreAccessModules.IsTimeSheetManagementAccess,
                        IsUserManagementAccess = request.StoreAccessModules.IsUserManagementAccess,
                        NumberOfBranchesAllow = request.StoreAccessModules.NumberOfBranchesAllow
                    });
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
