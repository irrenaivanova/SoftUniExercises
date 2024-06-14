namespace Tests;

using FightingArena;
using NUnit.Framework;
using System;

[TestFixture]
public class WarriorTests
{
    [TestCase("Ivan",30,50)]
    [TestCase("Иван", 10000, 1000)]
    public void IfConstructorWorkProperly(string expectedName, int expectedDamage, int expectedHP)
    {
        Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);
        Assert.AreEqual(expectedName, warrior.Name);
        Assert.AreEqual(expectedDamage, warrior.Damage);
        Assert.AreEqual(expectedHP, warrior.HP);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("     ")]

    public void When_NameIsNullOrWhitespace_Should_TheConstructorThrowException (string name)
    {
        int expectedDamage = 20;
        int expectedHP = 50;
        Assert.Throws<ArgumentException>(() => { new Warrior(name, expectedDamage, expectedHP);}, 
            "Name should not be empty or whitespace!");
    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-10000)]
    public void When_DamageIsNullOrNegative_Should_TheConstructorThrowException(int damage)
    {
        string name = "Pesho";
        int expectedHP = 50;
        Assert.Throws<ArgumentException>(() => { new Warrior(name, damage, expectedHP); },
            "Damage value should be positive!");
    }

    [TestCase(-1)]
    [TestCase(-10000)]
    public void When_HPINegative_Should_TheConstructorThrowException(int hp)
    {
        string name = "Pesho";
        int damage = 50;
        Assert.Throws<ArgumentException>(() => { new Warrior(name, damage, hp); },
            "HP should not be negative!");
    }


    public void When_Attacking_ShouldThePorpertiesBe_SetProperly()
    {
        int expAttackerHp = 70;
        int expdeFHp = 50;
        Warrior attacker = new Warrior("Ivan", 50, 100);
        Warrior defender = new Warrior("Peter", 30, 100);


        Assert.AreEqual(expAttackerHp, attacker.HP);
        Assert.AreEqual(expdeFHp, defender.HP);
    }

    [TestCase(50)]
    [TestCase(60)]
    [TestCase(1000)]
    public void When_AttackingDefenderWithSmallerHP_Damage_ShouldbeSetToZero(int damageAttacker)
    {
        int expAttackerHp = 0;
        Warrior attacker = new Warrior("Ivan", damageAttacker, 100);
        Warrior defender = new Warrior("Peter", 5, 50);
        attacker.Attack(defender);
        Assert.AreEqual(expAttackerHp, defender.HP);
    }

    [TestCase(30)]
    [TestCase(29)]
    [TestCase(10)]
    public void When_AttackingWithHpSmallerOrLessThan30_ShouldThrowException(int attackerHp)
    {
        Warrior attacker = new Warrior("Ivan", 5, attackerHp);
        Warrior defender = new Warrior("Peter", 5, 50);

        Assert.Throws<InvalidOperationException>(() => { attacker.Attack(defender); }, 
            "Your HP is too low in order to attack other warriors!");
    }

    [TestCase(30)]
    [TestCase(29)]
    [TestCase(10)]
    public void When_AttackingWarriorWithHpSmallerOrLessThan30_ShouldThrowException(int deffenderHp)
    {
        Warrior attacker = new Warrior("Ivan", 5, 100);
        Warrior defender = new Warrior("Peter", 5, deffenderHp);

        Assert.Throws<InvalidOperationException>(() => { attacker.Attack(defender); },
            "Enemy HP must be greater than 30 in order to attack him!");
    }


    [Test]
    public void When_TryingToAttactStrongerEnemy_ShouldThrowException()
    {
        Warrior attacker = new Warrior("Ivan", 5, 20);
        Warrior defender = new Warrior("Peter", 30, 20);

        Assert.Throws<InvalidOperationException>(() => { attacker.Attack(defender); },
            "You are trying to attack too strong enemy");
    }
}