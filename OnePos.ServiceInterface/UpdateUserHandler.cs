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
    public class UpdateUserHandler
    {
        private readonly IOnePosEntitiesFactory _contextFactory;
        private readonly IOnePosEntities _onePosEntities;

        public UpdateUserHandler(IOnePosEntitiesFactory contextFactory, IOnePosEntities onePosEntities)
        {
            _contextFactory = contextFactory;
            _onePosEntities = onePosEntities;
        }

        public UpdateUserResponse Handle(UpdateUserRequest request)
        {
            var response = new UpdateUserResponse();

            var userInfo = _onePosEntities.Users.FirstOrDefault(x => x.Id == request.User.Id);

            userInfo.Id = request.User.Id;
            userInfo.Name = request.User.Name;
            userInfo.UserName = request.User.UserName;
              userInfo.BohPasswordAttempts = request.User.BohPasswordAttempts;
                         userInfo.ExternalPayrollId = request.User.ExternalPayrollId;
                         userInfo.BohSecretAnswer = request.User.BohSecretAnswer;
                         userInfo.BohLockoutDate = request.User.BohLockoutDate;
                         userInfo.BohPasswordDate = request.User.BohPasswordDate;
                         userInfo.BohSecretQuestion = request.User.BohSecretQuestion;
                         userInfo.Birthdate = request.User.Birthdate;
                         userInfo.EmailAddress = request.User.EmailAddress;
                         userInfo.EmployeeNumber = request.User.EmployeeNumber;
                         userInfo.Address1 = request.User.Address1;
                        userInfo.Address2 = request.User.Address2;
                        userInfo.City = request.User.City;
                        userInfo.Country = request.User.Country;
                        userInfo.AltPhone = request.User.AltPhone;
                        userInfo.FingerPasswordId = request.User.FingerPasswordId;
                        userInfo.FirstName = request.User.FirstName;
                        userInfo.HiredDate = request.User.HiredDate;
                        userInfo.HomePhone = request.User.HomePhone;
                        userInfo.IsDeleted = request.User.IsDeleted;
                        userInfo.IsTerminated = request.User.IsTerminated;
                        userInfo.IsTraining = request.User.IsTraining;
                        userInfo.LastName = request.User.LastName;
                        userInfo.LoginBohPassword = request.User.LoginBohPassword;
                        userInfo.LoginKeyPassword = request.User.LoginKeyPassword;
                        userInfo.LoginMagPassword = request.User.LoginMagPassword;
                        userInfo.MiddleName = request.User.MiddleName;
                        userInfo.MobilePhone = request.User.MobilePhone;
                        userInfo.OldBohPassword1 = request.User.OldBohPassword1;
                        userInfo.OldBohPassword2 = request.User.OldBohPassword2;
                        userInfo.OldBohPassword3 = request.User.OldBohPassword3;
                        userInfo.OldBohPassword4 = request.User.OldBohPassword4;
                        userInfo.ScreenName = request.User.ScreenName;
                        userInfo.Sex = request.User.Sex;
                       userInfo.Ssn = request.User.Ssn;
                        userInfo.State = request.User.State;
                        userInfo.TerminationDate = request.User.TerminationDate;
                        userInfo.Zipcode = request.User.Zipcode;
            userInfo.TimeStamp = request.User.TimeStamp;

            _onePosEntities.SaveChanges();

            return response;
        }
    }
}
