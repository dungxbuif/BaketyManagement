using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class Import
    {
        public int IdImport { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ImportDetail ImportDetail { get; set; }
    }
}
