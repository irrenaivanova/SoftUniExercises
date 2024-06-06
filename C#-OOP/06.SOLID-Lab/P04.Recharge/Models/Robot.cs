using System;
using System.Collections.Generic;
using System.Text;
using P04.Recharge.Interfaces;

namespace P04.Recharge.Models
{
    public class Robot : Worker, IRechargeable
    {
        public Robot(string id, int workingHours) : base(id, workingHours)
        {
        }

        public int Capacity { get; private set; }


        public int CurrentPower { get; private set; }
     
        public void Work(int hours)
        {
            if (hours > CurrentPower)
            {
                hours = CurrentPower;
            }

            base.Work(hours);
            CurrentPower -= hours;
        }

        public  void Recharge()
        {
            CurrentPower = Capacity;
        }

    }
}