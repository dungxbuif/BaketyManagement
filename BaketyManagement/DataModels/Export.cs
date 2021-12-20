using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class Export
    {
        public int IdExport { get; set; }
        public int? IdRecipe { get; set; }
        public int? Amount { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Recipe IdRecipeNavigation { get; set; }
    }
}
