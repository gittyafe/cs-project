using BO;

namespace BlApi;

public interface IOrder
{
    List<SaleInProduct> AddProductToOrder(Order order, int id, int quantity);
    void CalcTotalPriceForProduct(ProductInOrder product);
    void CalcTotalPrice(Order order);
    void DoOrder(Order);
    void SearchSaleForProduct(ProductInOrder product, bool isFavorite);
}
