

namespace BO;
using System;

public class Sale
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int QuantityRequired { get; set; }
    public double TotalPrice { get; set; }
    public bool IsOnlyClub { get; set; }
    public DateTime StartSale { get; set; }
    public DateTime EndSale { get; set; }

    public Sale() : this(0, -1, 0, 0.0, false, DateTime.Now, DateTime.Now) { }

    public Sale(int id, int productId, int quantityRequired, double totalPrice, bool isOnlyClub, DateTime startSale, DateTime endSale)
    {
        Id = id;
        ProductId = productId;
        QuantityRequired = quantityRequired;
        TotalPrice = totalPrice;
        IsOnlyClub = isOnlyClub;
        StartSale = startSale;
        EndSale = endSale;
    }
}

