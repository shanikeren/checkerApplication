using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    internal class Line
    {
        
            private List<OrderItem> Locked = new List<OrderItem>();
            private List<OrderItem> ToDo = new List<OrderItem>();
            private List<OrderItem> Doing = new List<OrderItem>();

          
            public string Name { get; set; }

          
            public int ServingAreaId { get; set; }

    
            public int Limit { get; set; } = -1;


            public LineState State { get; set; } = LineState.Closed;

            public List<Dish> Dishes { get; set; } = new List<Dish>();
    

    }
}
