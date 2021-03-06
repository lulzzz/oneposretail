//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnePos.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ExtendedBoolTableId { get; set; }
        public Nullable<System.Guid> ExtendedStringTableId { get; set; }
        public Nullable<System.Guid> ExtendedDecimalTableId { get; set; }
        public Nullable<System.Guid> ExtendedIntTableId { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable1Id { get; set; }
        public Nullable<System.Guid> ExtendedLinkTable2Id { get; set; }
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
        public Nullable<System.DateTime> Birthdate { get; set; }
        public Nullable<System.DateTime> HiredDate { get; set; }
        public Nullable<short> Sex { get; set; }
        public byte[] LoginBohPassword { get; set; }
        public string LoginKeyPassword { get; set; }
        public string LoginMagPassword { get; set; }
        public bool IsTerminated { get; set; }
        public byte[] OldBohPassword1 { get; set; }
        public byte[] OldBohPassword2 { get; set; }
        public byte[] OldBohPassword3 { get; set; }
        public byte[] OldBohPassword4 { get; set; }
        public Nullable<System.DateTime> BohPasswordDate { get; set; }
        public int BohPasswordAttempts { get; set; }
        public string BohSecretQuestion { get; set; }
        public string BohSecretAnswer { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<System.DateTime> BohLockoutDate { get; set; }
        public Nullable<long> ExternalPayrollId { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public string Country { get; set; }
        public string MobilePhone { get; set; }
        public Nullable<System.Guid> FingerPasswordId { get; set; }
        public string AltPhone { get; set; }
        public string EmployeeNumber { get; set; }
        public string MiddleName { get; set; }
        public Nullable<bool> IsTraining { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> TimePunch_Id { get; set; }
    
        public virtual ICollection<Role> Roles { get; set; }
        public virtual TimePunch TimePunch { get; set; }
    }
}
