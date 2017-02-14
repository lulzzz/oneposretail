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
   

    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetproductsResponse>
    {
        private readonly IOnePosEntities _onePosEntities;
        public GetProductsHandler(IOnePosEntities onePosEntities)
        {
            _onePosEntities = onePosEntities;
        }




        public GetproductsResponse Handle(GetProductsRequest request)
        {
            var response = new GetproductsResponse();

             if(request.ProductID == new Guid())
            {
                response.Products = _onePosEntities.Products.Select(x => new Message.Model.Product
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            }

           else
            {
                response.Products = _onePosEntities.Products.Where(p=>p.Id== request.ProductID).Select(x => new Message.Model.Product
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }

            

            return response;
        }

    }
}
