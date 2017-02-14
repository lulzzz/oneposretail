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
    public class UpdateJobCodeHandler : IRequestHandler<UpdateJobCodeRequest, UpdateJobCodeResponse>
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;

        public UpdateJobCodeHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public UpdateJobCodeResponse Handle(UpdateJobCodeRequest request)
        {
            var response = new UpdateJobCodeResponse();

            var jobcodeInfo = _onePosEntities.JobCodes.FirstOrDefault(x => x.Id == request.jobcode.Id);

            jobcodeInfo.Name = request.jobcode.Name;
            jobcodeInfo.IsDeleted = request.jobcode.IsDeleted;
            //jobcodeInfo.JobType = request.jobcode.JobType;

           





            _onePosEntities.SaveChanges();

            return response;
        }
    }
}
