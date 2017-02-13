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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ManageTaxes" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ManageTaxes.svc or ManageTaxes.svc.cs at the Solution Explorer and start debugging.
    public class ManageTaxes : IManageTaxes
    {
        public TaxConfigurationAPIResponse CreateTaxConfiguration(string ResponseFormat, TaxConfigurationAPIRequest taxconfigurationinfo)
        {
            TaxConfigurationAPIResponse taxconfrigurationapiresponse = new TaxConfigurationAPIResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);



            CreateTaxConfigurationHandler createtaxconfigurationhandler = new CreateTaxConfigurationHandler(dFactory, OnePosEntities);



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

            /// TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            CreateTaxConfigurationRequest createtaxconfigurationrequest = new CreateTaxConfigurationRequest()
            {

                TaxConfiguration = new Message.Model.TaxConfiguration
                {
                  //  Id = taxconfigurationinfo.id,
                    Name = taxconfigurationinfo.name,
                    IsDeleted = taxconfigurationinfo.isdeleted,
                    IsInclusiveTax = taxconfigurationinfo.isinclusivetax,
                    IsFlatFee = taxconfigurationinfo.isinclusivetax,
                    AlwaysRunTax = taxconfigurationinfo.alwaysruntax,
                    EndTime = taxconfigurationinfo.endtime,
                    StartTime = taxconfigurationinfo.starttime,
                    Rate = taxconfigurationinfo.rate,
                    RunSunday = taxconfigurationinfo.runsunday,
                    RunFriday = taxconfigurationinfo.runfriday,
                    RunMonday = taxconfigurationinfo.runmonday,
                    RunTuesday = taxconfigurationinfo.runtuesday,
                    RunWednesday = taxconfigurationinfo.runwednesday,
                    RunSaturday = taxconfigurationinfo.runsaturday,
                    RunThursday = taxconfigurationinfo.runthursday,
                    FlatFee = taxconfigurationinfo.flatfee,
                    TimeStamp = taxconfigurationinfo.timestamp

                }


               
            };

            try
            {

                CreateTaxConfigurationResponse createtaxconfigurationresponse = new CreateTaxConfigurationResponse();
                createtaxconfigurationresponse = createtaxconfigurationhandler.Handle(createtaxconfigurationrequest);

                if (createtaxconfigurationresponse.ExceptionType == ExceptionType.None)
                {
                    taxconfrigurationapiresponse.taxconfigurationid = createtaxconfigurationresponse.TaxConfigurationID;
                    taxconfrigurationapiresponse.statusCode = HttpStatusCode.OK;
                    taxconfrigurationapiresponse.statusMessage = "Taxes created successfully.";
                }
                else
                {
                    taxconfrigurationapiresponse.statusCode = HttpStatusCode.BadRequest;
                    taxconfrigurationapiresponse.statusMessage = createtaxconfigurationresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                taxconfrigurationapiresponse.statusCode = HttpStatusCode.BadRequest;
                taxconfrigurationapiresponse.statusMessage = ex.Message;
            }
            return taxconfrigurationapiresponse;
        }

        public TaxConfigurationAPIListResponse GetTaxConfigurations(string ResponseFormat)
        {
            TaxConfigurationAPIListResponse taxconfigurationapilistresponse = new TaxConfigurationAPIListResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            GetTaxConfigurationsHandler gettaxconfigurationshandler = new GetTaxConfigurationsHandler(OnePosEntities);

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
                GetTaxConfigurationsResponse gettaxconfigurationsresponse = new GetTaxConfigurationsResponse();

                gettaxconfigurationsresponse = gettaxconfigurationshandler.Handle(new GetTaxConfigurationsRequest() { });

                if (gettaxconfigurationsresponse.ExceptionType == ExceptionType.None)
                {
                    taxconfigurationapilistresponse.taxconfigurationList = gettaxconfigurationsresponse.TaxConfigurations.Select(x => new TaxConfigurationAPIRequest
                    {
                        id = x.Id,
                        name = x.Name
                    }).ToList();

                    taxconfigurationapilistresponse.statusCode = HttpStatusCode.OK;
                    taxconfigurationapilistresponse.statusMessage = "Taxes List";
                }
                else
                {
                    taxconfigurationapilistresponse.statusCode = HttpStatusCode.BadRequest;
                    taxconfigurationapilistresponse.statusMessage = gettaxconfigurationsresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                taxconfigurationapilistresponse.statusCode = HttpStatusCode.BadRequest;
                taxconfigurationapilistresponse.statusMessage = ex.Message;
            }
            return taxconfigurationapilistresponse;
            // throw new NotImplementedException();
        }

        public TaxConfigurationAPIResponse UpdateTaxConfiguration(string ResponseFormat, TaxConfigurationAPIRequest taxconfigurationinfo)
        {
            TaxConfigurationAPIResponse taxconfrigurationapiresponse = new TaxConfigurationAPIResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);



            UpdateTaxConfigurationHandler updatetaxconfigurationhandler = new UpdateTaxConfigurationHandler(dFactory, OnePosEntities);



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

            /// TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            UpdateTaxConfigurationRequest updatetaxconfigurationrequest = new UpdateTaxConfigurationRequest()
            {

                TaxConfiguration = new Message.Model.TaxConfiguration
                {
                    Id = taxconfigurationinfo.id,
                    Name = taxconfigurationinfo.name,
                    IsDeleted = taxconfigurationinfo.isdeleted,
                    IsInclusiveTax = taxconfigurationinfo.isinclusivetax,
                    IsFlatFee = taxconfigurationinfo.isinclusivetax,
                    AlwaysRunTax = taxconfigurationinfo.alwaysruntax,
                    EndTime = taxconfigurationinfo.endtime,
                    StartTime = taxconfigurationinfo.starttime,
                    Rate = taxconfigurationinfo.rate,
                    RunSunday = taxconfigurationinfo.runsunday,
                    RunFriday = taxconfigurationinfo.runfriday,
                    RunMonday = taxconfigurationinfo.runmonday,
                    RunTuesday = taxconfigurationinfo.runtuesday,
                    RunWednesday = taxconfigurationinfo.runwednesday,
                    RunSaturday = taxconfigurationinfo.runsaturday,
                    RunThursday = taxconfigurationinfo.runthursday,
                    FlatFee = taxconfigurationinfo.flatfee,
                    TimeStamp = taxconfigurationinfo.timestamp

                }
            };

            try
            {

                UpdateTaxConfigurationResponse updatetaxconfigurationresponse = new UpdateTaxConfigurationResponse();
                updatetaxconfigurationresponse = updatetaxconfigurationhandler.Handle(updatetaxconfigurationrequest);

                if (updatetaxconfigurationresponse.ExceptionType == ExceptionType.None)
                {
                    //taxconfrigurationapiresponse.storeid = new Guid();
                    taxconfrigurationapiresponse.statusCode = HttpStatusCode.OK;
                    taxconfrigurationapiresponse.statusMessage = "Tax Configuration Updated Successfully.";
                }
                else
                {
                    taxconfrigurationapiresponse.statusCode = HttpStatusCode.BadRequest;
                    taxconfrigurationapiresponse.statusMessage = updatetaxconfigurationresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                taxconfrigurationapiresponse.statusCode = HttpStatusCode.BadRequest;
                taxconfrigurationapiresponse.statusMessage = ex.Message;
            }
            return taxconfrigurationapiresponse;
        }




        public TaxGroupAPIResponse CreateTaxGroup(string ResponseFormat, TaxGroupAPIRequest taxgroupinfo)
        {
            TaxGroupAPIResponse taxgroupapiresponse = new TaxGroupAPIResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);



            CreateTaxGroupHandler createtaxconfigurationhandler = new CreateTaxGroupHandler(dFactory, OnePosEntities);



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

            /// TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            CreateTaxGroupRequest createtaxconfigurationrequest = new CreateTaxGroupRequest()
            {

                TaxGroup = new Message.Model.TaxGroup
                {
                   // Id = taxgroupinfo.id,
                    Name = taxgroupinfo.name,
                    IsDeleted = taxgroupinfo.isdeleted,
                    taxes = taxgroupinfo.taxes.Select(item=> new Message.Model.TaxConfiguration { Id=item.id}).ToList(),
                    TimeStamp = taxgroupinfo.timestamp

                }

                

            };

           // var data = taxgroupinfo.taxes["id"];

            try
            {

                CreateTaxGroupResponse createtaxconfigurationresponse = new CreateTaxGroupResponse();
                createtaxconfigurationresponse = createtaxconfigurationhandler.Handle(createtaxconfigurationrequest);

                if (createtaxconfigurationresponse.ExceptionType == ExceptionType.None)
                {
                    taxgroupapiresponse.taxgroupid = createtaxconfigurationresponse.TaxGroupID;
                    taxgroupapiresponse.statusCode = HttpStatusCode.OK;
                    taxgroupapiresponse.statusMessage = "Tax Group created successfully.";
                }
                else
                {
                    taxgroupapiresponse.statusCode = HttpStatusCode.BadRequest;
                    taxgroupapiresponse.statusMessage = createtaxconfigurationresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                taxgroupapiresponse.statusCode = HttpStatusCode.BadRequest;
                taxgroupapiresponse.statusMessage = ex.Message;
            }
            return taxgroupapiresponse;
        }

        public SingleTaxGroupAPIListResponse GetSingleTaxGroup(string ResponseFormat, Guid ID)
        {
            SingleTaxGroupAPIListResponse taxconfigurationapilistresponse = new SingleTaxGroupAPIListResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            GetSingleTaxGroupHandler gettaxconfigurationshandler = new GetSingleTaxGroupHandler(OnePosEntities);

            GetSingleTaxGroupRequest getsingletaxgrouprequest = new GetSingleTaxGroupRequest();
            getsingletaxgrouprequest.Id = ID;

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
                GetSingleTaxGroupResponse gettaxconfigurationsresponse = new GetSingleTaxGroupResponse();

                gettaxconfigurationsresponse = gettaxconfigurationshandler.Handle(getsingletaxgrouprequest);

                if (gettaxconfigurationsresponse.ExceptionType == ExceptionType.None)
                {
                    taxconfigurationapilistresponse.taxGroup = new TaxGroupAPIRequest();
                    taxconfigurationapilistresponse.taxGroup.id = gettaxconfigurationsresponse.TaxGroup.Id;
                    taxconfigurationapilistresponse.taxGroup.name = gettaxconfigurationsresponse.TaxGroup.Name;
                    taxconfigurationapilistresponse.taxGroup.taxes = gettaxconfigurationsresponse.TaxGroup.taxes.Select(item=> new TaxConfigurationAPIRequest() { id=item.Id,name=item.Name,rate = item.Rate}).ToList();
                    taxconfigurationapilistresponse.taxGroup.timestamp = gettaxconfigurationsresponse.TaxGroup.TimeStamp;


                    taxconfigurationapilistresponse.statusCode = HttpStatusCode.OK;
                    taxconfigurationapilistresponse.statusMessage = "Tax Groups List";
                }
                else
                {
                    taxconfigurationapilistresponse.statusCode = HttpStatusCode.BadRequest;
                    taxconfigurationapilistresponse.statusMessage = gettaxconfigurationsresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                taxconfigurationapilistresponse.statusCode = HttpStatusCode.BadRequest;
                taxconfigurationapilistresponse.statusMessage = ex.Message;
            }
            return taxconfigurationapilistresponse;
        }

        public TaxGroupAPIListResponse GetTaxGroups(string ResponseFormat)
        {
            TaxGroupAPIListResponse taxconfigurationapilistresponse = new TaxGroupAPIListResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            GetTaxGroupsHandler gettaxconfigurationshandler = new GetTaxGroupsHandler(OnePosEntities);

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
                GetTaxGroupsResponse gettaxconfigurationsresponse = new GetTaxGroupsResponse();

                gettaxconfigurationsresponse = gettaxconfigurationshandler.Handle(new GetTaxGroupsRequest() { });

                if (gettaxconfigurationsresponse.ExceptionType == ExceptionType.None)
                {
                    taxconfigurationapilistresponse.taxGroupList = gettaxconfigurationsresponse.TaxGroups.Select(x => new TaxGroupAPIRequest
                    {
                        id = x.Id,
                        name = x.Name,
                       // taxes =x.taxes
                        
                    }).ToList();

                    taxconfigurationapilistresponse.statusCode = HttpStatusCode.OK;
                    taxconfigurationapilistresponse.statusMessage = "Tax Groups List";
                }
                else
                {
                    taxconfigurationapilistresponse.statusCode = HttpStatusCode.BadRequest;
                    taxconfigurationapilistresponse.statusMessage = gettaxconfigurationsresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                taxconfigurationapilistresponse.statusCode = HttpStatusCode.BadRequest;
                taxconfigurationapilistresponse.statusMessage = ex.Message;
            }
            return taxconfigurationapilistresponse;
            // throw new NotImplementedException();
        }

        public TaxGroupAPIResponse UpdateTaxGroup(string ResponseFormat, TaxGroupAPIRequest taxconfigurationinfo)
        {
            TaxGroupAPIResponse taxgroupapiresponse = new TaxGroupAPIResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);



            UpdateTaxGroupHandler updatetaxconfigurationhandler = new UpdateTaxGroupHandler(dFactory, OnePosEntities);



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

            /// TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            UpdateTaxGroupRequest updatetaxconfigurationrequest = new UpdateTaxGroupRequest()
            {

                TaxGroup = new Message.Model.TaxGroup
                {
                    Id = taxconfigurationinfo.id,
                    Name = taxconfigurationinfo.name,
                    IsDeleted = taxconfigurationinfo.isdeleted,
                    TimeStamp = taxconfigurationinfo.timestamp

                }
            };

            try
            {

                UpdateTaxGroupResponse updatetaxconfigurationresponse = new UpdateTaxGroupResponse();
                updatetaxconfigurationresponse = updatetaxconfigurationhandler.Handle(updatetaxconfigurationrequest);

                if (updatetaxconfigurationresponse.ExceptionType == ExceptionType.None)
                {
                   // taxgroupapiresponse.taxgroupid = ""
                    taxgroupapiresponse.statusCode = HttpStatusCode.OK;
                    taxgroupapiresponse.statusMessage = "Tax Configuration Updated Successfully.";
                }
                else
                {
                    taxgroupapiresponse.statusCode = HttpStatusCode.BadRequest;
                    taxgroupapiresponse.statusMessage = updatetaxconfigurationresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                taxgroupapiresponse.statusCode = HttpStatusCode.BadRequest;
                taxgroupapiresponse.statusMessage = ex.Message;
            }
            return taxgroupapiresponse;
        }

       
    }
}
