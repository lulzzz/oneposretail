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
   

    public class UpdateAccessLevelHandler : IRequestHandler<UpdateAccessLevelRequest, UpdateAccessLevelResponse>
    {
    
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;

        public UpdateAccessLevelHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public UpdateAccessLevelResponse Handle(UpdateAccessLevelRequest request)
        {
            var response = new UpdateAccessLevelResponse();

            var accesslevel = _onePosEntities.AccessLevels.FirstOrDefault(x => x.Id == request.AccessLevel.Id);

            accesslevel.CanAccessSystemConfig = request.AccessLevel.CanAccessSystemConfig;
            accesslevel.CanApplyAdditionalSurcharge = request.AccessLevel.CanApplyAdditionalSurcharge;
            accesslevel.CanApplyCompToItem = request.AccessLevel.CanApplyCompToItem;
            accesslevel.CanApplyHousePayment = request.AccessLevel.CanApplyHousePayment;
            accesslevel.CanApplyVoidToItem = request.AccessLevel.CanApplyVoidToItem;
            accesslevel.CanBatchPayments = request.AccessLevel.CanBatchPayments;
            accesslevel.CanCaptureElectronicPayments = request.AccessLevel.CanCaptureElectronicPayments;
            accesslevel.CanCloseHouse = request.AccessLevel.CanCloseHouse;
            accesslevel.Name = request.AccessLevel.Name;
            accesslevel.CanForceUnlockTerminal = request.AccessLevel.CanForceUnlockTerminal;
            accesslevel.CanNoSale = request.AccessLevel.CanNoSale;
            accesslevel.CanOrder = request.AccessLevel.CanOrder;
            accesslevel.CanPayIn = request.AccessLevel.CanPayIn;
            accesslevel.CanPayOut = request.AccessLevel.CanPayOut;
            accesslevel.CanPromoCheck = request.AccessLevel.CanPromoCheck;
            accesslevel.CanReopenOrder = request.AccessLevel.CanReopenOrder;
            accesslevel.CanSearchAllPayments = request.AccessLevel.CanSearchAllPayments;
            accesslevel.CanSeeOtherUsersOrders = request.AccessLevel.CanSeeOtherUsersOrders;
            accesslevel.CanSetMagStripe = request.AccessLevel.CanSetMagStripe;
            accesslevel.CanTaxFree = request.AccessLevel.CanTaxFree;
            accesslevel.CanTransferOrder = request.AccessLevel.CanTransferOrder;
            accesslevel.CanViewReports = request.AccessLevel.CanViewReports;
            accesslevel.CanVoidPayment = request.AccessLevel.CanVoidPayment;
            accesslevel.Checkouts = request.AccessLevel.Checkouts;
            accesslevel.Discounts = request.AccessLevel.Discounts;
            accesslevel.Employee = request.AccessLevel.Employee;
            accesslevel.Id = request.AccessLevel.Id;
            accesslevel.IsDeleted = request.AccessLevel.IsDeleted;
            accesslevel.Master = request.AccessLevel.Master;
            accesslevel.Name = request.AccessLevel.Name;
            accesslevel.Onetouch = request.AccessLevel.Onetouch;
            accesslevel.Payroll = request.AccessLevel.Payroll;
            accesslevel.RequireMagcardLogin = request.AccessLevel.RequireMagcardLogin;
            accesslevel.Sales = request.AccessLevel.RequireMagcardLogin;

            _onePosEntities.SaveChanges();

            return response;
        }
    }
}
