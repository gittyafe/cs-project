using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

public class CustomerImplementation : ICustomer
{
    public int Create(Customer item)
    {

        var q1 = Customers.FirstOrDefault(c => c.Id == item.Id);
        if (q1 != null)
            throw new AlreadyExistException("there is already a customer with id " + item.Id);

        Customers.Add(item);
        return item.Id;

    }
    public Customer? Read(int id)
    {
        var q1 = Customers.FirstOrDefault(c => c.Id == id);
        if (q1 == null)
            throw new NotExistException("there is no customer with id " + id);

        return q1;
    }
    public List<Customer> ReadAll()
    {
        var q = Customers.ToList();
        return q;
    }
    public void Update(Customer item)
    {
        Delete(item.Id);
        Customers.Add(item);
    }
    public void Delete(int id)
    {
        var q1 = Customers.FirstOrDefault(s => s.Id == id);
        Console.WriteLine(q1);
        if (q1 == null)
            throw new NotExistException("there is no customer with id " + id);

        var q2 = Customers.Where(c => c.Id != id).ToList();
        Customers = q2;
    }
}
