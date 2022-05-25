using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    public class RestMenu
    {
        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public List<Dish> Dishes { get; set; } = new List<Dish>();
    }
}

