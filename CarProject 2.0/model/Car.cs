using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0.model
{
    public class Car
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public TuningPart TuningPart { get; set; } 


        public Car(string name, string brand, string model, TuningPart tuningPart)
        {
            Name = name;
            Brand = brand;
            Model = model;
            TuningPart = tuningPart;
        }
    }

}
