using OnePos.Message;
using OnePos.Persistance;
using OnePos.ServiceInterface;
using System.ServiceModel.Activation;
using System.IO;
using OnePos.Framework.Domain;
using OnePos.Framework.ServiceModel;
using OnePos.Framework.Extensions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Hosting;
using OnePos.API.Models;
using OnePos.Framework;
using OnePos.Message.Model;
using System;
using OnePos.Domain.Encryption;
using System.ServiceModel.Web;
using System.Linq;
using System.Net;

namespace OnePos.API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ManageUsers" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ManageUsers.svc or ManageUsers.svc.cs at the Solution Explorer and start debugging.
   

    [AspNetCompatibilityRequirements(
      RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ManageUsers : IManageUsers
    {
        public JobCodeAPIResponse CreateJobCode(string ResponseFormat, JobCodeAPIRequest jobcodeinfo)
        {
            JobCodeAPIResponse jobcodeapiresponse = new JobCodeAPIResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);

            

            CreateJobCodeHandler createjobcodehandler = new CreateJobCodeHandler(dFactory, OnePosEntities);

            

            if (ResponseFormat.ToLower() == "json")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
            else if (ResponseFormat.ToLower() == "xml")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }

           /// TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            CreateJobCodeRequest createjobcoderequest = new CreateJobCodeRequest()
            {
                JobCode = new JobCode
                {
                    Id =jobcodeinfo.id,
                    Name =  jobcodeinfo.name
                   
                
                }
            };

            try
            {

                CreateJobCodeResponse createjobcoderesponse = new CreateJobCodeResponse();
                createjobcoderesponse = createjobcodehandler.Handle(createjobcoderequest);

                if (createjobcoderesponse.ExceptionType == ExceptionType.None)
                {
                    //jobcodeapiresponse.Id = (createjobcoderesponse.JobID) as long;
                    jobcodeapiresponse.statusCode = HttpStatusCode.OK;
                    jobcodeapiresponse.statusMessage = "Store created successfully.";
                }
                else
                {
                    jobcodeapiresponse.statusCode = HttpStatusCode.BadRequest;
                    jobcodeapiresponse.statusMessage = createjobcoderesponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                jobcodeapiresponse.statusCode = HttpStatusCode.BadRequest;
                jobcodeapiresponse.statusMessage = ex.Message;
            }
            return jobcodeapiresponse;
        }

        public JobCodeAPIListResponse GetJobCodes(string ResponseFormat)
        {
            JobCodeAPIListResponse jobcodeapilistresponse = new JobCodeAPIListResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            GetJobCodesHandler getjobcodeshandler = new GetJobCodesHandler(OnePosEntities);

            if (ResponseFormat.ToLower() == "json")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
            else if (ResponseFormat.ToLower() == "xml")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }

            TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            try
            {
                GetJobCodesResponse getjobcodesresponse = new GetJobCodesResponse();

                getjobcodesresponse = getjobcodeshandler.Handle(new GetJobCodesRequest() { });

                if (getjobcodesresponse.ExceptionType == ExceptionType.None)
                {
                    jobcodeapilistresponse.jobCodesList = getjobcodesresponse.Jobcodes.Select(x => new JobCodeAPIRequest
                    {
                        id = x.Id,
                        name = x.Name
                    }).ToList();

                    jobcodeapilistresponse.statusCode = HttpStatusCode.OK;
                    jobcodeapilistresponse.statusMessage = "Job Codes List";
                }
                else
                {
                    jobcodeapilistresponse.statusCode = HttpStatusCode.BadRequest;
                    jobcodeapilistresponse.statusMessage = getjobcodesresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                jobcodeapilistresponse.statusCode = HttpStatusCode.BadRequest;
                jobcodeapilistresponse.statusMessage = ex.Message;
            }
            return jobcodeapilistresponse;
            // throw new NotImplementedException();
        }

        public JobCodeAPIResponse UpdateJobCode(string ResponseFormat, JobCodeAPIRequest jobcodeinfo)
        {
            JobCodeAPIResponse jobcodeapiresponse = new JobCodeAPIResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);



            UpdateJobCodeHandler updatejobcodehandler = new UpdateJobCodeHandler(dFactory, OnePosEntities);



            if (ResponseFormat.ToLower() == "json")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
            else if (ResponseFormat.ToLower() == "xml")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }

            /// TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            UpdateJobCodeRequest updatejobcoderequest = new UpdateJobCodeRequest()
            {
          

                jobcode = new JobCode
                {
                    Id = jobcodeinfo.id,
                    Name = jobcodeinfo.name


                }
            };

            try
            {

                UpdateJobCodeResponse updatejobcoderesponse = new UpdateJobCodeResponse();
                updatejobcoderesponse = updatejobcodehandler.Handle(updatejobcoderequest);

                if (updatejobcoderesponse.ExceptionType == ExceptionType.None)
                {
                    //jobcodeapiresponse.Id = (createjobcoderesponse.JobID) as long;
                    jobcodeapiresponse.statusCode = HttpStatusCode.OK;
                    jobcodeapiresponse.statusMessage = "JobCode Updated Successfully.";
                }
                else
                {
                    jobcodeapiresponse.statusCode = HttpStatusCode.BadRequest;
                    jobcodeapiresponse.statusMessage = updatejobcoderesponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                jobcodeapiresponse.statusCode = HttpStatusCode.BadRequest;
                jobcodeapiresponse.statusMessage = ex.Message;
            }
            return jobcodeapiresponse;
        }



        public PayGradeAPIResponse CreatePayGrade(string ResponseFormat, PayGradeAPIRequest paygradeinfo)
        {
            PayGradeAPIResponse paygradeapiresponse = new PayGradeAPIResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);



            CreatePayGradeHandler createpaygradehandler = new CreatePayGradeHandler(dFactory, OnePosEntities);



            if (ResponseFormat.ToLower() == "json")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
            else if (ResponseFormat.ToLower() == "xml")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }

            /// TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            CreatePayGradeRequest createpaygraderequest = new CreatePayGradeRequest()
            {

                PayGrade = new PayGrade()
                {
                    Id = paygradeinfo.id,
            Name = paygradeinfo.name,
            IsDeleted = paygradeinfo.isdeleted,
            IsEligibleForOvertimePay = paygradeinfo.iseligibleforovertimepay,
            IsSalaried = paygradeinfo.issalaried,
            OtAppliedByDayHours = paygradeinfo.otappliedbydayhours,
            OtHoursThreshold = paygradeinfo.othoursthreshold,
            TimeStamp = paygradeinfo.timestamp,
            TipTaxRate = paygradeinfo.tiptaxrate,
            WageRate = paygradeinfo.wagerate,
            WageRateOnOverTime = paygradeinfo.wagerateonovertime

        }
        
            };

            try
            {

                CreatePayGradeResponse createpaygraderesponse = new CreatePayGradeResponse();
                createpaygraderesponse = createpaygradehandler.Handle(createpaygraderequest);

                if (createpaygraderesponse.ExceptionType == ExceptionType.None)
                {
                    //paygradeapiresponse.Id = (createpaygraderesponse.JobID) as long;
                    paygradeapiresponse.statusCode = HttpStatusCode.OK;
                    paygradeapiresponse.statusMessage = "Store created successfully.";
                }
                else
                {
                    paygradeapiresponse.statusCode = HttpStatusCode.BadRequest;
                    paygradeapiresponse.statusMessage = createpaygraderesponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                paygradeapiresponse.statusCode = HttpStatusCode.BadRequest;
                paygradeapiresponse.statusMessage = ex.Message;
            }
            return paygradeapiresponse;
        }


        public PayGradeAPIListResponse GetPayGrades(string ResponseFormat)
        {
            PayGradeAPIListResponse paygradeapilistresponse = new PayGradeAPIListResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            GetPayGradesHandler getpaygradeshandler = new GetPayGradesHandler(OnePosEntities);

            if (ResponseFormat.ToLower() == "json")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
            else if (ResponseFormat.ToLower() == "xml")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }

            TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            try
            {
                GetPayGradesResponse getpaygradesresponse = new GetPayGradesResponse();

                getpaygradesresponse = getpaygradeshandler.Handle(new GetPayGradesRequest() { });

                if (getpaygradesresponse.ExceptionType == ExceptionType.None)
                {
                    paygradeapilistresponse.paygradesList = getpaygradesresponse.PayGrades.Select(x => new PayGradeAPIRequest
                    {
                        id = x.Id,
                        name = x.Name,
                        isdeleted = x.IsDeleted,
                        iseligibleforovertimepay = x.IsEligibleForOvertimePay,
                        issalaried = x.IsSalaried,
                        otappliedbydayhours = x.OtAppliedByDayHours,
                        othoursthreshold = x.OtHoursThreshold,
                        timestamp = x.TimeStamp,
                        tiptaxrate = x.TipTaxRate,
                        wagerate = x.WageRate,
                        wagerateonovertime = x.WageRateOnOverTime
                    }).ToList();

                    paygradeapilistresponse.statusCode = HttpStatusCode.OK;
                    paygradeapilistresponse.statusMessage = "Job Codes List";
                }
                else
                {
                    paygradeapilistresponse.statusCode = HttpStatusCode.BadRequest;
                    paygradeapilistresponse.statusMessage = getpaygradesresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                paygradeapilistresponse.statusCode = HttpStatusCode.BadRequest;
                paygradeapilistresponse.statusMessage = ex.Message;
            }
            return paygradeapilistresponse;
            // throw new NotImplementedException();
        }


        public PayGradeAPIResponse UpdatePayGrade(string ResponseFormat, PayGradeAPIRequest paygradeinfo)
        {
            PayGradeAPIResponse paygradeapiresponse = new PayGradeAPIResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);



            UpdatePayGradeHandler updatepaygradehandler = new UpdatePayGradeHandler(dFactory, OnePosEntities);



            if (ResponseFormat.ToLower() == "json")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
            else if (ResponseFormat.ToLower() == "xml")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }

            /// TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            UpdatePayGradeRequest updatepaygraderequest = new UpdatePayGradeRequest()
            {


                PayGrade = new PayGrade
                {
                    Id = paygradeinfo.id,
                    Name = paygradeinfo.name,
                    IsDeleted = paygradeinfo.isdeleted,
                    IsEligibleForOvertimePay = paygradeinfo.iseligibleforovertimepay,
                    IsSalaried = paygradeinfo.issalaried,
                    OtAppliedByDayHours = paygradeinfo.otappliedbydayhours,
                    OtHoursThreshold = paygradeinfo.othoursthreshold,
                    TimeStamp = paygradeinfo.timestamp,
                    TipTaxRate = paygradeinfo.tiptaxrate,
                    WageRate = paygradeinfo.wagerate,
                    WageRateOnOverTime = paygradeinfo.wagerateonovertime


                }
            };

            try
            {

                UpdatePayGradeResponse updatepaygraderesponse = new UpdatePayGradeResponse();
                updatepaygraderesponse = updatepaygradehandler.Handle(updatepaygraderequest);

                if (updatepaygraderesponse.ExceptionType == ExceptionType.None)
                {
                    //paygradeapiresponse.Id = (createpaygraderesponse.JobID) as long;
                    paygradeapiresponse.statusCode = HttpStatusCode.OK;
                    paygradeapiresponse.statusMessage = "PayGrade Updated Successfully.";
                }
                else
                {
                    paygradeapiresponse.statusCode = HttpStatusCode.BadRequest;
                    paygradeapiresponse.statusMessage = updatepaygraderesponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                paygradeapiresponse.statusCode = HttpStatusCode.BadRequest;
                paygradeapiresponse.statusMessage = ex.Message;
            }
            return paygradeapiresponse;
        }

        public UserAPIReponse CreateUser(string ResponseFormat, UserAPIRequest userInfo)
        {

            UserAPIReponse userapireponse = new UserAPIReponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);



            CreateUserHandler CreateUserHandler = new CreateUserHandler(dFactory, OnePosEntities);



            if (ResponseFormat.ToLower() == "json")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
            else if (ResponseFormat.ToLower() == "xml")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }

            /// TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            CreateUserRequest createuserrequest = new CreateUserRequest()
            {
                User = new User
                {
                    
                   
                    Name = userInfo.name,
                    UserName = userInfo.username,
                    BohPasswordAttempts = userInfo.bohpasswordattempts,
                    ExternalPayrollId = userInfo.externalpayrollid,
                    BohSecretAnswer = userInfo.bohsecretanswer,
                    BohLockoutDate = userInfo.bohlockoutdate,
                    BohPasswordDate = userInfo.bohpassworddate,
                    BohSecretQuestion = userInfo.bohsecretquestion,
                    Birthdate = userInfo.birthdate,
                    EmailAddress = userInfo.emailaddress,
                    EmployeeNumber = userInfo.employeenumber,
                    Address1 = userInfo.address1,
                    Address2 = userInfo.address2,
                    City = userInfo.city,
                    Country = userInfo.country,
                    AltPhone = userInfo.altphone,
                    FingerPasswordId = userInfo.fingerpasswordid,
                    FirstName = userInfo.firstname,
                    HiredDate = userInfo.hireddate,
                    HomePhone = userInfo.homephone,
                    IsDeleted = userInfo.isdeleted,
                    IsTerminated = userInfo.isterminated,
                    IsTraining = userInfo.istraining,
                    LastName = userInfo.lastname,
                    LoginBohPassword = userInfo.loginbohpassword,
                    LoginKeyPassword = userInfo.loginkeypassword,
                    LoginMagPassword = userInfo.loginmagpassword,
                    MiddleName = userInfo.middlename,
                    MobilePhone = userInfo.mobilephone,
                    OldBohPassword1 = userInfo.oldbohpassword1,
                    OldBohPassword2 = userInfo.oldbohpassword2,
                    OldBohPassword3 = userInfo.oldbohpassword3,
                    OldBohPassword4 = userInfo.oldbohpassword4,
                    ScreenName = userInfo.screenname,
                    Sex = userInfo.sex,
                    Ssn = userInfo.ssn,
                    State = userInfo.state,
                    TerminationDate = userInfo.terminationdate,
                    Zipcode = userInfo.zipcode


                }
            };

            try
            {

                CreateUserResponse createuserresponse = new CreateUserResponse();
                createuserresponse = CreateUserHandler.Handle(createuserrequest);

                if (createuserresponse.ExceptionType == ExceptionType.None)
                {
                    userapireponse.UserID = createuserresponse.UserID;
                    userapireponse.statusCode = HttpStatusCode.OK;
                    userapireponse.statusMessage = "User created successfully.";
                }
                else
                {
                    userapireponse.statusCode = HttpStatusCode.BadRequest;
                    userapireponse.statusMessage = createuserresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                userapireponse.statusCode = HttpStatusCode.BadRequest;
                userapireponse.statusMessage = ex.Message;
            }
            return userapireponse;

            //throw new NotImplementedException();
        }

        public UserAPIReponse UpdateUser(string ResponseFormat, UserAPIRequest userInfo)
        {
            UserAPIReponse userapireponse = new UserAPIReponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            IOnePosEntitiesFactory dFactory = new OnePosEntitiesFactory(DependencyContainer.Default);


            UpdateUserHandler updateuserhandler = new UpdateUserHandler(dFactory, OnePosEntities);



            if (ResponseFormat.ToLower() == "json")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
            else if (ResponseFormat.ToLower() == "xml")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }

            /// TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            UpdateUserRequest updatejobcoderequest = new UpdateUserRequest()
            {


                User = new User
                {
                    Id = userInfo.id,
                    Name = userInfo.name,
                    UserName = userInfo.username,
                    BohPasswordAttempts = userInfo.bohpasswordattempts,
                    ExternalPayrollId = userInfo.externalpayrollid,
                    BohSecretAnswer = userInfo.bohsecretanswer,
                    BohLockoutDate = userInfo.bohlockoutdate,
                    BohPasswordDate = userInfo.bohpassworddate,
                    BohSecretQuestion = userInfo.bohsecretquestion,
                    Birthdate = userInfo.birthdate,
                    EmailAddress = userInfo.emailaddress,
                    EmployeeNumber = userInfo.employeenumber,
                    Address1 = userInfo.address1,
                    Address2 = userInfo.address2,
                    City = userInfo.city,
                    Country = userInfo.country,
                    AltPhone = userInfo.altphone,
                    FingerPasswordId = userInfo.fingerpasswordid,
                    FirstName = userInfo.firstname,
                    HiredDate = userInfo.hireddate,
                    HomePhone = userInfo.homephone,
                    IsDeleted = userInfo.isdeleted,
                    IsTerminated = userInfo.isterminated,
                    IsTraining = userInfo.istraining,
                    LastName = userInfo.lastname,
                    LoginBohPassword = userInfo.loginbohpassword,
                    LoginKeyPassword = userInfo.loginkeypassword,
                    LoginMagPassword = userInfo.loginmagpassword,
                    MiddleName = userInfo.middlename,
                    MobilePhone = userInfo.mobilephone,
                    OldBohPassword1 = userInfo.oldbohpassword1,
                    OldBohPassword2 = userInfo.oldbohpassword2,
                    OldBohPassword3 = userInfo.oldbohpassword3,
                    OldBohPassword4 = userInfo.oldbohpassword4,
                    ScreenName = userInfo.screenname,
                    Sex = userInfo.sex,
                    Ssn = userInfo.ssn,
                    State = userInfo.state,
                    TerminationDate = userInfo.terminationdate,
                    Zipcode = userInfo.zipcode


                }
            };

            try
            {

                UpdateUserResponse updateuserresponse = new UpdateUserResponse();
                updateuserresponse = updateuserhandler.Handle(updatejobcoderequest);

                if (updateuserresponse.ExceptionType == ExceptionType.None)
                {
                    //jobcodeapiresponse.Id = (createjobcoderesponse.JobID) as long;
                    userapireponse.statusCode = HttpStatusCode.OK;
                    userapireponse.statusMessage = "User Updated Successfully.";
                }
                else
                {
                    userapireponse.statusCode = HttpStatusCode.BadRequest;
                    userapireponse.statusMessage = updateuserresponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                userapireponse.statusCode = HttpStatusCode.BadRequest;
                userapireponse.statusMessage = ex.Message;
            }
            return userapireponse;
            //throw new NotImplementedException();
        }

        public UserAPIListResponse GetUsers(string ResponseFormat, SingleEntityorA11APIRequest userInfo)
        {
            UserAPIListResponse userapilistresponse = new UserAPIListResponse();
            IOnePosEntities OnePosEntities = new OnePosEntities();
            GetUsersHandler getusershandler = new GetUsersHandler(OnePosEntities);

            if (ResponseFormat.ToLower() == "json")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
            else if (ResponseFormat.ToLower() == "xml")
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }




            TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
            try
            {
                GetUsersResponse GetUsersResponse = new GetUsersResponse();

                GetUsersResponse = getusershandler.Handle(new GetUsersRequest {  UserID= userInfo.ID == "" ? new Guid() : new Guid(userInfo.ID) });

                if (GetUsersResponse.ExceptionType == ExceptionType.None)
                {
                    userapilistresponse.usersList = GetUsersResponse.Users.Select(x => new UserAPIRequest
                    {
                        id = x.Id,
                        name = x.Name,
                        username = x.UserName,
                        firstname = x.FirstName,
                        lastname = x.LastName


                        //id = userInfo.id,
                        //Name = userInfo.name,
                        //UserName = userInfo.username,
                        //BohPasswordAttempts = userInfo.bohpasswordattempts,
                        //ExternalPayrollId = userInfo.externalpayrollid,
                        //BohSecretAnswer = userInfo.bohsecretanswer,
                        //BohLockoutDate = userInfo.bohlockoutdate,
                        //BohPasswordDate = userInfo.bohpassworddate,
                        //BohSecretQuestion = userInfo.bohsecretquestion,
                        //Birthdate = userInfo.birthdate,
                        //EmailAddress = userInfo.emailaddress,
                        //EmployeeNumber = userInfo.employeenumber,
                        //Address1 = userInfo.address1,
                        //Address2 = userInfo.address2,
                        //City = userInfo.city,
                        //Country = userInfo.country,
                        //AltPhone = userInfo.altphone,
                        //FingerPasswordId = userInfo.fingerpasswordid,
                        //FirstName = userInfo.firstname,
                        //HiredDate = userInfo.hireddate,
                        //HomePhone = userInfo.homephone,
                        //IsDeleted = userInfo.isdeleted,
                        //IsTerminated = userInfo.isterminated,
                        //IsTraining = userInfo.istraining,
                        //LastName = userInfo.lastname,
                        //LoginBohPassword = userInfo.loginbohpassword,
                        //LoginKeyPassword = userInfo.loginkeypassword,
                        //LoginMagPassword = userInfo.loginmagpassword,
                        //MiddleName = userInfo.middlename,
                        //MobilePhone = userInfo.mobilephone,
                        //OldBohPassword1 = userInfo.oldbohpassword1,
                        //OldBohPassword2 = userInfo.oldbohpassword2,
                        //OldBohPassword3 = userInfo.oldbohpassword3,
                        //OldBohPassword4 = userInfo.oldbohpassword4,
                        //ScreenName = userInfo.screenname,
                        //Sex = userInfo.sex,
                        //Ssn = userInfo.ssn,
                        //State = userInfo.state,
                        //TerminationDate = userInfo.terminationdate,
                        //Zipcode = userInfo.zipcode

                    }).ToList();

                    userapilistresponse.statusCode = HttpStatusCode.OK;
                    userapilistresponse.statusMessage = "Products List";
                }
                else
                {
                    userapilistresponse.statusCode = HttpStatusCode.BadRequest;
                    userapilistresponse.statusMessage = GetUsersResponse.Exception.Message;
                }

            }
            catch (Exception ex)
            {
                userapilistresponse.statusCode = HttpStatusCode.BadRequest;
                userapilistresponse.statusMessage = ex.Message;
            }
            return userapilistresponse;
        }
    }
}
