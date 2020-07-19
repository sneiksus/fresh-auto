using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Fuel { get; set; }
        public string Picture { get; set; }
        public string Transmission { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public int Power { get; set; }
        public int Km { get; set; }

        public string Url { get; set; }
    }
}
