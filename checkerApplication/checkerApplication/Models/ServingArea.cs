using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    internal class ServingArea
    {

        private Dictionary<int, OrderItem> zones = new Dictionary<int, OrderItem>();

        public int RestaurantId { get; set; }

        public int ZoneNum { get; set; }

        public string Name { get; set; }

        public List<Line> Lines { get; set; } = new List<Line>();

    }
}

