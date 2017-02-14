using System;


namespace OnePos.Message.Model
{
    public class JobCode : IAuditable
    {
        public JobCode()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
        }

        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Byte[] TimeStamp { get; set; }
        public string Name { get; set; }

        public JobType JobType { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
