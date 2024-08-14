namespace Gym
{
    using System;
    using Gym.Core;
    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Equipment;
    using Gym.Models.Gyms;

    public class StartUp
    {
        public static void Main()
        {
            //BoxingGym gym = new BoxingGym("boxing gum");
            //gym.AddAthlete(new Boxer("kdsjdks", "djsjd", 0));
            //gym.Exercise();
            //gym.AddEquipment(new BoxingGloves());
            //Console.WriteLine(gym.GymInfo());


            //return;
        
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
