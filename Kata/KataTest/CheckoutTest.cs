using NUnit.Framework;
using Kata;
using System.IO;

namespace KataTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ScanKnownItem()
        {
            Item item1 = new Item("A99", 0.50);
            Item item2 = new Item("B15", 0.30);
            Item item3 = new Item("C40", 0.60);

            Checkout.Scan(item1);
            Checkout.Scan(item1);
            Checkout.Scan(item1);
            Checkout.Scan(item1);
            Checkout.Scan(item1);
            Checkout.Scan(item2);
            Checkout.Scan(item2);
            Checkout.Scan(item2);
            Checkout.Scan(item3);
        }

        [Test]
        public void ScanUnknownItem()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void TotalPrice()
        {
            Checkout.Total();
            Checkout.ApplyDiscount();
        }

    }
}