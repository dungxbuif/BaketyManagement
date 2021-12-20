using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class RecipeDetail
    {
        public int IdMaterial { get; set; }
        public int IdRecipe { get; set; }
        public double? Amount { get; set; }
        public double? Price { get; set; }

        public virtual Material IdMaterialNavigation { get; set; }
        public virtual Recipe IdRecipeNavigation { get; set; }
    }
}
