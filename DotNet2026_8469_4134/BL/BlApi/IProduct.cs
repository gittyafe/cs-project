using BO;

namespace BlApi;

public interface IProduct:ICrud<Product>
{
    void GetAllRelevantSalesForProduct(ProductInOrder product, bool isFavorite);
}
