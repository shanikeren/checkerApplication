using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    public class RestMenu
    {
        public int restaurantId { get; set; }

        public string name { get; set; }

        public List<Dish> dishes { get; set; } = new List<Dish>();
        public int id { get; set; }

        public RestMenu(int restaurantId, string name)
        {
            this.restaurantId = restaurantId;
            this.name = name;
        }
    }
}

