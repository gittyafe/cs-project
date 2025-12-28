using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

public class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        
        foreach (var p in Products)
        {
            if (item.Id == p?.Id)
                throw new AlreadyExistException();
        }
        int id = Config.StaticValue;
        Product product = item with { Id = id };
        Products.Add(product);
        return id;

    }
    public Product? Read(int id)
    {
        foreach (var p in Products)
        {
            if (id == p.Id)
                return p;
            
        }
        throw new NotExistException();
    }
    public List<Product> ReadAll()
    {
        return Products;
    }
    public void Update(Product item)
    {
        Delete(item.Id);
        Products.Add(item);
    }
    public void Delete(int id)
    {
        foreach (var p in Products)
        {
            if (id == p.Id)
            {
                Products.Remove(p);
                return;
            }     
        }
        throw new NotExistException();

    }
}
