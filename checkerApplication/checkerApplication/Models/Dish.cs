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

       public Dish()
        {

        }
        public Dish(int lineId, int restMenuId, DishType type, int price, string name, string description)
        {
            this.lineId = lineId;
            this.restMenuId = restMenuId;
            this.type = type;
            this.price = price;
            this.name = name;
            this.description = description;
        }
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
