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
using OnePos.Framework.Domain;
using OnePos.Framework.ServiceModel;
using OnePos.Framework.Extensions;

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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ManageStores" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ManageStores.svc or ManageStores.svc.cs at the Solution Explorer and start debugging.

    [AspNetCompatibilityRequirements(
       RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ManageStores : IManageStores
    {
        public StoreAPIResponse CreateStore(string ResponseFormat, StoreAPIRequest storeInfo)
        {
            StoreAPIResponse storeapiresponse = new StoreAPIResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);
            CreateStoreHandler createProductHandler = new CreateStoreHandler(dFactory, OnePosEntities);

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
            CreateStoreRequest createstorerequest = new CreateStoreRequest()
            {
                Store = new Store
                {
                    StoreName = storeInfo.storename,
                    StoreOwnerName = storeInfo.storeownername,
                    StoreUniqueKey = GenerateAPIKey(),
                    StoreAddress = storeInfo.storeaddress,
                    PhoneNumber = storeInfo.phonenumber,
                    LicenseExpiry = Encrypt.Encrypt(storeInfo.licenseexpiry),
                    AdminUsername = Encrypt.Encrypt("admin"), //NEED TO GENERATE THIS USERNAME AND PASSWORD
                    AdminPassword = Encrypt.Encrypt("admin"),
                    EmailId = storeInfo.emailid,
                    IsActive = !string.IsNullOrEmpty(storeInfo.isactive) ? Convert.ToBoolean(storeInfo.isactive) : false,
                    StoreStatusId = (int)OnePosStoreStatusEnum.Queued
                }
            };

            try {

                CreateStoreResponse createstoreresponse = new CreateStoreResponse();
                createstoreresponse = createProductHandler.Handle(createstorerequest);

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
                Store = new Store
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
                    EmailId = storeInfo.emailid,
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
                        adminusername = Encrypt.Decrypt(x.AdminUsername),
                        adminpassword = Encrypt.Decrypt(x.AdminPassword),
                        emailid = x.EmailId,
                        isactive = x.IsActive.ToString(),
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

        public virtual string GenerateAPIKey()
        {
            IUniqueIdentifierGenerator ib = new GuidCombGenerator();
            string KeyString = ib.GenerateNewId().ToString();
            return KeyString;
        }
    }
}
