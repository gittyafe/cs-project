using DO;
using DalApi;
using static Dal.DataSource;
using Tools;
using System.Reflection;

namespace Dal;

public class CustomerImplementation : ICustomer
{
    public int Create(Customer item)
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Start Create: Id={item.Id}");

        var q1 = Customers.FirstOrDefault(c => c.Id == item.Id);
        if (q1 != null)
        {
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed Create - already exists: Id={item.Id}");
            throw new AlreadyExistException("there is already a customer with id " + item.Id);
        }

        Customers.Add(item);
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End Create: Id={item.Id}");
        return item.Id;
    }
    public Customer Read(Func<Customer, bool> filter)
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Start Read");
        var customer = Customers.FirstOrDefault(filter);

        if (customer is null)
        {
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Failed Read - not found");
            throw new NotExistException("There is no customer with this trait");
        }

        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End Read: Id={customer.Id}");
        return customer;
    }
    public List<Customer> ReadAll()
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Start ReadAll");
        var q = Customers.ToList();
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End ReadAll: Count={q.Count}");
        return q;
    }
    public void Update(Customer item)
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Start Update: Id={item.Id}");
        Delete(item.Id);
        Customers.Add(item);
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End Update: Id={item.Id}");
    }
    public void Delete(int id)
    {
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Start Delete: Id={id}");
        var q1 = Customers.FirstOrDefault(s => s.Id == id);
        Console.WriteLine(q1);
        if (q1 == null)
        {
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Failed Delete - not found: Id={id}");
            throw new NotExistException("there is no customer with id " + id);
        }

        var q2 = Customers.Where(c => c.Id != id).ToList();
        Customers = q2;
        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"End Delete: Id={id}");
    }
}
