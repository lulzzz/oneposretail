using System.Text;
using OnePos.Framework.ServiceModel.Server;
using OnePos.Message;
using OnePos.Message.Model;
using OnePos.Persistance;
using OnePos.Framework.ServiceModel;
using OnePos.Domain;
using System.Linq;

namespace OnePos.ServiceInterface
{
   public class GetPayGradesHandler : IRequestHandler<GetPayGradesRequest, GetPayGradesResponse>
    {
        private readonly IOnePosEntities _onePosEntities;

        public GetPayGradesHandler(IOnePosEntities onePosEntities)
        {
            _onePosEntities = onePosEntities;
        }


        public GetPayGradesResponse Handle(GetPayGradesRequest request)
        {
            var response = new GetPayGradesResponse();

            response.PayGrades = _onePosEntities.PayGrades.Select(x => new Message.Model.PayGrade
            {
                Id = x.Id,
                Name = x.Name,
                BreaksArePaid =x.BreaksArePaid,
                WageRate =x.WageRate,
                TipTaxRate =x.TipTaxRate,
            }).ToList();

            return response;
        }

    }
}

    
    

