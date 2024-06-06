using P04.Recharge.Interfaces;

namespace P04.Recharge.Models
{
    public abstract class Worker : IWorker
    {
        protected Worker(string id, int workingHours)
        {
            Id = id;
            WorkingHours = workingHours;
        }

        public string Id {get;private set;}

        public int WorkingHours { get; private set; }

        public void Work(int hours)
        {
            WorkingHours += hours;
        }
    }
}