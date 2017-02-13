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
    

    public class CreateTaxGroupHandler : IRequestHandler<CreateTaxGroupRequest, CreateTaxGroupResponse>
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;
        public CreateTaxGroupHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public CreateTaxGroupResponse Handle(CreateTaxGroupRequest request)
        {
            var response = new CreateTaxGroupResponse();

            try
            {
                using (
                    var context = _contextFactory.Create())
                {
                    var newTaxGroup = new TaxGroup()
                    {
                        // Id = request.TaxGroup.Id,
                        Id = Guid.NewGuid(),
                        Name = request.TaxGroup.Name,
                        IsDeleted = request.TaxGroup.IsDeleted,
                        TimeStamp = request.TaxGroup.TimeStamp
                     
                    };
                    context.TaxGroups.Add(newTaxGroup);
                    context.SaveChanges();
                    response.TaxGroupID = newTaxGroup.Id;

                        if(request.TaxGroup.taxes.Count >0)
                         _onePosEntities.InsertCommandforTaxRelation(request.TaxGroup.Id, request.TaxGroup.taxes.Select(item=> new Domain.TaxConfiguration() { Id=item.Id }).ToList());

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
