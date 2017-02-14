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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ManageProducts" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ManageProducts.svc or ManageProducts.svc.cs at the Solution Explorer and start debugging.
    public class ManageProducts : IManageProducts
    {

        public ProductAPIResponse CreateProduct(string ResponseFormat, ProductAPIRequest ProductInfo)
        {
            ProductAPIResponse productapiresponse = new ProductAPIResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);



            CreateProductHandler createproducthandler = new CreateProductHandler(dFactory, OnePosEntities);



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
            CreateProductRequest createproductrequest = new CreateProductRequest()
            {

                Product = new Message.Model.Product
                {

                   Name = ProductInfo.name,
                   CalorieCount = ProductInfo.caloriecount,
                   Downtick = ProductInfo.downtick,
                   Image = ProductInfo.image,
                   InclusiveTipRateId = ProductInfo.inclusivetiprateid,
                   IsActive = ProductInfo.isactive,
                   IsAgeRestrict = ProductInfo.isagerestrict,
                   IsDeleted = ProductInfo.isdeleted,
                   IsDisplayOnBilling = ProductInfo.isdisplayonbilling,
                   IsGiftCard = ProductInfo.isgiftcard,
                   LongName = ProductInfo.longname,
                   MaxFloorQty = ProductInfo.maxfloorqty,
                   MenuPosition = ProductInfo.menuposition,
                   Metaproductdata = ProductInfo.metaproductdata,
                   Plu = ProductInfo.plu,
                   Price = ProductInfo.price,
                   PriceMethod = ProductInfo.pricemethod,
                   PricePerUnitOfWeight = ProductInfo.priceperunitofweight,
                   ProductGroupPrinterId = ProductInfo.productgroupprinterid,
                   PromptForPrice = ProductInfo.promptforprice,
                   RemoveAtZeroCount = ProductInfo.removeatzerocount,
                   RevenueTypeId = ProductInfo.revenuetypeid,
                   Sku = ProductInfo.sku,
                   StoreId = ProductInfo.storeid,
                   SurchargeGroupId = ProductInfo.surchargegroupid,
                   TaxGroupId = ProductInfo.taxgroupid,
                   UnitOfWeightSize = ProductInfo.unitofweightsize,
                   Upc = ProductInfo.upc,
                   UseWeightPricing = ProductInfo.useweightpricing
            //remaing product fields.
        }



    };

            try
            {

                CreateProductResponse createproductresponse = new CreateProductResponse();
                createproductresponse = createproducthandler.Handle(createproductrequest);

                if (createproductresponse.ExceptionType == ExceptionType.None)
                {
                    productapiresponse.productid = createproductresponse.ProductId.ToString();
                    productapiresponse.statusCode = HttpStatusCode.OK;
                    productapiresponse.statusMessage = "Product created successfully.";
                }
                else
                {
                    productapiresponse.statusCode = HttpStatusCode.BadRequest;
                    productapiresponse.statusMessage = createproductresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                productapiresponse.statusCode = HttpStatusCode.BadRequest;
                productapiresponse.statusMessage = ex.Message;
            }
            return productapiresponse;
            //throw new NotImplementedException();
        }



        public ProductAPIListResponse GetProducts(string ResponseFormat, SingleEntityorA11APIRequest productInfo)
        {
            ProductAPIListResponse productapilistresponse = new ProductAPIListResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            GetProductsHandler getproductshandler = new GetProductsHandler(OnePosEntities);

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
                GetproductsResponse getproductsresponse = new GetproductsResponse();

                getproductsresponse = getproductshandler.Handle(new GetProductsRequest { ProductID= productInfo.ID==""?new Guid(): new Guid(productInfo.ID) });

                if (getproductsresponse.ExceptionType == ExceptionType.None)
                {
                    productapilistresponse.productsList = getproductsresponse.Products.Select(x => new ProductAPIRequest
                    {
                        id = x.Id,
                        name = x.Name
                    }).ToList();

                    productapilistresponse.statusCode = HttpStatusCode.OK;
                    productapilistresponse.statusMessage = "Products List";
                }
                else
                {
                    productapilistresponse.statusCode = HttpStatusCode.BadRequest;
                    productapilistresponse.statusMessage = getproductsresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                productapilistresponse.statusCode = HttpStatusCode.BadRequest;
                productapilistresponse.statusMessage = ex.Message;
            }
            return productapilistresponse;
        }
    }
    
}
