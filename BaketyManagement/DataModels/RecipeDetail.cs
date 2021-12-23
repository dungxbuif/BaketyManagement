using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class RecipeDetail
    {
        public int IdRecipe { get; set; }
        public int IdMaterial { get; set; }
        public double? Amount { get; set; }

        public virtual Material IdMaterialNavigation { get; set; }
        public virtual Recipe IdRecipeNavigation { get; set; }
    }
}
