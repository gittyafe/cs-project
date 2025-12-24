using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

public class CustomerImplementation : ICustomer
{
    public int Create(Customer item)
    {
        foreach (var c in Customers)
        {
            if (item.Id == c?.Id)
                throw new AlreadyExistException();
        }
        int id = Config.StaticValue;
        Customer cust = item with { Id = id };
        Customers.Add(cust);
        return id;

    }
    public Customer? Read(int id)
    {
        foreach (var c in Customers)
        {
            if (id == c?.Id)
                return c;
            
        }
        throw new NotExistException();
    }
    public List<Customer> ReadAll()
    {
        return Customers;
    }
    public void Update(Customer item)
    {
        Delete(item.Id);
        Customers.Add(item);
    }
    public void Delete(int id)
    {
        foreach (var c in Customers)
        {
            if (id == c.Id)
            {
                Customers.Remove(c);
                return;
            }     
        }
        throw new NotExistException();

    }
}
