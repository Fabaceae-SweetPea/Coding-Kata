using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Linq;

namespace Kata
{
    public class Checkout
    {
        public static List<Item> basket = new List<Item>();
        public static List<Discount> availableDiscounts = new List<Discount>();
        public static double total = 0;

        public static double Total()
        {
            if (basket.Count > 0)
            {
                foreach (Item i in basket)
                {
                    total = Math.Round(total + i.UnitPrice, 2);
                }
            }

            if (basket.Count > 0)
            {
                ApplyDiscount();
            }
            return total;
        }

        public static void ApplyDiscount()
        {
            Discount discount = new Discount();
            discount.SKU = "A99";
            discount.Quantity = 3;
            discount.OfferPrice = 1.30;
            availableDiscounts.Add(discount);

            discount = new Discount();
            discount.SKU = "B15";
            discount.Quantity = 2;
            discount.OfferPrice = 0.50;
            availableDiscounts.Add(discount);

            foreach (Discount d in availableDiscounts)
            {
                int count = basket.Count(i => i.SKU == d.SKU);
                Item item = basket.Find(x => x.SKU == d.SKU);
                if (count != 0 && count % d.Quantity >= 1)
                {
                    int discountNumber = count / d.Quantity;
                    total = Math.Round(total + (d.OfferPrice * discountNumber), 2);
                    total = Math.Round(total - (item.UnitPrice * (discountNumber * d.Quantity)), 2);
                }
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

        public string SKU { get; set; }
        public double UnitPrice { get; set; }

    }

    public class Discount
    {
        public Discount() { }

        public string SKU { get; set; }
        public int Quantity { get; set; }
        public double OfferPrice { get; set; }

    }
}
