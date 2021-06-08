using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

namespace Kata
{
    public class Checkout
    {
        public static List<Item> basket = new List<Item>();
        public static double total = 0;

        public static double Total()
        {
            if (basket.Count > 0)
            {
                foreach (Item i in basket)
                {
                    total += i.UnitPrice;
                }
            }

            return total;
        }

        public static void ApplyDiscount()
        {
            int itemCountB15 = 0;
            int itemCountA99 = 0;

            foreach (Item i in basket)
            {
                if (i.SKU == "B15")
                {
                    itemCountB15++;
                }

                if (i.SKU == "A99")
                {
                    itemCountA99++;
                }
            }
            
            if (itemCountB15 % 2 >= 1)
            {
                int discountNumber = itemCountB15 / 2;
                total += 0.45 * discountNumber;
                total -= 0.30 * (discountNumber * 2);
            }

            if (itemCountA99 % 3 >= 1)
            {
                int discountNumber = itemCountA99 / 3;
                total += 1.30 * discountNumber;
                total -= 0.50 * (discountNumber * 3);
            }
        }

        public static void Scan(Item item)
        {
            if (item.SKU == "A99" || item.SKU == "B15" || item.SKU == "C40")
            {
                basket.Add(item);
            }
            else
            {
                new ArgumentException("Item does not exist");
            }     
        }

    }

    public class Item
    {
        public Item() { }

        public Item(string SKU, double UnitPrice)
        {
            SKU = SKU;
            UnitPrice = UnitPrice;
        }

        public string SKU { get; set; }
        public double UnitPrice { get; set; }

    }

}
