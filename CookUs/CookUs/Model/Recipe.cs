using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RecipeTime { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Steps { get; set; }
        
    }
}
