using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

public class SaleImplementation : ISale
{
    
    public int Create(Sale item)
    {
        var q1 = Sales.FirstOrDefault(s => s.Id == item.Id);
        if (q1 != null)
            throw new AlreadyExistException("there is already a sale with id " + item.Id);

        int id = Config.StaticValueSale;
        Sale sale = item with { Id = id };
        Sales.Add(sale);
        return id;
    }
    public Sale? Read(int id)
    {
        var q1 = Sales.FirstOrDefault(s=>s.Id==id);
        if (q1 == null)
            throw new NotExistException("there is no sale with id " + id);

        return q1;
    }
    public List<Sale> ReadAll()
    {
        var q = Sales.ToList();
        return q;
    }
    public void Update(Sale item)
    {
        Delete(item.Id);
        Sales.Add(item);
    }
    public void Delete(int id)
    {
        var q1 = Sales.FirstOrDefault(s => s.Id == id);
        Console.WriteLine( q1);
        if (q1 == null)
            throw new NotExistException("there is no sale with id " + id);

        var q2 = Sales.Where(s=>s.Id!=id).ToList();
        Sales = q2;
    }
}
