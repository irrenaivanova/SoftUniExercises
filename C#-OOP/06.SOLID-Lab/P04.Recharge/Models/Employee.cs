namespace P04.Recharge.Models
{
    using System;
    using P04.Recharge.Interfaces;

    public abstract class Employee : Worker, ISleeper
    {
        protected Employee(string id, int workingHours) : base(id, workingHours)
        {
        }

        public void Sleep()
        {
            throw new NotImplementedException();
        }
    }
}
