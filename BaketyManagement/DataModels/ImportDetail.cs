using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class ImportDetail
    {
        public int IdMaterial { get; set; }
        public int? IdImport { get; set; }
        public double? Amount { get; set; }
        public double? Price { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Material IdMaterial1 { get; set; }
        public virtual Import IdMaterialNavigation { get; set; }
    }
}
