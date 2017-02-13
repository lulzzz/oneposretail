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
   


    public class GetTaxConfigurationsHandler : IRequestHandler<GetTaxConfigurationsRequest, GetTaxConfigurationsResponse>
    {
        private readonly IOnePosEntities _onePosEntities;
        public GetTaxConfigurationsHandler(IOnePosEntities onePosEntities)
        {
            _onePosEntities = onePosEntities;
        }

        public GetTaxConfigurationsResponse Handle(GetTaxConfigurationsRequest request)
        {
            var response = new GetTaxConfigurationsResponse();

            response.TaxConfigurations = _onePosEntities.TaxConfigurations.Select(x => new Message.Model.TaxConfiguration
            {
            Id = x.Id,
            Name = x.Name,
            IsDeleted = x.IsDeleted,
            IsFlatFee = x.IsFlatFee,
            IsInclusiveTax = x.IsInclusiveTax,
            Rate = x.Rate,
            RunFriday = x.RunFriday,
            RunMonday = x.RunMonday,
            RunSaturday = x.RunSaturday,
            RunSunday = x.RunSunday,
            RunThursday = x.RunThursday,
            RunTuesday = x.RunTuesday,
            RunWednesday = x.RunWednesday,
            StartTime = x.StartTime,
            TimeStamp = x.TimeStamp
            }).ToList();

            return response;
        }
    }
}
