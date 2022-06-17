using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    public class Dish
    {
        public int lineId { get; set; }
        public int restMenuId { get; set; }
        public DishType type { get; set; }
        public int price { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public int id { get; set; }

    }

    public enum DishType
    {
        UnDefined,
        Starter,
        Main,
        Dessert,
        Drink
    }
}
