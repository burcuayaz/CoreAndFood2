using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood2.Data.Models
{
    public class Food
    {
        public int FoodID { get; set; }
        [Required(ErrorMessage = "Food Name Not Empty")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Price Not Empty")]
        public double Price { get; set; }
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Stock Not Empty")]
        public int Stock { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
