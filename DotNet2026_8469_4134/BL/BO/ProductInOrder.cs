namespace BO;

using System.Collections.Generic;
using System;

public class ProductInOrder
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public double BasePrice { get; set; }

    public int AmountInOrder { get; set; }

    public List<SaleInProduct> ListSaleInProduct { get; set; }

    // מחושב או נשמר בהתאם לחישוב מבצעים
    public double TotalPrice { get; set; }

    public ProductInOrder()
        : this(0, "", 0, 1, new List<SaleInProduct>()) { }

    public ProductInOrder(
        int productId,
        string productName,
        double basePrice,
        int amountInOrder,
        List<SaleInProduct> listSaleInProduct)
    {
        ProductId = productId;
        ProductName = productName;
        BasePrice = basePrice;
        AmountInOrder = amountInOrder;
        ListSaleInProduct = listSaleInProduct ?? new List<SaleInProduct>();
        TotalPrice = AmountInOrder * BasePrice;
    }

    // האם הפריט משתמש במבצע כלשהו
    public bool UsesSale => ListSaleInProduct != null && ListSaleInProduct.Count > 0;

    public override string ToString() =>
        this.ToStringProperty();
}