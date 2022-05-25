using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    public class Restaurant
    {
        public string Name { get; set; }

        private string Email { get; set; }

        private string Password { get; set; }

        public string Phone { get; set; }

        public string ContactName { get; set; }

        public List<RestMenu> Menus { get; set; } = new List<RestMenu>();

        public List<Line> Lines { get; set; } = new List<Line>();

        public List<ServingArea> ServingAreas { get; set; } = new List<ServingArea>();
    }
}

