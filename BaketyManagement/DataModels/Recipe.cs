using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class Recipe
    {
        public int IdRecipe { get; set; }
        public int? IdCategory { get; set; }
        public string NameCake { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
    }
}
