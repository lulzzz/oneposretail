using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Net.Http;
using System.Threading.Tasks;
using OnePos.API.Models;

namespace OnePos.API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IManageUsers" in both code and config file together.
    [ServiceContract]
    public interface IManageUsers
    {
       
        [OperationContract]
        [WebInvoke(UriTemplate = "CreateJobCode/{ResponseFormat}", Method = "POST")]
        JobCodeAPIResponse CreateJobCode(string ResponseFormat, JobCodeAPIRequest jobInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateJobCode/{ResponseFormat}", Method = "POST")]
        JobCodeAPIResponse UpdateJobCode(string ResponseFormat, JobCodeAPIRequest jobInfo);


        [OperationContract]
        [WebGet(UriTemplate = "GetJobCodes/{ResponseFormat}")]
        JobCodeAPIListResponse GetJobCodes(string ResponseFormat);



        [OperationContract]
        [WebInvoke(UriTemplate = "CreateUser/{ResponseFormat}", Method = "POST")]
        UserAPIReponse CreateUser(string ResponseFormat, UserAPIRequest userInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateUser/{ResponseFormat}", Method = "POST")]
        UserAPIReponse UpdateUser(string ResponseFormat, UserAPIRequest userInfo);


        [OperationContract]
        [WebInvoke(UriTemplate = "GetUser/{ResponseFormat}", Method = "POST")]
        UserAPIListResponse GetUsers(string ResponseFormat,SingleEntityorA11APIRequest userInfo);


    }
}
