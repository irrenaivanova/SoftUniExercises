//using System;
//using System.Linq;
//using System.Reflection;
//using NUnit.Framework;
//using Bakery;

//// ReSharper disable CheckNamespace
//// ReSharper disable InconsistentNaming

//[TestFixture]
//public class Structure_000_003_EntityTypesTables
//{
//    // MUST exist within project, otherwise a Compile Time Error will be thrown.
//    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

//    [Test]
//    public void ValidateFoodsExist()
//    {
//        var typesToAssert = new[]
//        {
//            "ITable",
//            "Table",
//            "InsideTable",
//            "OutsideTable",
//        };

//        foreach (var typeName in typesToAssert)
//        {
//            Assert.That(GetType(typeName), Is.Not.Null, $"{typeName} type doesn't exist!");
//        }
//    }

//    private static Type GetType(string name)
//    {
//        var type = ProjectAssembly
//            .GetTypes()
//            .FirstOrDefault(t => t.Name == name);

//        return type;
//    }
//}