using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWebsite.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Relationships
        public int RecipeId { get; set; }
        public Recipe Recipes { get; set; }

        public int CategoriesId { get; set; }
        public Categories Category { get; set; }

    }
}
