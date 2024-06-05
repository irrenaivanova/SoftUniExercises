using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            
        }

        public string Model { get; set; }
        public Engine Engine { get; set; } 
        public int? Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            string weight = Weight==null ? "n/a":Weight.ToString();
            string color = Color ?? "n/a";
            string engineDisp = Engine.Displacement == null ? "n/a": Engine.Displacement.ToString();
            string engineEffi = Engine.Efficiency == null ? "n/a": Engine.Efficiency;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");
            sb.AppendLine($"    Displacement: {engineDisp}");
            sb.AppendLine($"    Efficiency: {engineEffi}");
            sb.AppendLine($"  Weight: {weight}");
            sb.AppendLine($"  Color: {color}");

            //if (Engine.Displacement != 0)
            //{
            //    sb.AppendLine($"    Displacement: {Engine.Displacement}");
            //}
            //else
            //{
            //    sb.AppendLine($"    Displacement: n/a");
            //}
            //if (Engine.Efficiency != null)
            //{
            //    sb.AppendLine($"    Efficiency: {Engine.Efficiency}");
            //}
            //else
            //{
            //    sb.AppendLine($"    Efficiency: n/a");
            //}

            //if ( Weight != 0) 
            //{
            //    sb.AppendLine($"  Weight: {Weight}");
            //}
            //else
            //{
            //    sb.AppendLine($"  Weight: n/a");
            //}
            //if (Color != null)
            //{
            //    sb.AppendLine($"  Color: {Color}");
            //}
            //else
            //{
            //    sb.AppendLine($"  Color: n/a");
            //}

            return sb.ToString().Trim();
        }
    }
}
