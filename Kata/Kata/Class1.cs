using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace Kata
{
    public class Checkout
    {
        private static SqlConnection Conn;
        public static List<Item> basket = new List<Item>();
        public static List<Discount> availableDiscounts = new List<Discount>();
        public static double total = 0;

        private static void CreateConnection()
        {
            string ConnStr = "Server = localhost\\SQLEXPRESS01; Database = master; Trusted_Connection = True";
            Conn = new SqlConnection(ConnStr);
        }

        public static void getDiscountData()
        {
            CreateConnection();
            string SqlString = "SELECT *  FROM [Shop].[dbo].[Offers]";
            SqlDataAdapter sda = new SqlDataAdapter(SqlString, Conn);
            DataTable dt = new DataTable();
            try
            {
                Conn.Open();
                sda.Fill(dt);
            }
            catch (SqlException se)
            {
            }
            finally
            {
                Conn.Close();
            }

            if (dt.Rows.Count > 0)
            {
                Discount discount = new Discount();
                foreach (DataRow dr in dt.Rows)
                {
                    discount = new Discount();
                    discount.SKU = dr["SKU"].ToString();
                    discount.Quantity = int.Parse(dr["Quantity"].ToString());
                    discount.OfferPrice = double.Parse(dr["OfferPrice"].ToString());
                    availableDiscounts.Add(discount);
                }
            }
        }

        public static bool checkProductExists(String SKU)
        {
            CreateConnection();
            string SqlString = "SELECT *  FROM [Shop].[dbo].[Products] WHERE [SKU] = '" + SKU + "'";
            DataTable dt = new DataTable();
            try
            {
                Conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(SqlString, Conn))
                {
                    da.Fill(dt);
                }

            }
            catch (SqlException se)
            {
            }
            finally
            {
                Conn.Close();
            }

            if (dt.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

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
            getDiscountData();

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
            if (checkProductExists(item.SKU))
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
