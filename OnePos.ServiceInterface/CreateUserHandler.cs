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
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;
        public CreateUserHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public CreateUserResponse Handle(CreateUserRequest request)
        {
            var response = new CreateUserResponse();
            
            try
            {
                using (var context = _contextFactory.Create())
                {
                    var newUser = new User()
                    {
                        Id = Guid.NewGuid(),
                        Name = request.User.Name,
                        UserName = request.User.UserName,
                        BohPasswordAttempts = request.User.BohPasswordAttempts,
                        ExternalPayrollId = request.User.ExternalPayrollId,
                        BohSecretAnswer = request.User.BohSecretAnswer,
                        BohLockoutDate = request.User.BohLockoutDate,
                        BohPasswordDate = request.User.BohPasswordDate,
                        BohSecretQuestion = request.User.BohSecretQuestion,
                        Birthdate = request.User.Birthdate,
                        EmailAddress = request.User.EmailAddress,
                        EmployeeNumber = request.User.EmployeeNumber,
                        Address1 = request.User.Address1,
                        Address2 = request.User.Address2,
                        City = request.User.City,
                        Country = request.User.Country,
                        AltPhone = request.User.AltPhone,
                        FingerPasswordId = request.User.FingerPasswordId,
                        FirstName = request.User.FirstName,
                        HiredDate = request.User.HiredDate,
                        HomePhone = request.User.HomePhone,
                        IsDeleted = request.User.IsDeleted,
                        IsTerminated = request.User.IsTerminated,
                        IsTraining = request.User.IsTraining,
                        LastName = request.User.LastName,
                        LoginBohPassword = request.User.LoginBohPassword,
                        LoginKeyPassword = request.User.LoginKeyPassword,
                        LoginMagPassword = request.User.LoginMagPassword,
                        MiddleName = request.User.MiddleName,
                        MobilePhone = request.User.MobilePhone,
                        OldBohPassword1 = request.User.OldBohPassword1,
                        OldBohPassword2 = request.User.OldBohPassword2,
                        OldBohPassword3 = request.User.OldBohPassword3,
                        OldBohPassword4 = request.User.OldBohPassword4,
                        ScreenName = request.User.ScreenName,
                        Sex = request.User.Sex,
                        Ssn = request.User.Ssn,
                        State = request.User.State,
                        TerminationDate = request.User.TerminationDate,
                        Zipcode = request.User.Zipcode,
                        //TimeStamp = request.User.TimeStamp
                    };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    response.UserID = newUser.Id;
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
