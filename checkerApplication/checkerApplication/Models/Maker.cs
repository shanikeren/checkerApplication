using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    public class Maker
    {
        public string name { get; set; }
        public string line { get; set; }
        public int id { get; set; }

        public Maker(string name, string line)
        {
            this.name = name;
            this.line = line;
        }
    }
}
