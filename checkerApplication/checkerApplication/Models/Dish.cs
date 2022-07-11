using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    public class Dish
    {
        public int lineId { get; set; }
        public int restMenuId { get; set; }
        public eDishType type { get; set; }
        public float price { get; set; }
        public int makerId { get; set; } = -1;   // what maker is mainly used to create this dish (stovetop/ oven/ etc.)
        public int makerFit { get; set; } = -1; // how many of this dish can be made at the same time inside the maker
        public float estMakeTime { get; set; } = -1; // how much time in minutes it takes to make - an estimate
        public string name { get; set; }
        public string description { get; set; }
        public int id { get; set; }

       public Dish()
        {

        }
        public Dish(int lineId, int restMenuId, eDishType type, float price, string name, string description
            ,int makerId, int makerFit, float estMakeTime)
        {
            this.lineId = lineId;
            this.restMenuId = restMenuId;
            this.type = type;
            this.price = price;
            this.name = name;
            this.description = description;
            this.makerId = makerId;
            this.makerFit = makerFit;
            this.estMakeTime = estMakeTime;
        }
    }
    
    public enum eDishType
    {
        UnDefined,
        Starter,
        Main,
        Dessert,
        Drink
    }
}
