
using DalApi;
using DO;
using System.Xml.Linq;

namespace Dal;

internal class CustomerImplementation:ICustomer
{
    private readonly string fileCustomers = "customers";
    public int Create(Customer item)
    {
        XElement customersXml = XElement.Load(fileCustomers);
        customersXml.Element("ArrayOfCustomer").Add();
        customersXml.Save(fileCustomers);
        return item.Id;
    }
    public Customer? Read(Func<Customer, bool> filter)
    {
        throw new NotImplementedException();
    }
    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        throw new NotImplementedException();        
    }
    public void Update(Customer item)
    {
        
    }
    public void Delete(int id)
    {
    }
}
