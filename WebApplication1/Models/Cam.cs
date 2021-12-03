using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Cam
    {
        public int Id { get; set; }

        public double CoordX { get; set; }

        public double CoordY { get; set; }

        public string Address { get; set; }

        public double IsFull { get; set; }

        public string ImgLink { get; set; }

        public bool InWork { get; set; }

        public bool Gun { get; set; }

        public bool Animal { get; set; }
    }
}