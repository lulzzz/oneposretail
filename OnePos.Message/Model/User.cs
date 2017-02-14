using System;

namespace OnePos.Message.Model
{
    public class User
    {

       
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string ScreenName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string HomePhone { get; set; }
        public string Ssn { get; set; }

        public DateTime? Birthdate { get; set; }

        public DateTime? HiredDate { get; set; }


        public short? Sex { get; set; }
        public byte[] LoginBohPassword { get; set; }
        public string LoginKeyPassword { get; set; }
        public string LoginMagPassword { get; set; }
        public bool IsTerminated { get; set; }
        public byte[] OldBohPassword1 { get; set; }
        public byte[] OldBohPassword2 { get; set; }
        public byte[] OldBohPassword3 { get; set; }
        public byte[] OldBohPassword4 { get; set; }
        public DateTime? BohPasswordDate { get; set; }
        public int BohPasswordAttempts { get; set; }
        public string BohSecretQuestion { get; set; }
        public string BohSecretAnswer { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? BohLockoutDate { get; set; }
        public long? ExternalPayrollId { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string Country { get; set; }
        public string MobilePhone { get; set; }
        public Guid? FingerPasswordId { get; set; }
        public string AltPhone { get; set; }
        public string EmployeeNumber { get; set; }
        public string MiddleName { get; set; }
        public bool? IsTraining { get; set; }

       // public virtual ICollection<Role> Roles { get; set; }
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Byte[] TimeStamp { get; set; }
        public string Name { get; set; }

    }
}
