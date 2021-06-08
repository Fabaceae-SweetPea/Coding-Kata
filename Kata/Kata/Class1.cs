﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Kata
{
    public class Checkout
    {
        public static List<Item> basket = new List<Item>();

        public static double Total()
        {
            double total = 0;

            if (basket.Count > 0)
            {
                foreach (Item i in basket)
                {
                    total += i.UnitPrice;
                }
            }

            return total;
        }

        public static void Scan(Item item)
        {
            basket.Add(item);
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
