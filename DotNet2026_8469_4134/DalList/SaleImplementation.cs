using DalApi;
using Do;
using DO;
using System.Linq;
using static Dal.DataSource;
using Tools;
using System.Reflection;

namespace Dal;

public class SaleImplementation : ISale
{
    
    public int Create(Sale item)
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Start Create: IdCandidate={item.Id}");

        var q1 = Sales.FirstOrDefault(s => s.Id == item.Id);
        if (q1 != null)
<<<<<<< HEAD
        {
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"there is already exists with id {item.Id}");
            throw new AlreadyExistException($"there is already exists with id {item.Id}");
        }
=======
            throw new DalAlreadyExistException("there is already a sale with id " + item.Id);
>>>>>>> 81151ff8110400e869dc4dfc23b69e08640fe3df

        int id = Config.StaticValueSale;
        Sale sale = item with { Id = id };
        Sales.Add(sale);
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End Create: Id={id}");
        return id;
    }
    public Sale Read(Func<Sale, bool> filter)
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Start Read");
        var sale = Sales.FirstOrDefault(filter);

        if (sale is null)
<<<<<<< HEAD
        {
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Failed Read - not found");
            throw new NotExistException("There is no sale with this trait");
        }
=======
            throw new DalNotExistException("There is no sale with this trait");
>>>>>>> 81151ff8110400e869dc4dfc23b69e08640fe3df

        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End Read: Id={sale.Id}");
        return sale;
    }
    public List<Sale> ReadAll()
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Start ReadAll");
        var q = Sales.ToList();
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End ReadAll: Count={q.Count}");
        return q;
    }
    public void Update(Sale item)
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Start Update: Id={item.Id}");
        Delete(item.Id);
        Sales.Add(item);
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End Update: Id={item.Id}");
    }
    public void Delete(int id)
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Start Delete: Id={id}");
        var q1 = Sales.FirstOrDefault(s => s.Id == id);
        Console.WriteLine( q1);
        if (q1 == null)
<<<<<<< HEAD
        {
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"there is no sale with id {id}");
            throw new NotExistException($"there is no sale with id {id}");
        }
=======
            throw new DalNotExistException("there is no sale with id " + id);
>>>>>>> 81151ff8110400e869dc4dfc23b69e08640fe3df

        var q2 = Sales.Where(s=>s.Id!=id).ToList();
        Sales = q2;
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End Delete: Id={id}");
    }
}
