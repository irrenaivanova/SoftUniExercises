using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private Athlete testAthlete;
        private Gym testGym;

        [SetUp]
        public void Setup()
        {
            testAthlete = new Athlete("Ivan");
            testGym = new Gym("Irena", 20);
        }
        [Test]
        public void AthleteConstructorWorks_Correctly_WithTheName()
        {
            Assert.AreEqual(testAthlete.FullName, "Ivan");
        }

        [Test]
        public void AthleteConstructorWorks_Correctly_IsInjured()
        {
            Assert.AreEqual(testAthlete.IsInjured, false);
        }

        [Test]
        public void GymConstructorWorks_Correctly_WithTheName()
        {
            Assert.AreEqual(testGym.Name, "Irena");
            Assert.AreEqual(20, testGym.Capacity);
            Assert.AreEqual(0, testGym.Count);
        }


        [TestCase("")]
        [TestCase(null)]
        public void IsItThrown_Exception_WhenEmptyName(string name)
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 20);
            });
        }

        [TestCase(-1000)]
        [TestCase(-5)]
        public void IsItThrown_Exception_WhenWrongCapacity(int cap)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Iren", cap);
            });
        }

        [Test]
        public void CountWorkProperly()
        {
            testGym.AddAthlete(testAthlete);
            Assert.AreEqual(1, testGym.Count);
        }

        [Test]
        public void ThrowsException_WhenCapacityFull()
        {
            Gym gym = new Gym("Super sme", 1);
            gym.AddAthlete(testAthlete);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(testAthlete);
            });
        }

        [Test]
        public void ThrowsException_WhenRemoving()
        {
            testGym.AddAthlete(testAthlete);
            Assert.Throws<InvalidOperationException>(() => { testGym.RemoveAthlete("Petkan"); });
        }

        [Test]
        public void ProperCount_WhenRemoving()
        {
            testGym.AddAthlete(testAthlete);
            testGym.AddAthlete(new Athlete("Petkan"));
            testGym.RemoveAthlete("Petkan");
            Assert.AreEqual(1,testGym.Count);
        }

        [Test]
        public void ThrowsException_WhenInJuring()
        {
            testGym.AddAthlete(testAthlete);
            Assert.Throws<InvalidOperationException>(() => { testGym.InjureAthlete("Petkan"); });
        }

        [Test]
        public void IsReallyInjured()
        {
            testGym.AddAthlete(testAthlete);
            var injured = testGym.InjureAthlete("Ivan");
            Assert.AreEqual(injured.IsInjured, true);
        }

        [Test]
        public void ReportWorkCorrectly()
        {
            testGym.AddAthlete(testAthlete);
            testGym.AddAthlete(new Athlete("Petkan"));
            Assert.AreEqual("Active athletes at Irena: Ivan, Petkan", testGym.Report());
        }
    }
}
