using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    public class ServingArea
    {

        //private Dictionary<int, OrderItem> zones = new Dictionary<int, OrderItem>();

        public int restaurantId { get; set; }

        public int zoneNum { get; set; }

        public string name { get; set; }

        public List<Line> lines { get; set; } = new List<Line>();

        public int id;

        //zoomNum is the limit for me 
        public ServingArea(int restaurantId, int zoneNum, string name)
        {
            this.restaurantId = restaurantId;
            this.zoneNum = zoneNum;
            this.name = name;
        }
    }
}

