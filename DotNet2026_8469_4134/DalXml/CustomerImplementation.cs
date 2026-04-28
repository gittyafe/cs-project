
using DalApi;
using DO;
using System.Security.Claims;
using System.Xml.Linq;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    private readonly string fileCustomers = @"..\xml\customers.xml";
    public int Create(Customer item)
    {
        XElement customersXml = XElement.Load(fileCustomers);
        customersXml.Element("ArrayOfCustomer").Add(new XElement("Customer", "ggg"));
            //        new XElement("Id", item.Id),
            //        new XElement("Name", item.Name),
            //        new XElement("Address", item.Address),
            //        new XElement("Phone", item.Phone)       
            //));

        customersXml.Save(fileCustomers);
        return item.Id;
    }
    public Customer? Read(Func<Customer, bool> filter)
    {
        XElement customersXml = XElement.Load(fileCustomers);
        var q = from c in customersXml.Descendants("Customer")
                let cust = new Customer()
                {
                    Id = int.Parse(c.Element("Id").Value),
                    Name = c.Element("Name").Value,
                    Address = c.Element("Address").Value,
                    Phone = c.Element("Phone").Value
                }
                where filter(cust)
                select cust;

        return q.FirstOrDefault();
    }
    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        XElement customersXml = XElement.Load(fileCustomers);
        var q = from c in customersXml.Descendants("Customer")
                let cust = new Customer()
                {
                    Id = int.Parse(c.Element("Id").Value),
                    Name = c.Element("Name").Value,
                    Address = c.Element("Address").Value,
                    Phone = c.Element("Phone").Value
                }
                where filter(cust)
                select cust;

        return q.ToList();
    }
    public void Update(Customer item)
    {
        Delete(item.Id);
        Create(item);
    }
    public void Delete(int id)
    {
        XElement customersXml = XElement.Load(fileCustomers);
        customersXml.Descendants("Id").FirstOrDefault(cid => int.Parse(cid.Value) == id)
              .Parent.Remove();

        customersXml.Save(fileCustomers);
    }
}
