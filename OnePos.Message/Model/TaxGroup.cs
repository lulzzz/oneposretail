using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePos.Message.Model
{
    public class TaxGroup
    {
        public TaxGroup()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            // TaxConfigurations = new HashSet<TaxConfiguration>();
        }

        public TaxGroup(Guid id)
        {
            Id = id;
            IsDeleted = false;
        }
        // public virtual ICollection<TaxConfiguration> TaxConfigurations { get; set; }
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Byte[] TimeStamp { get; set; }
        public string Name { get; set; }
        public List<TaxConfiguration> taxes { get; set; }
    }
}
