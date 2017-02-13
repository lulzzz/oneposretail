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
  

    public class UpdateTaxConfigurationHandler : IRequestHandler<UpdateTaxConfigurationRequest, UpdateTaxConfigurationResponse>
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;

        public UpdateTaxConfigurationHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public UpdateTaxConfigurationResponse Handle(UpdateTaxConfigurationRequest request)
        {
            var response = new UpdateTaxConfigurationResponse();

            var taxConfigurationInfo = _onePosEntities.TaxConfigurations.FirstOrDefault(x => x.Id == request.TaxConfiguration.Id);

            taxConfigurationInfo.Name = request.TaxConfiguration.Name;
            taxConfigurationInfo.IsDeleted = request.TaxConfiguration.IsDeleted;
            taxConfigurationInfo.IsFlatFee = request.TaxConfiguration.IsFlatFee;
            taxConfigurationInfo.IsInclusiveTax = request.TaxConfiguration.IsInclusiveTax;
            taxConfigurationInfo.Rate = request.TaxConfiguration.Rate;
            taxConfigurationInfo.RunFriday = request.TaxConfiguration.RunFriday;
            taxConfigurationInfo.RunMonday = request.TaxConfiguration.RunMonday;
            taxConfigurationInfo.RunSaturday = request.TaxConfiguration.RunSaturday;
            taxConfigurationInfo.RunSunday = request.TaxConfiguration.RunSunday;
            taxConfigurationInfo.RunThursday = request.TaxConfiguration.RunThursday;
            taxConfigurationInfo.RunTuesday = request.TaxConfiguration.RunTuesday;
            taxConfigurationInfo.RunWednesday = request.TaxConfiguration.RunWednesday;
            taxConfigurationInfo.StartTime = request.TaxConfiguration.StartTime;
            taxConfigurationInfo.TimeStamp = request.TaxConfiguration.TimeStamp;

            _onePosEntities.SaveChanges();

            return response;
        }
    }
}

