using DO;

namespace BO;

public class SaleInProduct
{
    public int SaleId { get; set; }
    public int AmountForSale { get; set; }
    public double Price { get; set; }
    public bool IsOnlyClub { get; set; }

    public SaleInProduct() : this(0, 0, 0.0, false) { }

    public SaleInProduct(int saleId, int amountForSale, double price, bool isOnlyClub)
    {
        SaleId = saleId;
        AmountForSale = amountForSale;
        Price = price;
        IsOnlyClub = isOnlyClub;
    }

    public override string ToString() =>
    this.ToStringProperty();
}
