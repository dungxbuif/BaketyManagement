using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class MaterialStore
    {
        public int IdMaterialStore { get; set; }
        public int? IdMaterial { get; set; }
        public double? Amount { get; set; }

        public virtual Material IdMaterialNavigation { get; set; }
    }
}
