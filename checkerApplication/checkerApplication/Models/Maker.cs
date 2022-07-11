using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    public class Maker
    {
        public string name { get; set; }
        public int lineId { get; set; }
        public int id { get; set; }

        public Maker(string name, int lineId)
        {
            this.name = name;
            this.lineId = lineId;
        }
    }
}
