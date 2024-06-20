using BankSafe;
using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault testBank;
        private Item testItem;

        [SetUp]
        public void Setup()
        {
            testBank = new BankVault();
            testItem = new Item("az", "test");
        }

        [Test]
        public void IfConstructor_WorkCOrrecly_AndInitialise_ACorrectDictionary()
        {
            Assert.AreEqual(testBank.VaultCells.Count, 12);
        }


        [TestCase("A1")]
        [TestCase("B4")]
        [TestCase("C1")]
        [TestCase("C4")]
        public void IfConstructor_WorkCorrecly_And_TheCelss_HasNullValues(string nameCell)
        {
            Assert.AreEqual(testBank.VaultCells[nameCell], null);
        }

        [TestCase("A7")]
        [TestCase("B0")]
        public void When_AddingAnItem_AndThereIsNoSuchName_ShouldThrowAnException(string cell)
        {

            var ex = Assert.Throws<ArgumentException>(() => testBank.AddItem(cell, testItem));
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");

        }
        [Test]
        public void When_AddingAnItem_AndTheCellIsAlreadyFull_ShouldThrowAnException()
        {
            testBank.AddItem("A1", testItem);
            var ex = Assert.Throws<ArgumentException>(() => testBank.AddItem("A1", testItem));
            Assert.AreEqual(ex.Message, "Cell is already taken!");

        }
        [TestCase("A2")]
        [TestCase("B1")]
        public void When_AddingAnItem_AndTheItemALreadyExist_ShouldThrowAnException(string cell)
        {
            testBank.AddItem("A1", testItem);
            var ex = Assert.Throws<InvalidOperationException>(() => testBank.AddItem(cell, testItem));
            Assert.AreEqual(ex.Message, "Item is already in cell!");
        }

        [Test]
        public void When_AddingAnItem_The_Item_IsAddedCorrectly()
        {
            testBank.AddItem("A1", testItem);
            Assert.AreEqual(testBank.VaultCells["A1"], testItem);
        }

        [Test]
        public void When_AddingAnItem_IsRETurn_TheCorrectMessage()
        {
            string adding = testBank.AddItem("A1", testItem);
            Assert.AreEqual(adding, $"Item:{testItem.ItemId} saved successfully!");
        }

        [TestCase("A7")]
        [TestCase("B0")]
        public void When_RemovingAnItem_AndThereIsNoSuchName_ShouldThrowAnException(string cell)
        {

            var ex = Assert.Throws<ArgumentException>(() => testBank.RemoveItem(cell, testItem));
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");

        }

        [Test]
        public void When_RemovingAnItem_AndThereIsNoSuchItem_ShouldThrowAnException()
        {
            var ex = Assert.Throws<ArgumentException>(() => testBank.RemoveItem("A1", testItem));
            Assert.AreEqual(ex.Message, "Item in that cell doesn't exists!");

        }

        [Test]
        public void When_RemovingAnItem_The_Item_IsRemovedCorrectly()
        {
            testBank.AddItem("A1", testItem);
            testBank.RemoveItem("A1", testItem);
            Assert.AreEqual(testBank.VaultCells["A1"], null);
        }

        [Test]
        public void When_RemovingAnItem_IsRETurn_TheCorrectMessage()
        {
            testBank.AddItem("A1", testItem);
            string removing = testBank.RemoveItem("A1", testItem);
            Assert.AreEqual(removing, $"Remove item:{testItem.ItemId} successfully!");
        }


    }
}
