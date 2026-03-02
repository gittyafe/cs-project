using DalApi;
using Do;
using DO;
using System.Linq;
using static Dal.DataSource;
using Tools;
using System.Reflection;

namespace Dal;

public class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Start Create: IdCandidate={item.Id}");

        var q1 = Products.FirstOrDefault(p => p.Id == item.Id);
        if (q1 != null)
<<<<<<< HEAD
        {
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed Create - already exists: Id={item.Id}");
            throw new AlreadyExistException("there is already a product with id " + item.Id);
        }
=======
            throw new DalAlreadyExistException("there is already a product with id " + item.Id);
       
>>>>>>> 81151ff8110400e869dc4dfc23b69e08640fe3df

        int id = Config.StaticValueProduct;
        Product product = item with { Id = id };
        Products.Add(product);
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End Create: Id={id}");
        return id;

    }
    public Product Read(Func<Product, bool> filter)
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Start Read");
        var product = Products.FirstOrDefault(filter);

        if (product is null)
<<<<<<< HEAD
        {
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Failed Read - not found");
            throw new NotExistException("There is no product with this trait");
        }
=======
            throw new DalAlreadyExistException("There is no product with this trait");
>>>>>>> 81151ff8110400e869dc4dfc23b69e08640fe3df

        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End Read: Id={product.Id}");
        return product;
    }
    public List<Product> ReadAll()
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Start ReadAll");
        var q = Products.ToList();
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End ReadAll: Count={q.Count}");
        return q;
    }
    public void Update(Product item)
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Start Update: Id={item.Id}");
        Delete(item.Id);
        Products.Add(item);
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End Update: Id={item.Id}");
    }
    public void Delete(int id)
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Start Delete: Id={id}");
        var q1 = Products.FirstOrDefault(p => p.Id == id);
        if (q1 == null)
<<<<<<< HEAD
        {
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed Delete - not found: Id={id}");
            throw new NotExistException("there is no product with id " + id);
        }
=======
            throw new DalNotExistException("there is no product with id " + id);
>>>>>>> 81151ff8110400e869dc4dfc23b69e08640fe3df

        var q2 = Products.Where(p => p.Id != id).ToList();
        Products = q2;
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End Delete: Id={id}");
    }
}
