
using DalApi;
using DO;
using System.Collections.Generic;
using System.Security.Claims;
using System.Xml.Linq;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    private readonly string fileCustomers = @"..\xml\customers.xml";
    public int Create(Customer item)
    {
        var list = ReadAll(x=>true);
        if (list.FirstOrDefault(x => x?.Id == item.Id) != null)
        {
            throw new DalAlreadyExistException("there is already a customer with id " + item.Id);
        }
        XElement customersXml = XElement.Load(fileCustomers);
        customersXml.Add(new XElement("Customer",
            new XElement("Id", item.Id),    
            new XElement("Name", item.Name),
            new XElement("Address", item.Address),
            new XElement("Phone", item.Phone),
            new XElement("IsClub", item.IsClub)
        ));

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
                    Phone = c.Element("Phone").Value,
                    IsClub = bool.Parse(c.Element("IsClub")?.Value ?? "false")
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
    Phone = c.Element("Phone").Value,
    IsClub = bool.Parse(c.Element("IsClub")?.Value ?? "false")
                }
                where filter == null || filter(cust)
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

        var list = ReadAll(x=>true);
        if (list.FirstOrDefault(x => x.Id == id) == null)
        {
            throw new DalNotExistException("there no customer with id " + id);
        }

        customersXml.Descendants("Id").FirstOrDefault(cid => int.Parse(cid.Value) == id)
              .Parent.Remove();

        customersXml.Save(fileCustomers);
    }
}
