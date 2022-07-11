using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    public class Line
    {
        public string name { get; set; }

        public int servingAreaId { get; set; } // id of serving area related to this line

        public int limit { get; set; } = -1; // -1 means no limit

        public eLineState state { get; set; } = eLineState.Closed; // starts off closed, changes to open upon user request

        public List<Dish> dishes { get; set; } = new List<Dish>();
        public List<Maker> makers { get; set; } = new List<Maker>();
        public int id { get; set; }


        public Line(int limit, string name, int servingAreaID)
        {
            this.limit = limit;
            this.name = name;    
            servingAreaId = servingAreaID;
        }
    }

    
    public enum eLineState
    {
        Closed,
        Open,
        Busy
    }
}
