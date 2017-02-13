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
   
    public class GetSingleTaxGroupHandler : IRequestHandler<GetSingleTaxGroupRequest, GetSingleTaxGroupResponse>
    {
        private readonly IOnePosEntities _onePosEntities;
        public GetSingleTaxGroupHandler(IOnePosEntities onePosEntities)
        {
            _onePosEntities = onePosEntities;
        }

        public GetSingleTaxGroupResponse Handle(GetSingleTaxGroupRequest request)
        {
            var response = new GetSingleTaxGroupResponse();
             var id = new Guid(request.Id.ToString().ToUpper());
            var TaxGroup = _onePosEntities.TaxGroups.Where(p => p.Id == id).FirstOrDefault();
            response.TaxGroup = new Message.Model.TaxGroup();
            response.TaxGroup.Id = TaxGroup.Id;
            response.TaxGroup.Name  = TaxGroup.Name;
            response.TaxGroup.IsDeleted = TaxGroup.IsDeleted;
            response.TaxGroup.TimeStamp = TaxGroup.TimeStamp;
            
            response.TaxGroup.taxes = getTaxes(TaxGroup.Id);
           


            return response;
        }

        private List<Message.Model.TaxConfiguration> getTaxes(Guid id)
        {
            var data = _onePosEntities.TaxGroups.Where(p => p.Id == id).First().TaxConfigurations.ToList();
            
            return data.Select(item => new Message.Model.TaxConfiguration() { Id =item.Id,Name=item.Name,Rate=item.Rate }).ToList();
        }
    }

}
