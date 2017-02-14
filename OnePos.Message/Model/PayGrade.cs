using System;


namespace OnePos.Message.Model
{
    public class PayGrade 
    {
        public PayGrade()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
        }


        public decimal WageRate { get; set; }
        public decimal TipTaxRate { get; set; }
        public bool IsSalaried { get; set; }
        public bool OtAppliedByDayHours { get; set; }
        public decimal WageRateOnOverTime { get; set; }
        public bool BreaksArePaid { get; set; }
        public decimal OtHoursThreshold { get; set; }
        public bool IsEligibleForOvertimePay { get; set; }
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Byte[] TimeStamp { get; set; }
        public string Name { get; set; }


    }
}
