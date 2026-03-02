using DalApi;
using Do;
using DO;
using System.Linq;
using static Dal.DataSource;

namespace Dal;

public class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        var q1 = Products.FirstOrDefault(p => p.Id == item.Id);
        if (q1 != null)
            throw new DalAlreadyExistException("there is already a product with id " + item.Id);
       

        int id = Config.StaticValueProduct;
        Product product = item with { Id = id };
        Products.Add(product);
        return id;

    }
    public Product Read(Func<Product, bool> filter)
    {
        var product = Products.FirstOrDefault(filter);

        if (product is null)
            throw new DalAlreadyExistException("There is no product with this trait");

        return product;
    }
    public List<Product> ReadAll()
    {
        var q = Products.ToList();
        return q;
    }
    public void Update(Product item)
    {
        Delete(item.Id);
        Products.Add(item);
    }
    public void Delete(int id)
    {
        var q1 = Products.FirstOrDefault(p => p.Id == id);
        if (q1 == null)
            throw new DalNotExistException("there is no product with id " + id);

        var q2 = Products.Where(p => p.Id != id).ToList();
        Products = q2;
    }
}
