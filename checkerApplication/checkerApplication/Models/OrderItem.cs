using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    public class OrderItem
    {
        public Dish Dish { get; set; }

        public int DishId { get; set; }

        public int OrderId { get; set; }

        public int ServingAreaZone { get; set; }

        public string Changes { get; set; }

        public ItemStatus Status { get; set; } = ItemStatus.Ordered;

        public LineItemStatus LineStatus { get; set; } = LineItemStatus.Locked;
    }

    public enum LineItemStatus
    {
        Locked,
        ToDo,
        Doing,
        Done,
        Rejected,
    }

    public enum ItemStatus
    {
        Ordered,
        AtLine,
        WaitingToBeServed,
        Served,
        Returned,
    }
}

