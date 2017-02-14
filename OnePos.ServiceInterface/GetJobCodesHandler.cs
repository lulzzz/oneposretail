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
    
    public class GetJobCodesHandler : IRequestHandler<GetJobCodesRequest, GetJobCodesResponse>
    {
        private readonly IOnePosEntities _onePosEntities;
        public GetJobCodesHandler(IOnePosEntities onePosEntities)
        {
            _onePosEntities = onePosEntities;
        }




        public GetJobCodesResponse Handle(GetJobCodesRequest request)
        {
            var response = new GetJobCodesResponse();

            response.Jobcodes = _onePosEntities.JobCodes.Select(x => new Message.Model.JobCode
            {
                Id = x.Id,
                Name= x.Name
            }).ToList();

            return response;
        }

    }
}

