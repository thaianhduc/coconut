using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Coconut.Tryout
{
    public class Order
    {
        public string Customer { get; set; }
        public DateTime OrderedAt { get; set; }
        public decimal TotalCost { get; set; }
        public int NumberOfProducts { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var orders = GetOrders();
            var data = BuildData(orders);
            WriteToFile(data);
        }

        private static IList<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order{Customer = "Batman", TotalCost = 100000, OrderedAt = DateTime.Today.AddDays(-3)},
                new Order{Customer = "Superman", TotalCost = 1000, OrderedAt = DateTime.Today.AddDays(-2)},
                new Order{Customer = "Spiderman", TotalCost = 100, OrderedAt = DateTime.Today.AddDays(-1)}
            };
        }

        private static IList<IList<string>> BuildData(IList<Order> orders)
        {
            // Initialize rows with header
            var rows = new List<IList<string>>
            {
                new List<string> {"Customer", "Total Cost", "Ordered At"}
            };
            // Add rows data for each order
            foreach (var order in orders)
            {
                rows.Add(new List<string>
                {
                    order.Customer,
                    order.TotalCost.ToString(CultureInfo.CurrentCulture),
                    order.OrderedAt.ToString(CultureInfo.CurrentCulture)
                });
            }
            return rows;
        }

        private static void WriteToFile(IList<IList<string>> data)
        {
            const string deliminator = ";";
            var fullPathToCsvFile = @"d:\export\orders.csv";
            var csvData = data.Select(a => string.Join(deliminator, a))
                .ToList();
            File.WriteAllLines(fullPathToCsvFile, csvData, Encoding.Unicode);
        }
    }
}