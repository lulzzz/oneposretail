﻿using System; 

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

        public int StoreTypeId { get; set; }

        public string StoreTypeName { get; set; }

        public bool IsFirstLogin { get; set; }

        public string Address { get; set; }
        public string DBUserName { get; set; }
        public string DBPassword { get; set; }
        public string DatabaseName { get; set; } 
        public bool IsMainDB { get; set; }

    }
}
