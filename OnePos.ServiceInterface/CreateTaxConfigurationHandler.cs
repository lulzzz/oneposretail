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
    

    public class CreateTaxConfigurationHandler : IRequestHandler<CreateTaxConfigurationRequest, CreateTaxConfigurationResponse>
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;
        public CreateTaxConfigurationHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public CreateTaxConfigurationResponse Handle(CreateTaxConfigurationRequest request)
        {
            var response = new CreateTaxConfigurationResponse();

            try
            {
                using (var context = _contextFactory.Create())
                {
                    var newTaxConfiguration = new TaxConfiguration()
                    {
                        //Id = request.TaxConfiguration.Id,
                        //Name = request.TaxConfiguration.Name,
                        //IsDeleted = request.TaxConfiguration.IsDeleted,
                        //TimeStamp = request.TaxConfiguration.TimeStamp,


                        Id = Guid.NewGuid(),
                        Name = request.TaxConfiguration.Name,
                        IsDeleted = request.TaxConfiguration.IsDeleted,
                        IsInclusiveTax = request.TaxConfiguration.IsInclusiveTax,
                        IsFlatFee = request.TaxConfiguration.IsFlatFee,

                        AlwaysRunTax = request.TaxConfiguration.AlwaysRunTax,
                        EndTime = request.TaxConfiguration.EndTime,
                        StartTime = request.TaxConfiguration.StartTime,
                        Rate = request.TaxConfiguration.Rate,
                        RunSunday = request.TaxConfiguration.RunSunday,
                        RunFriday = request.TaxConfiguration.RunFriday,
                        RunMonday = request.TaxConfiguration.RunMonday,
                        RunTuesday = request.TaxConfiguration.RunTuesday,
                        RunWednesday = request.TaxConfiguration.RunTuesday,
                        RunSaturday = request.TaxConfiguration.RunSaturday,
                        RunThursday = request.TaxConfiguration.RunThursday,
                        FlatFee = request.TaxConfiguration.FlatFee,
                        TimeStamp = request.TaxConfiguration.TimeStamp

                    };
                    context.TaxConfigurations.Add(newTaxConfiguration);
                    context.SaveChanges();
                    response.TaxConfigurationID = newTaxConfiguration.Id;
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
