
namespace BlApi;

public interface IProduct:ICrud<BO.Product>
{
    void GetAllRelevantSalesForProduct(BO.ProductInOrder product, bool isFavorite);
}
