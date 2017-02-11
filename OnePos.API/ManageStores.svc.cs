using System; 
using System.Data; 
using System.Linq;
using System.Net; 
using System.ServiceModel.Web; 
using OnePos.Domain;
using OnePos.Domain.Encryption;
using OnePos.Message;
using OnePos.Persistance;
using OnePos.ServiceInterface;
using System.ServiceModel.Activation; 
using OnePos.Framework.Domain;
using OnePos.Framework.ServiceModel;
using OnePos.Framework.Extensions; 
using OnePos.API.Models;
using OnePos.Framework;
using OnePos.Message.Model;
using OnePos.MessageService;

namespace OnePos.API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ManageStores" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ManageStores.svc or ManageStores.svc.cs at the Solution Explorer and start debugging.

    [AspNetCompatibilityRequirements(
       RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ManageStores : IManageStores
    { 
        public StoreAPIResponse CreateStore(string ResponseFormat, StoreAPIRequest storeInfo)
        {
            StoreAPIResponse storeapiresponse = new StoreAPIResponse();
            var connString = "";// "onepos_bba4a354_f4b3_4d57_b370_a6fd011de4dd_MainDB";// @"metadata=res://*/OnePosModel.csdl|res://*/OnePosModel.ssdl|res://*/OnePosModel.msl;provider=System.Data.SqlClient;provider connection string='Data Source = himasankar - pc; Initial Catalog = onepos_bba4a354_f4b3_4d57_b370_a6fd011de4dd_MainDB; Integrated Security = True; MultipleActiveResultSets = True'";
             
            //IOnePosEntities OnePosEntitiesCopy = new OnePosEntities(dConn2, false); 
            IOnePosEntities OnePosEntitiesCopy = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default); 
            CreateStoreHandler createstorehandler = new CreateStoreHandler(dFactory, OnePosEntitiesCopy);

            if (ResponseFormat.ToLower() == "json")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
            else if (ResponseFormat.ToLower() == "xml")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }

            TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            var stroreUniqueKey = GenerateAPIKey();
            var adminUserName = storeInfo.emailid;
            var adminPassword = RandomString(9);
            CreateStoreRequest createstorerequest = new CreateStoreRequest()
            {
                Store = new Message.Model.Store
                {
                    StoreName = storeInfo.storename,
                    StoreOwnerName = storeInfo.storeownername,
                    StoreUniqueKey = stroreUniqueKey,
                    StoreAddress = storeInfo.storeaddress,
                    PhoneNumber = storeInfo.phonenumber,
                    LicenseExpiry = Encrypt.Encrypt(storeInfo.licenseexpiry),
                    AdminUsername = adminUserName,
                    AdminPassword = Encrypt.Encrypt(adminPassword),
                    EmailId = storeInfo.emailid,
                    IsActive = !string.IsNullOrEmpty(storeInfo.isactive) ? Convert.ToBoolean(storeInfo.isactive) : false,
                    IsFirstLogin = true,
                    StoreStatusId = (int)OnePosStoreStatusEnum.Queued,
                    StoreTypeId = storeInfo.storetypeid
                },
                StoreAccessModules = new Message.Model.StoreAccessModules
                {
                    IsInventoryAccess = true,
                    IsProductManagementAccess = true,
                    IsReportsAccess = false,
                    IsTimeSheetManagementAccess = false,
                    IsUserManagementAccess = true,
                    NumberOfBranchesAllow = 5
                }
            };

            try {

                CreateStoreResponse createstoreresponse = new CreateStoreResponse();
                createstoreresponse = createstorehandler.Handle(createstorerequest);

                if (createstoreresponse.ExceptionType == ExceptionType.None)
                {
                    storeapiresponse.storeid = createstoreresponse.StoreId; 
                    storeapiresponse.statusCode = HttpStatusCode.OK;
                    storeapiresponse.statusMessage = "Store created successfully.";

                }
                else
                {
                    storeapiresponse.statusCode = HttpStatusCode.BadRequest;
                    storeapiresponse.statusMessage = createstoreresponse.Exception.Message;
                }

            } catch (Exception ex) {
                storeapiresponse.statusCode = HttpStatusCode.BadRequest;
                storeapiresponse.statusMessage = ex.Message;
            }  
            return storeapiresponse; 
        }

        public StoreAPIResponse UpdateStore(string ResponseFormat, StoreAPIRequest storeInfo)
        {
            StoreAPIResponse storeapiresponse = new StoreAPIResponse();
            //IOnePosEntities OnePosEntities = new OnePosEntities(@"metadata=res://*/OnePosModel.csdl|res://*/OnePosModel.ssdl|res://*/OnePosModel.msl;provider=System.Data.SqlClient;provider connection string='Data Source = himasankar - pc; Initial Catalog = onepos_bba4a354_f4b3_4d57_b370_a6fd011de4dd_MainDB; Integrated Security = True; MultipleActiveResultSets = True'");
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);
            UpdateStoreHandler updateStoreHandler = new UpdateStoreHandler(dFactory, OnePosEntities);

            if (ResponseFormat.ToLower() == "json")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
            else if (ResponseFormat.ToLower() == "xml")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }

            TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            UpdateStoreRequest updatestorerequest = new UpdateStoreRequest()
            {
                Store = new Message.Model.Store
                {
                    ID=storeInfo.id,
                    StoreName = storeInfo.storename,
                    StoreOwnerName = storeInfo.storeownername,
                    //StoreUniqueKey = GenerateAPIKey(),
                    StoreAddress = storeInfo.storeaddress,
                    PhoneNumber = storeInfo.phonenumber,
                    LicenseExpiry = Encrypt.Encrypt(storeInfo.licenseexpiry),
                    //AdminUsername = Encrypt.Encrypt("admin"), //NEED TO GENERATE THIS USERNAME AND PASSWORD
                    //AdminPassword = Encrypt.Encrypt("admin"),
                    //EmailId = storeInfo.emailid,
                    IsActive = !string.IsNullOrEmpty(storeInfo.isactive) ? Convert.ToBoolean(storeInfo.isactive) : false
                }
            };

            try
            {

                UpdateStoreResponse updatestoreresponse = new UpdateStoreResponse();
                updatestoreresponse = updateStoreHandler.Handle(updatestorerequest);

                if (updatestoreresponse.ExceptionType == ExceptionType.None)
                { 
                    storeapiresponse.statusCode = HttpStatusCode.OK;
                    storeapiresponse.statusMessage = "Store updated successfully.";
                }
                else
                {
                    storeapiresponse.statusCode = HttpStatusCode.BadRequest;
                    storeapiresponse.statusMessage = updatestoreresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                storeapiresponse.statusCode = HttpStatusCode.BadRequest;
                storeapiresponse.statusMessage = ex.Message;
            }
            return storeapiresponse;
        }

        public StoreListResponse GetStores(string ResponseFormat)
        {
            var connString = "onepos_bba4a354_f4b3_4d57_b370_a6fd011de4dd_MainDB";// @"metadata=res://*/OnePosModel.csdl|res://*/OnePosModel.ssdl|res://*/OnePosModel.msl;provider=System.Data.SqlClient;provider connection string='Data Source = himasankar - pc; Initial Catalog = onepos_bba4a354_f4b3_4d57_b370_a6fd011de4dd_MainDB; Integrated Security = True; MultipleActiveResultSets = True'";

            StoreListResponse storeapiresponse = new StoreListResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();


            GetStoresHandler getstoreshandler = new GetStoresHandler(OnePosEntities);

            if (ResponseFormat.ToLower() == "json")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
            else if (ResponseFormat.ToLower() == "xml")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }

            TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption(); 
            try
            {

                GetStoresResponse getstoresresponse = new GetStoresResponse();
                getstoresresponse = getstoreshandler.Handle(new GetStoresRequest() { });

                if (getstoresresponse.ExceptionType == ExceptionType.None)
                {
                    storeapiresponse.storesList = getstoresresponse.Stores.Select(x => new StoreAPIRequest
                    {
                        id = x.ID,
                        storename = x.StoreName,
                        storeownername = x.StoreOwnerName,
                        storeuniquekey = x.StoreUniqueKey,
                        storeaddress = x.StoreAddress,
                        phonenumber = x.PhoneNumber,
                        licenseexpiry = Encrypt.Decrypt(x.LicenseExpiry), 
                        emailid = x.EmailId,
                        isactive = x.IsActive.ToString(),
                        storetypeid=x.StoreTypeId,
                        storetypename=x.StoreTypeName,
                        StoreStatus= EnumExtensions.GetDescription((OnePosStoreStatusEnum)x.StoreStatusId),
                }).ToList();

                    storeapiresponse.statusCode = HttpStatusCode.OK;
                    storeapiresponse.statusMessage = "Stores List";
                }
                else
                {
                    storeapiresponse.statusCode = HttpStatusCode.BadRequest;
                    storeapiresponse.statusMessage = getstoresresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                storeapiresponse.statusCode = HttpStatusCode.BadRequest;
                storeapiresponse.statusMessage = ex.Message;
            }
            return storeapiresponse;
        }

        public StoreTypeResponse GetStoreTypes(string ResponseFormat)
        {

            StoreTypeResponse storetyperesponse = new StoreTypeResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();


            GetStoreTypesHandler getstoretypeshandler = new GetStoreTypesHandler(OnePosEntities);

            if (ResponseFormat.ToLower() == "json")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
            else if (ResponseFormat.ToLower() == "xml")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }

            TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            try
            {

                GetStoreTypesResponse getstoretypesresponse = new GetStoreTypesResponse();
                getstoretypesresponse = getstoretypeshandler.Handle(new GetStoreTypesRequest() { });

                if (getstoretypesresponse.ExceptionType == ExceptionType.None)
                {
                    storetyperesponse.storetypes = getstoretypesresponse.StoreTypes.Select(x => new StoreTypes
                    {
                        stroretypeid=x.StoreTypeId,
                         storetypename=x.StoreName,
                          storetypedescription=x.StoreDescription
                    }).ToList();

                    storetyperesponse.statusCode = HttpStatusCode.OK;
                    storetyperesponse.statusMessage = "Stores Types List";
                }
                else
                {
                    storetyperesponse.statusCode = HttpStatusCode.BadRequest;
                    storetyperesponse.statusMessage = getstoretypesresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                storetyperesponse.statusCode = HttpStatusCode.BadRequest;
                storetyperesponse.statusMessage = ex.Message;
            }
            return storetyperesponse;
        }

        public virtual string GenerateAPIKey()
        {
            IUniqueIdentifierGenerator ib = new GuidCombGenerator();
            string KeyString = ib.GenerateNewId().ToString();
            return KeyString;
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
