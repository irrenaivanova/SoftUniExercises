using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007.RawData
{
    public class Car
    {
        public Car(string model,int speed, int power,int weight, string type,float press1, int age1, float press2, int age2, float press3, int age3, float press4, int age4) 
        {
            Model = model;
            Engine.Speed = speed;
            Engine.Power = power;
            Cargo.Weight = weight;
            Cargo.Type = type;
            Tires[0] = new Tires(age1, press1);
            Tires[1] = new Tires(age2, press2);
            Tires[2] = new Tires(age3, press3);
            Tires[3] = new Tires(age4, press4);
        }
        public string Model { get; set; }
        public Engine Engine { get; set; } = new Engine();
        public Cargo Cargo { get; set; }=new Cargo();
        public Tires[] Tires { get; set; } = new Tires[4];
    }
}
