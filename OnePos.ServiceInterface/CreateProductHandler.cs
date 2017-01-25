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
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;
        public CreateProductHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public CreateProductResponse Handle(CreateProductRequest request)
        {
            var response = new CreateProductResponse();

            try
            {
                using (var context = _contextFactory.Create())
                {
                    var newProduct = new Product();
                    newProduct.Name = request.Product.Name;  
                    //remaing product fields.
                    
                    context.Products.Add(newProduct);
                    context.SaveChanges(); 
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
