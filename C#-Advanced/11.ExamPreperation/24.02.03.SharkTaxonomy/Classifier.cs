using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new();
        }

        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }
        public int GetCount => Species.Count; 

        public void AddShark(Shark shark)
        {
            if (Species.Count < Capacity && !Species.Any(x=>x.Kind==shark.Kind)) 
            { 
                Species.Add(shark);
            }
        }
        public bool RemoveShark(string kind)
        {
            if(Species.Any(x=>x.Kind==kind)) 
            {
                Species.Remove(Species.First((x => x.Kind == kind)));
                return true;
            }
            return false;
        }
        public string GetLargestShark()
        { 
           return  Species.OrderByDescending(x => x.Length).FirstOrDefault().ToString();
           
        }
        public double GetAverageLength()
        {
            double average = Species.Select(x => x.Length).Average();
            return average;
        }
        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{GetCount} sharks classified:");
            foreach (Shark shark in Species)
            {
                sb.AppendLine(shark.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
