

namespace BO;

using System.Collections.Generic;

public class Order
{
    public bool IsPreferredCustomer { get; set; }
    public List<ProductInOrder> ProductsInOrder { get; set; }
    public double FinalPrice { get; set; }

    public Order() : this(false, new List<ProductInOrder>(), 0.0) { }

    public Order(bool isPreferredCustomer, List<ProductInOrder> productsInOrder, double finalPrice)
    {
        IsPreferredCustomer = isPreferredCustomer;
        ProductsInOrder = productsInOrder ?? new List<ProductInOrder>();
        FinalPrice = finalPrice;
    }
}

