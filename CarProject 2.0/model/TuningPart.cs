using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0.model
{
    public class TuningPart
    {
        public Guid Id { get; set; }
        public string Engine { get; set; }
        public string Spoiler { get; set; }
        public string Brake { get; set; }
        public string Tires { get; set; }
        public string Nitrous { get; set; }
        public double Price { get; set; }


        public TuningPart(string engine, string spoiler, string brake, string tires, string nitrous, double price)
        {
            Engine = engine;
            Spoiler = spoiler;
            Brake = brake;
            Tires = tires;
            Nitrous = nitrous;
            Price = price;
        }

        public TuningPart()
        {

        }
    }
}
