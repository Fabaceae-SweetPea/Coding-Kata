using NUnit.Framework;
using Kata;
using System.IO;
using NuGet.Frameworks;
using NUnit.Framework.Internal;
using System;

namespace KataTest
{
    public class Tests
    {
        public TestContext testData { get; set; }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ScanKnownItem()
        {
            bool testSuccess;
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
            double total = Checkout.Total();

            if (total > 0)
            {
                testSuccess = true;
            }
            else
            {
                testSuccess = false;
            }

           
            Console.WriteLine("Total price is: " + total.ToString());
            Assert.IsTrue(testSuccess);
        }

        [Test]
        public void ScanUnknownItem()
        {
            Item item1 = new Item();
            item1.SKU = "D78";
            item1.UnitPrice = 0.60;

            Checkout.Scan(item1);
        }

        [Test]
        public void TotalPrice()
        {
            bool testSuccess = true;
            double total = Checkout.Total();

            if (total > 0)
            {
                testSuccess = false;
            }
            else
            {
                testSuccess = true;
            }

            Assert.IsTrue(testSuccess);
        }

    }
}