using _04.VehicleExtension.Core;
using _04.VehicleExtension.Factories;
using _04.VehicleExtension.IO;

Engine engine = new Engine(new ConsoleReader(), new ConsoleWriter(), new VehicleFactory());
engine.Run();