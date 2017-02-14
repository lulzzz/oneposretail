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
    public class GetUsersHandler: IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IOnePosEntities _onePosEntities;
        public GetUsersHandler(IOnePosEntities onePosEntities)
        {
            _onePosEntities = onePosEntities;
        }

        public GetUsersResponse Handle(GetUsersRequest request)
        {
            var response = new GetUsersResponse();


            if (request.UserID == new Guid())
            {
                response.Users = _onePosEntities.Users.Select(x => new Message.Model.User
                {
                    Id = x.Id,
                    Name = x.Name,
                    UserName = x.UserName,
                    BohPasswordAttempts = x.BohPasswordAttempts,
                    ExternalPayrollId = x.ExternalPayrollId,
                    BohSecretAnswer = x.BohSecretAnswer,
                    BohLockoutDate = x.BohLockoutDate,
                    BohPasswordDate = x.BohPasswordDate,
                    BohSecretQuestion = x.BohSecretQuestion,
                    Birthdate = x.Birthdate,
                    EmailAddress = x.EmailAddress,
                    EmployeeNumber = x.EmployeeNumber,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    City = x.City,
                    Country = x.Country,
                    AltPhone = x.AltPhone,
                    FingerPasswordId = x.FingerPasswordId,
                    FirstName = x.FirstName,
                    HiredDate = x.HiredDate,
                    HomePhone = x.HomePhone,
                    IsDeleted = x.IsDeleted,
                    IsTerminated = x.IsTerminated,
                    IsTraining = x.IsTraining,
                    LastName = x.LastName,
                    LoginBohPassword = x.LoginBohPassword,
                    LoginKeyPassword = x.LoginKeyPassword,
                    LoginMagPassword = x.LoginMagPassword,
                    MiddleName = x.MiddleName,
                    MobilePhone = x.MobilePhone,
                    OldBohPassword1 = x.OldBohPassword1,
                    OldBohPassword2 = x.OldBohPassword2,
                    OldBohPassword3 = x.OldBohPassword3,
                    OldBohPassword4 = x.OldBohPassword4,
                    ScreenName = x.ScreenName,
                    Sex = x.Sex,
                    Ssn = x.Ssn,
                    State = x.State,
                    TerminationDate = x.TerminationDate,
                    Zipcode = x.Zipcode,
                    TimeStamp = x.TimeStamp
                }).ToList();

            }

            else
            {
               
                response.Users = _onePosEntities.Users.Where(p=>p.Id == request.UserID).Select(x => new Message.Model.User
                {
                    Id = x.Id,
                    Name = x.Name,
                    UserName = x.UserName,
                    BohPasswordAttempts = x.BohPasswordAttempts,
                    ExternalPayrollId = x.ExternalPayrollId,
                    BohSecretAnswer = x.BohSecretAnswer,
                    BohLockoutDate = x.BohLockoutDate,
                    BohPasswordDate = x.BohPasswordDate,
                    BohSecretQuestion = x.BohSecretQuestion,
                    Birthdate = x.Birthdate,
                    EmailAddress = x.EmailAddress,
                    EmployeeNumber = x.EmployeeNumber,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    City = x.City,
                    Country = x.Country,
                    AltPhone = x.AltPhone,
                    FingerPasswordId = x.FingerPasswordId,
                    FirstName = x.FirstName,
                    HiredDate = x.HiredDate,
                    HomePhone = x.HomePhone,
                    IsDeleted = x.IsDeleted,
                    IsTerminated = x.IsTerminated,
                    IsTraining = x.IsTraining,
                    LastName = x.LastName,
                    LoginBohPassword = x.LoginBohPassword,
                    LoginKeyPassword = x.LoginKeyPassword,
                    LoginMagPassword = x.LoginMagPassword,
                    MiddleName = x.MiddleName,
                    MobilePhone = x.MobilePhone,
                    OldBohPassword1 = x.OldBohPassword1,
                    OldBohPassword2 = x.OldBohPassword2,
                    OldBohPassword3 = x.OldBohPassword3,
                    OldBohPassword4 = x.OldBohPassword4,
                    ScreenName = x.ScreenName,
                    Sex = x.Sex,
                    Ssn = x.Ssn,
                    State = x.State,
                    TerminationDate = x.TerminationDate,
                    Zipcode = x.Zipcode,
                    TimeStamp = x.TimeStamp
                }).ToList();
            }

           

            return response;
        }
    }
}
