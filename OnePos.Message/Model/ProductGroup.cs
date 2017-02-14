using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePos.Message.Model
{
    public class ProductGroup
    {
        public ProductGroup(Guid id)
        {
            Id = id;
            IsDeleted = false;
        }


        public string ProductgroupColor { get; set; }
        public int MenuPosition { get; set; }
        public bool CanDiscountGroup { get; set; }
        public bool UseDriversAgeVerification { get; set; }
        public bool ApplyGroupPrice { get; set; }
        public decimal GroupPrice { get; set; }
        public bool OrderMenuItemsByWeight { get; set; }

       
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Byte[] TimeStamp { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name ?? "";
        }
    }
}
