using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class Material
    {
        public int IdMaterial { get; set; }
        public int? IdSupplier { get; set; }
        public string NameMaterial { get; set; }
        public string Unit { get; set; }

        public virtual Supplier IdSupplierNavigation { get; set; }
    }
}
