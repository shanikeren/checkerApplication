using System;
using System.Collections.Generic;
using System.Text;

namespace checkerApplication.Models
{
    public class Restaurant
    {
        public int id { get; set; }
        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string phone { get; set; }

        public string contactName { get; set; }

        public List<RestMenu> menus { get; set; } = new List<RestMenu>();

        public List<Line> lines { get; set; }

        public List<ServingArea> servingAreas { get; set; } = new List<ServingArea>();
        public List<Maker> makers { get; set; } = new List<Maker>();
        public Restaurant(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.phone = "0525381648";
            this.contactName = "Anna Zak";
            lines =  new List<Line>();
        }
        public Restaurant() {
            lines = new List<Line>();
        }
    }
}

