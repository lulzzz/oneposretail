using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePos.Message.Model
{
    public class TaxConfiguration
    {
        public TaxConfiguration()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
        }

        public bool AlwaysRunTax { get; set; }
        public bool IsInclusiveTax { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public bool RunMonday { get; set; }
        public bool RunTuesday { get; set; }
        public bool RunWednesday { get; set; }
        public bool RunThursday { get; set; }
        public bool RunFriday { get; set; }
        public bool RunSaturday { get; set; }
        public bool RunSunday { get; set; }

        public decimal Rate { get; set; }
        public bool IsFlatFee { get; set; }
        public decimal FlatFee { get; set; }
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Byte[] TimeStamp { get; set; }
        public string Name { get; set; }

    }
}
