using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class Material
    {
        public Material()
        {
            MaterialStores = new HashSet<MaterialStore>();
            RecipeDetails = new HashSet<RecipeDetail>();
        }

        public int IdMaterial { get; set; }
        public int? IdSupplier { get; set; }
        public string NameMaterial { get; set; }
        public string Unit { get; set; }

        public virtual Supplier IdSupplierNavigation { get; set; }
        public virtual ImportDetail ImportDetail { get; set; }
        public virtual ICollection<MaterialStore> MaterialStores { get; set; }
        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }
    }
}
