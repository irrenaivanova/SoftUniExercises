using Gym.Models.Athletes;
using Gym.Models.Equipment;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core.Contracts
{
    public class Controller : IController
    {
        private EquipmentRepository equipmentRepository = new EquipmentRepository();
        private ICollection<IGym> gyms = new List<IGym>();
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (!(athleteType == "Boxer" || athleteType== "Weightlifter"))
            {
               throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            var typeOfGym = gym.GetType().Name;

            if (athleteType == "Boxer" && typeOfGym == "BoxingGym")
            {
                gym.AddAthlete(new Boxer(athleteName, motivation, numberOfMedals));
                return string.Format(OutputMessages.EntityAddedToGym,athleteType,gymName);
            }

            if (athleteType == "Weightlifter" && typeOfGym == "WeightliftingGym")
            {
                gym.AddAthlete(new Weightlifter(athleteName, motivation, numberOfMedals));
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
            return OutputMessages.InappropriateGym;
        }

        public string AddEquipment(string equipmentType)
        {
           if (equipmentType == "BoxingGloves")
            {
                equipmentRepository.Add(new BoxingGloves());
            }
           else if (equipmentType == "Kettlebell")
            {
                equipmentRepository.Add(new Kettlebell());
            }
           else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                gyms.Add(new BoxingGym(gymName));
            }
            else if (gymType == "WeightliftingGym")
            {
                gyms.Add(new WeightliftingGym(gymName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var eqToAdd = equipmentRepository.Models.FirstOrDefault(x => x.GetType().Name == equipmentType);
            if (eqToAdd == null)
            {
               throw new InvalidOperationException( string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            gym.AddEquipment(eqToAdd);
            equipmentRepository.Remove(eqToAdd);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType,gymName);
        }

        public string Report()
        {
            return string.Join("\n", gyms.Select(x => x.GymInfo()));
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            gym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count());
        }
    }
}
