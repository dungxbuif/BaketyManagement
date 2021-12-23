using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class Import
    {
        public int IdImport { get; set; }
        public int? IdMaterial { get; set; }
        public double? Amount { get; set; }
        public double? Price { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Material IdMaterialNavigation { get; set; }
    }
}
