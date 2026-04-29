

namespace BO;

using System.Collections.Generic;
using System.Xml.Linq;

public class Order
{
    public bool IsClub { get; set; }
    public List<ProductInOrder> ProductsInOrder { get; set; }
    public double FinalPrice { get; set; }

    public Order() : this(false, new List<ProductInOrder>(), 0.0) { }

    public Order(bool isClub, List<ProductInOrder> productsInOrder, double finalPrice)
    {
        IsClub = isClub;
        ProductsInOrder = productsInOrder ?? new List<ProductInOrder>();
        FinalPrice = finalPrice;
    }

    public override string ToString() =>
            this.ToStringProperty();

}

