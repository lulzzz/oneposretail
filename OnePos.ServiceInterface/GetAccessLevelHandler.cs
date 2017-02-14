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
   
    public class GetAccessLevelHandler : IRequestHandler<GetAccessLevelsRequest, GetAccessLevelsResponse>
    {
        private readonly IOnePosEntities _onePosEntities;
        public GetAccessLevelHandler(IOnePosEntities onePosEntities)
        {
            _onePosEntities = onePosEntities;
        }


        public GetAccessLevelsResponse Handle(GetAccessLevelsRequest request)
        {
            var response = new GetAccessLevelsResponse();

            response.AccessLevels = _onePosEntities.AccessLevels.Select(x => new Message.Model.AccessLevel
            {
           Name = x.Name,
           CanAccessSystemConfig = x.CanAccessSystemConfig,
           CanApplyAdditionalSurcharge = x.CanApplyAdditionalSurcharge,
           CanApplyCompToItem = x.CanApplyCompToItem,
           CanApplyHousePayment = x.CanApplyHousePayment,
           CanApplyVoidToItem = x.CanApplyVoidToItem,
           CanBatchPayments = x.CanBatchPayments,
           CanCaptureElectronicPayments = x.CanCaptureElectronicPayments,
           CanCloseHouse = x.CanCloseHouse,
           CanForceUnlockTerminal = x.CanForceUnlockTerminal,
           CanNoSale = x.CanNoSale,
           CanOrder = x.CanOrder,
           CanPayIn = x.CanPayIn,
           CanPayOut = x.CanPayOut,
           CanPromoCheck = x.CanPromoCheck,
           CanReopenOrder = x.CanReopenOrder,
           CanSearchAllPayments = x.CanSearchAllPayments,
           CanSeeOtherUsersOrders = x.CanSeeOtherUsersOrders,
           CanSetMagStripe = x.CanSetMagStripe,
           CanTaxFree = x.CanTaxFree,
           CanTransferOrder = x.CanTransferOrder,
           CanViewReports = x.CanViewReports,
           CanVoidPayment = x.CanVoidPayment,
           Checkouts = x.Checkouts,
           Discounts = x.Discounts,
           Employee = x.Employee,
           Id = x.Id,
           IsDeleted = x.IsDeleted,
           Master = x.Master,
           Onetouch = x.Onetouch,
           Payroll = x.Payroll,
           RequireMagcardLogin = x.RequireMagcardLogin,
           Sales = x.RequireMagcardLogin
        }).ToList();

            return response;
        }

    }
}
