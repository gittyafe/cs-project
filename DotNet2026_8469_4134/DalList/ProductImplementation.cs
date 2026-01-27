using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

public class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        var q1 = Products.FirstOrDefault(p => p.Id == item.Id);
        if (q1 != null)
            throw new AlreadyExistException("there is already a product with id " + item.Id);
       

        int id = Config.StaticValueProduct;
        Product product = item with { Id = id };
        Products.Add(product);
        return id;

    }
    public Product? Read(int id)
    {
        var q1 = Products.FirstOrDefault(p => p.Id == id);
        if (q1 == null)
            throw new NotExistException("there is no product with id " + id);

        return q1;
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
            throw new NotExistException("there is no product with id " + id);

        var q2 = Products.Where(p => p.Id != id).ToList();
        Products = q2;
    }
}
