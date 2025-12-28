using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

public class SaleImplementation : ISale
{
    
    public int Create(Sale item)
    {

        foreach (var s in Sales)
        {
            if (item.Id == s?.Id)
                throw new AlreadyExistException();
        }
        int id = Config.StaticValue;
        Sale sale = item with { Id = id };
        Sales.Add(sale);
        return id;

    }
    public Sale? Read(int id)
    {
        foreach (var s in Sales)
        {
            if (id == s.Id)
                return s;

        }
        throw new NotExistException();
    }
    public List<Sale> ReadAll()
    {
        return Sales;
    }
    public void Update(Sale item)
    {
        Delete(item.Id);
        Sales.Add(item);
    }
    public void Delete(int id)
    {
        foreach (var s in Sales)
        {
            if (id == s.Id)
            {
                Sales.Remove(s);
                return;
            }
        }
        throw new NotExistException();
    }
}
