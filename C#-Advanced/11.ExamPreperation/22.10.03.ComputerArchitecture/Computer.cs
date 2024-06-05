using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new();
        }
        public int Count {get { return Multiprocessor.Count;} }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }

        public void Add(CPU cpu)
        {
            if (Capacity>Multiprocessor.Count)
            {
                Multiprocessor.Add(cpu);
            }
        }
         public bool Remove(string brand)
        {
            CPU current = Multiprocessor.FirstOrDefault(x => x.Brand == brand);
            if (current!=null)
            {
                Multiprocessor.Remove(current);
                return true;
            }
            return false;

        }

        public CPU MostPowerful()
        {
            return Multiprocessor.OrderByDescending(x=>x.Frequency).FirstOrDefault();
        }

        public CPU GetCPU(string brand)
        {
            return Multiprocessor.FirstOrDefault(x => x.Brand == brand);
        }

        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach (CPU cpu in Multiprocessor) 
            {
                sb.AppendLine(cpu.ToString());
            }
            return sb.ToString().TrimEnd();
        } 
    }
}
