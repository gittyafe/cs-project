
using System.Linq;

namespace BlImplementation;

internal class ProductImplementation : BlApi.IProduct
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public int Create(BO.Product product)
    {
        try
        {
            DO.Product doProduct = BO.Tools.ToDO(product);
            return _dal.Product.Create(doProduct);
        }
        catch (DO.DalAlreadyExistException ex)
        {
            throw new BO.BlAlreadyExistException("Product already exists", ex);
        }
    }
    
    public List<BO.Product> ReadAll(Func<BO.Product, bool> filter)
    {
        try
        {
            var products = _dal.Product.ReadAll(x=>true);
            var boProducts = from product in products
                             let bs = BO.Tools.ToBO(product)
                          where filter(bs)
                          select bs;
            return boProducts.ToList();

        }
        catch (DO.DalException ex)
        {
            throw new BO.BlException("Error reading products", ex);
        }
    }
    public BO.Product Read(Func<BO.Product, bool> filter)
    {
        try
        {
            var product = _dal.Product.ReadAll(x => true).Select(s=> BO.Tools.ToBO(s)).FirstOrDefault(filter);
            return product;
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BlNotExistException("Error reading products", ex);
        }
    }
    public void Update(BO.Product item)
    {
        try
        {
            var product = BO.Tools.ToDO(item);
            _dal.Product.Update(product);
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BlNotExistException("Error updating products", ex);
        }
    }
    public void Delete(int id)
    {
        try
        { 
            _dal.Product.Delete(id);
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BlNotExistException("Error deleting products", ex);
        }
    }

    public void GetAllRelevantSalesForProduct(BO.ProductInOrder product, bool isFavorite)
    {
        //?????????????????????????????????????????????????????
    }
}
