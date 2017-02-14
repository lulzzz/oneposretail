using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace OnePos.API.Models
{
    public class JobCodeAPIRequest
    {

        public Guid id { get; set; }
        public bool isdeleted { get; set; }
        public Byte[] timeStamp { get; set; }
        public string name { get; set; }

        public JobType jobtype { get; set; }

        //public string CreatedBy { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public string ModifiedBy { get; set; }
        //public DateTime? ModifiedDate { get; set; }

       
    }

    public class JobCodeAPIResponse
    {
        public long Id { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }

    public class JobCodeAPIListResponse
    {
        public IList<JobCodeAPIRequest> jobCodesList { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }

    public enum JobType
    {
        
        Cashier,
        Host,
        Manager = 1,
       
        Retail,
        Valet,
        Other
    }



    public class PayGradeAPIRequest
    {

        public decimal wagerate { get; set; }
        public decimal tiptaxrate { get; set; }
        public bool issalaried { get; set; }
        public bool otappliedbydayhours { get; set; }
        public decimal wagerateonovertime { get; set; }
        public bool breaksarepaid { get; set; }
        public decimal othoursthreshold { get; set; }
        public bool iseligibleforovertimepay { get; set; }
        public Guid id { get; set; }
        public bool isdeleted { get; set; }
        public byte[] timestamp { get; set; }
        public string name { get; set; }


    }

    public class PayGradeAPIResponse
    {
        public long Id { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }

    public class PayGradeAPIListResponse
    {
        public IList<PayGradeAPIRequest> paygradesList { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }


    public class UserAPIRequest
    {


        public string lastname { get; set; }
        public string firstname { get; set; }
        public string username { get; set; }
        public string screenname { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string homephone { get; set; }
        public string ssn { get; set; }

        public DateTime? birthdate { get; set; }

        public DateTime? hireddate { get; set; }


        public short? sex { get; set; }
        public byte[] loginbohpassword { get; set; }
        public string loginkeypassword { get; set; }
        public string loginmagpassword { get; set; }
        public bool isterminated { get; set; }
        public byte[] oldbohpassword1 { get; set; }
        public byte[] oldbohpassword2 { get; set; }
        public byte[] oldbohpassword3 { get; set; }
        public byte[] oldbohpassword4 { get; set; }
        public DateTime? bohpassworddate { get; set; }
        public int bohpasswordattempts { get; set; }
        public string bohsecretquestion { get; set; }
        public string bohsecretanswer { get; set; }
        public string emailaddress { get; set; }
        public DateTime? bohlockoutdate { get; set; }
        public long? externalpayrollid { get; set; }
        public DateTime? terminationdate { get; set; }
        public string country { get; set; }
        public string mobilephone { get; set; }
        public Guid? fingerpasswordid { get; set; }
        public string altphone { get; set; }
        public string employeenumber { get; set; }
        public string middlename { get; set; }
        public bool? istraining { get; set; }

        // public virtual icollection<role> roles { get; set; }
        public Guid id { get; set; }
        public bool isdeleted { get; set; }
        public byte[] timestamp { get; set; }
        public string name { get; set; }
    }

    public class UserAPIReponse
    {

        public Guid UserID { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }

    public class UserAPIListResponse
    {
        public IList<UserAPIRequest> usersList { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }

    }


   




}