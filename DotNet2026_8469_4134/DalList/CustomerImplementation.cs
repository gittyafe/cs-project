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
                throw new AlreadyExistException("there is already a customer with id " + item.Id);
        }
        Customers.Add(item);
        return item.Id;

    }
    public Customer? Read(Func<Customer, bool> filter)
    {
        foreach (var c in Customers)
        {
            if (filter(c))
                return c;
        }
        throw new NotExistException("there is no customer with this trait");
    }
    public List<Customer> ReadAll()
    {
        return new List<Customer>(Customers);
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
        throw new NotExistException("there is no customer with id " + id);

    }
}
