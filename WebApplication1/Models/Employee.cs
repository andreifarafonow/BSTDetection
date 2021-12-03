using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double CoordX { get; set; }

        public double CoordY { get; set; }

        public string ImgLink { get; set; }

        public bool InWork { get; set; }

        public int Fullness { get; set; } // 0-100

        public string Login { get; set; }

        public string Password { get; set; }
    }
}