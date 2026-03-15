
namespace BO;

using System.Collections.Generic;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public double Price { get; set; }
    public int QuantityInStack { get; set; }
    public List<SaleInProduct> ListSaleInProduct { get; set; }

    public Product() : this(-1, "", Category.CHOCOLATE, 0.0, 0, new List<SaleInProduct>()) { }

    public Product(int id, string name, Category category, double price, int quantityInStack, List<SaleInProduct> listSaleInProduct)
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        QuantityInStack = quantityInStack;
        ListSaleInProduct = listSaleInProduct ?? new List<SaleInProduct>();
    }
}

