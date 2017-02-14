using OnePos.Framework.ServiceModel.Server;
using System;
using OnePos.Message;
using OnePos.Persistance;
using OnePos.Framework.ServiceModel;
using OnePos.Domain;


namespace OnePos.ServiceInterface
{
    public class CreatePayGradeHandler : IRequestHandler<CreatePayGradeRequest, CreatePayGradeResponse>
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;
        public CreatePayGradeHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

       

        public CreatePayGradeResponse Handle(CreatePayGradeRequest request)
        {
            var response = new CreatePayGradeResponse();

            try
            {
                using (var context = _contextFactory.Create())
                {
                   

                    var newpaygrade = new PayGrade();
                    newpaygrade.Id = request.PayGrade.Id;
                    newpaygrade.Name = request.PayGrade.Name;
                    newpaygrade.IsDeleted = request.PayGrade.IsDeleted;
                    newpaygrade.IsEligibleForOvertimePay = request.PayGrade.IsEligibleForOvertimePay;
                    newpaygrade.IsSalaried = request.PayGrade.IsSalaried;
                    newpaygrade.OtAppliedByDayHours = request.PayGrade.OtAppliedByDayHours;
                    newpaygrade.OtHoursThreshold = request.PayGrade.OtHoursThreshold;
                    newpaygrade.TimeStamp = request.PayGrade.TimeStamp;
                    newpaygrade.TipTaxRate = request.PayGrade.TipTaxRate;
                    newpaygrade.WageRate = request.PayGrade.WageRate;
                    newpaygrade.WageRateOnOverTime = request.PayGrade.WageRateOnOverTime;

                    context.PayGrades.Add(newpaygrade);
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
