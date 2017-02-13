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
   
    public class GetTaxGroupsHandler : IRequestHandler<GetTaxGroupsRequest, GetTaxGroupsResponse>
    {
        private readonly IOnePosEntities _onePosEntities;
        public GetTaxGroupsHandler(IOnePosEntities onePosEntities)
        {
            _onePosEntities = onePosEntities;
        }

        public GetTaxGroupsResponse Handle(GetTaxGroupsRequest request)
        {
            var response = new GetTaxGroupsResponse();

            response.TaxGroups = _onePosEntities.TaxGroups.Select(x => new Message.Model.TaxGroup
            {

                Id = x.Id,
                Name = x.Name,
               
                TimeStamp = x.TimeStamp
            }).ToList();

            return response;
        }

        private  dynamic  getTaxes(Guid id)
        {
            var data = _onePosEntities.TaxGroups.Where(p => p.Id == id).First().TaxConfigurations.ToList();

            //_onePosEntities.InsertCommandforTaxRelation(,);
            return data;
        }
    }
}
