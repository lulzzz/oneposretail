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
    public class UpdatePayGradeHandler : IRequestHandler<UpdatePayGradeRequest, UpdatePayGradeResponse>
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;

        public UpdatePayGradeHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public UpdatePayGradeResponse Handle(UpdatePayGradeRequest request)
        {
            var response = new UpdatePayGradeResponse();

            var paygradeInfo = _onePosEntities.PayGrades.FirstOrDefault(x => x.Id == request.PayGrade.Id);

            paygradeInfo.Name = request.PayGrade.Name;
            paygradeInfo.IsDeleted = request.PayGrade.IsDeleted;
            paygradeInfo.IsEligibleForOvertimePay = request.PayGrade.IsEligibleForOvertimePay;
            paygradeInfo.IsSalaried = request.PayGrade.IsSalaried;
            paygradeInfo.OtAppliedByDayHours = request.PayGrade.OtAppliedByDayHours;
            paygradeInfo.OtHoursThreshold = request.PayGrade.OtHoursThreshold;
            paygradeInfo.TimeStamp = request.PayGrade.TimeStamp;
            paygradeInfo.TipTaxRate = request.PayGrade.TipTaxRate;
            paygradeInfo.WageRate = request.PayGrade.WageRate;
            paygradeInfo.WageRateOnOverTime = request.PayGrade.WageRateOnOverTime;
            _onePosEntities.SaveChanges();

            return response;
        }
    }
}
    
