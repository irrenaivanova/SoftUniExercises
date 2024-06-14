namespace Tests;

using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
public class ArenaTests
{

    [Test]
    public void ArenaConstructorShouldWorkCorrectly()
    {
        Arena arena = new Arena();
        Assert.IsNotNull(arena);
        Assert.IsNotNull(arena.Warriors);
    }

    [Test]
    public void IfCount_Work_Properly()
    {
        int expectedCount = 3;
        Arena arena = new Arena();
        for (int i = 0; i < expectedCount; i++)
        {
            arena.Enroll(new Warrior($"Ivan{i}", 10, 10));
        }
        Assert.AreEqual(expectedCount, arena.Count);
    }
    [Test]
    public void ArenaEnrollShouldWorkCorrectly()
    {
        Arena arena = new Arena();
        Warrior warrior = new("Gosho", 5, 100);

        arena.Enroll(warrior);

        Assert.IsNotEmpty(arena.Warriors);
        Assert.AreEqual(warrior, arena.Warriors.Single());
    }

    [Test]
    public void When_TryingToEnrollWarriorWithTheSameName_Throw_Exception()
    {
       
        Arena arena = new Arena();
        arena.Enroll(new Warrior("Peter", 10, 10));
        Assert.Throws<InvalidOperationException>(() => { arena.Enroll(new Warrior("Peter", 10, 10)); }, 
            "Warrior is already enrolled for the fights!");
    }

    [TestCase("Ivan","Petkan")]
    [TestCase("Petkan","Peter")]
    public void When_FightAndOneOfTheWarrierIsNull_ShouldThrowException(string name1, string name2)
    {
        Arena arena = new Arena();
        Warrior warrior1 = new Warrior("Ivan", 5, 20);
        Warrior warrior2 = new Warrior("Peter", 30, 20);

        Assert.Throws<InvalidOperationException>(() => { arena.Fight(name1,name2);},
            $"There is no fighter with name Petkan enrolled for the fights!");
    }
    [Test]
    public void IfArenaWorkProeprly()
    {
        int expAttackerHp = 70;
        int expdeFHp = 50;
        Arena arena = new();
        Warrior attacker = new Warrior("Ivan", 50, 100);
        Warrior defender = new Warrior("Peter", 30, 100);
        arena.Enroll(attacker);
        arena.Enroll(defender);
        arena.Fight(attacker.Name,defender.Name);

        Assert.AreEqual(expAttackerHp, attacker.HP);
        Assert.AreEqual(expdeFHp, defender.HP);
    }
}

