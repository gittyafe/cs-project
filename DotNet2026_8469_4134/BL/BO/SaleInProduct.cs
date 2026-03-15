namespace BO;

public class SaleInProduct
{
    public int SaleID { get; set; }
    public int AmountToSale { get; set; }
    public double Price { get; set; }
    public bool IsToClub { get; set; }

    public SaleInProduct() : this(0, 0, 0.0, false) { }

    public SaleInProduct(int saleID, int amountToSale, double price, bool isToClub)
    {
        SaleID = saleID;
        AmountToSale = amountToSale;
        Price = price;
        IsToClub = isToClub;
    }
}
