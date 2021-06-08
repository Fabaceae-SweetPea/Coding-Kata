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
            Item firstItem = new Item("A99", 0.50);

            Checkout.Scan(firstItem);

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