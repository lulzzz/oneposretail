using System; 

namespace OnePos.Message.Model
{
    public class Store
    {
        public long ID { get; set; }
        public string StoreName { get; set; }
        public string StoreOwnerName { get; set; }
        public string StoreUniqueKey { get; set; }
        public string StoreAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string LicenseExpiry { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
        public int StoreStatusId { get; set; }

    }
}
