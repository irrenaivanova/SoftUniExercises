using _03.Raiding.Engine;
using _03.Raiding.Factory;
using _03.Raiding.IO;

Engine engine = new Engine(new ConsoleWriter(), new ConsoleReader(), new Factory());
engine.Run();