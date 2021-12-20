using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class Supplier
    {
        public Supplier()
        {
            Materials = new HashSet<Material>();
        }

        public int IdSupplier { get; set; }
        public string NameSupplier { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}
