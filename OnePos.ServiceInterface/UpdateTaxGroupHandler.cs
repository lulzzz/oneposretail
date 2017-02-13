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
   

    public class UpdateTaxGroupHandler : IRequestHandler<UpdateTaxGroupRequest, UpdateTaxGroupResponse>
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;

        public UpdateTaxGroupHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public UpdateTaxGroupResponse Handle(UpdateTaxGroupRequest request)
        {
            var response = new UpdateTaxGroupResponse();

            var taxGroupInfo = _onePosEntities.TaxGroups.FirstOrDefault(x => x.Id == request.TaxGroup.Id);

            taxGroupInfo.Name = request.TaxGroup.Name;
            taxGroupInfo.IsDeleted = request.TaxGroup.IsDeleted;
            taxGroupInfo.TimeStamp = request.TaxGroup.TimeStamp;
           


            _onePosEntities.SaveChanges();

            return response;
        }
    }
}

