

namespace BO;
using System.Collections.Generic;

public class ProductInOrder
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double BasePrice { get; set; }
    public int AmountInOrder { get; set; }
    public List<SaleInProduct> ListSaleInProduct { get; set; }
    public double TotalPrice { get; set; }

    public ProductInOrder() : this(1, "", 0.0, 1, new List<SaleInProduct>(), 0.0) { }

    public ProductInOrder(int productId, string productName, double basePrice, int amountInOrder, List<SaleInProduct> listSaleInProduct, double totalPrice)
    {
        ProductId = productId;
        ProductName = productName;
        BasePrice = basePrice;
        AmountInOrder = amountInOrder;
        ListSaleInProduct = listSaleInProduct ?? new List<SaleInProduct>();
        TotalPrice = totalPrice;
    }

    public override string ToString() =>
    $"ProductId: {ProductId}, ProductName: {ProductName}, BasePrice: {BasePrice}, TotalPrice: {TotalPrice}, AmountInOrder: {AmountInOrder}, ListSaleInProduct: {ListSaleInProduct}";

}
