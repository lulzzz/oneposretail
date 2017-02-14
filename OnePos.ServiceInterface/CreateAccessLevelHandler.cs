using OnePos.Framework.ServiceModel.Server;
using System;
using OnePos.Message;
using OnePos.Persistance;
using OnePos.Framework.ServiceModel;
using OnePos.Domain;

namespace OnePos.ServiceInterface
{
   
    public class CreateAccessLevelHandler : IRequestHandler<CreateAccessLevelRequest, CreateAccessLevelResponse>
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;
        public CreateAccessLevelHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public CreateAccessLevelResponse Handle(CreateAccessLevelRequest request)
        {
            var response = new CreateAccessLevelResponse();

            try
            {
                using (var context = _contextFactory.Create())
                {
                    var newaccesslevel = new AccessLevel();

                    newaccesslevel.Name = request.AccessLevel.Name;
                    newaccesslevel.CanAccessSystemConfig = request.AccessLevel.CanAccessSystemConfig;
                    newaccesslevel.CanApplyAdditionalSurcharge = request.AccessLevel.CanApplyAdditionalSurcharge;
                    newaccesslevel.CanApplyCompToItem = request.AccessLevel.CanApplyCompToItem;
                    newaccesslevel.CanApplyHousePayment = request.AccessLevel.CanApplyHousePayment;
                    newaccesslevel.CanApplyVoidToItem = request.AccessLevel.CanApplyVoidToItem;
                    newaccesslevel.CanBatchPayments = request.AccessLevel.CanBatchPayments;
                    newaccesslevel.CanCaptureElectronicPayments = request.AccessLevel.CanCaptureElectronicPayments;
                    newaccesslevel.CanCloseHouse = request.AccessLevel.CanCloseHouse;
                    newaccesslevel.CanForceUnlockTerminal = request.AccessLevel.CanForceUnlockTerminal;
                    newaccesslevel.CanNoSale = request.AccessLevel.CanNoSale;
                    newaccesslevel.CanOrder = request.AccessLevel.CanOrder;
                    newaccesslevel.CanPayIn = request.AccessLevel.CanPayIn;
                    newaccesslevel.CanPayOut = request.AccessLevel.CanPayOut;
                    newaccesslevel.CanPromoCheck = request.AccessLevel.CanPromoCheck;
                    newaccesslevel.CanReopenOrder = request.AccessLevel.CanReopenOrder;
                    newaccesslevel.CanSearchAllPayments = request.AccessLevel.CanSearchAllPayments;
                    newaccesslevel.CanSeeOtherUsersOrders = request.AccessLevel.CanSeeOtherUsersOrders;
                    newaccesslevel.CanSetMagStripe = request.AccessLevel.CanSetMagStripe;
                    newaccesslevel.CanTaxFree = request.AccessLevel.CanTaxFree;
                    newaccesslevel.CanTransferOrder = request.AccessLevel.CanTransferOrder;
                    newaccesslevel.CanViewReports = request.AccessLevel.CanViewReports;
                    newaccesslevel.CanVoidPayment = request.AccessLevel.CanVoidPayment;
                    newaccesslevel.Checkouts = request.AccessLevel.Checkouts;
                    newaccesslevel.Discounts = request.AccessLevel.Discounts;
                    newaccesslevel.Employee = request.AccessLevel.Employee;
                    newaccesslevel.Id = request.AccessLevel.Id;
                    newaccesslevel.IsDeleted = request.AccessLevel.IsDeleted;
                    newaccesslevel.Master = request.AccessLevel.Master;
                    newaccesslevel.Name = request.AccessLevel.Name;
                    newaccesslevel.Onetouch = request.AccessLevel.Onetouch;
                    newaccesslevel.Payroll = request.AccessLevel.Payroll;
                    newaccesslevel.RequireMagcardLogin = request.AccessLevel.RequireMagcardLogin;
                    newaccesslevel.Sales = request.AccessLevel.RequireMagcardLogin;
                    
                   // newaccesslevel.Roles


                    //remaing product fields.

                    context.AccessLevels.Add(newaccesslevel);
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
