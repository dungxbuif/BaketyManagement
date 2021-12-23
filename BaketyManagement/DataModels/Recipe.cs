using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class Recipe
    {
        public Recipe()
        {
            Cakes = new HashSet<Cake>();
            RecipeDetails = new HashSet<RecipeDetail>();
        }

        public int IdRecipe { get; set; }
        public double? Price { get; set; }
        public int? IdCategory { get; set; }
        public string NameCake { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual ICollection<Cake> Cakes { get; set; }
        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }
    }
}
