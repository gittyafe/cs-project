

using DO;
using System.Numerics;
using System.Runtime.ConstrainedExecution;

namespace Dal;

internal static class DataSource
{
    internal static List<Product> Products = new List<Product>();
    internal static List<Customer> Customers = new List<Customer>();
    internal static List<Sale> Sales = new List<Sale>();
    internal static class Config
    {
        internal const int minimumProduct = 1000;
        internal const int minimumSale = 100;

        private static int statValueProduct = minimumProduct;
        private static int statValueSale = minimumSale;

        public static int StaticValueProduct {  get { return statValueProduct++; } }
        public static int StaticValueSale { get { return statValueSale++; } }


    }
}

