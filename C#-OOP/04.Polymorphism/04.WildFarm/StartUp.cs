using _04.WildFarm.Core;
using _04.WildFarm.Factories.Interfaces;
using _04.WildFarm.IO;

Engine engine = new Engine(new ConsoleWriter(),new ConsoleReader(),new FactoryAnimal(),new FactoryFood());
engine.Run();

Console.ReadLine();