using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    public class Line
    {
        public int id;
        public string name { get; set; }

        public int servingAreaId { get; set; } // id of serving area related to this line

        public int limit { get; set; } = -1; // -1 means no limit

        public eLineState state { get; set; } = eLineState.Closed; // starts off closed, changes to open upon user request

        public List<Dish> dishes { get; set; } = new List<Dish>();
        public List<Maker> makers { get; set; } = new List<Maker>();


        // practicals for actions
        private List<OrderItem> Locked = new List<OrderItem>();
        private List<OrderItem> ToDo = new List<OrderItem>();
        private List<OrderItem> Doing = new List<OrderItem>();

        public Line(int limit, string name, int servingEreaID)
        {
            this.limit = limit;
            this.name = name;    
            servingAreaId = servingEreaID;
        }
    }

    
    public enum eLineState
    {
        Closed,
        Open,
        Busy
    }
}
