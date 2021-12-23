using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class Cake
    {
        public Cake()
        {
            BilDetails = new HashSet<BilDetail>();
        }

        public int IdCake { get; set; }
        public int? IdRecipe { get; set; }
        public double? Price { get; set; }
        public int? Amount { get; set; }
        public DateTime? ExpCake { get; set; }
        public DateTime? MfgCake { get; set; }
        public string Size { get; set; }

        public virtual Recipe IdRecipeNavigation { get; set; }
        public virtual ICollection<BilDetail> BilDetails { get; set; }
    }
}
