using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWebsite.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string PhotoURL { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public int Rating { get; set; }

        //Relationships
        public List<Menu> Menus { get; set; }

    }
}
