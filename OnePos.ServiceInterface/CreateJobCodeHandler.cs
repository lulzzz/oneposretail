using OnePos.Framework.ServiceModel.Server;
using System;
using OnePos.Message;
using OnePos.Persistance;
using OnePos.Framework.ServiceModel;
using OnePos.Domain;

namespace OnePos.ServiceInterface
{
   public class CreateJobCodeHandler : IRequestHandler<CreateJobCodeRequest, CreateJobCodeResponse>
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;
        public CreateJobCodeHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public CreateJobCodeResponse Handle(CreateJobCodeRequest request)
        {
            var response = new CreateJobCodeResponse();

            try
            {
                using (var context = _contextFactory.Create())
                {
                    var jC = (int)request.JobCode.JobType;

                    var newJobCode = new JobCode();
                    newJobCode.Id = request.JobCode.Id;
                    newJobCode.Name = request.JobCode.Name;
                    newJobCode.IsDeleted = false;
                   // newJobCode.TimeStamp = request.JobCode.TimeStamp;
                    newJobCode.JobType = jC;

                    //remaing product fields.

                    context.JobCodes.Add(newJobCode);
                    context.SaveChanges();
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

