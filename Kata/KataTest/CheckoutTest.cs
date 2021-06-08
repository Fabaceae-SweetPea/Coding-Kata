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
            Item item1 = new Item();
            item1.SKU = "A99";
            item1.UnitPrice = 0.50;

            Item item2 = new Item();
            item2.SKU = "B15";
            item2.UnitPrice = 0.30;

            Item item3 = new Item();
            item3.SKU = "C40";
            item3.UnitPrice = 0.60;


            Checkout.Scan(item1);
            Checkout.Scan(item1);
            Checkout.Scan(item1);
            Checkout.Scan(item1);
            Checkout.Scan(item1);
            Checkout.Scan(item2);
            Checkout.Scan(item2);
            Checkout.Scan(item2);
            Checkout.Scan(item3);
            Checkout.Total();
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
        }

    }
}