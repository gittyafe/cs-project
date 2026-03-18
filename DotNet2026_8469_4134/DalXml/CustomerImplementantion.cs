
using DO;
using System.Xml.Linq;

namespace Dal
{
    internal class CustomerImplementantion
    {
        private readonly string fileCustomers = "customers";
        public int Create(Customer item)
        {
            XElement customersXml = XElement.Load(fileCustomers);
            customersXml.Element("ArrayOfCustomer").Add


            return
        }
        public Sale Read(Func<Customer, bool> filter)
        {
            return
        }
        public List<Sale> ReadAll(Func<Customer, bool> filter)
        {
            return
        }
        public void Update(Customer item)
        {
        }
        public void Delete(int id)
        {
        }
    }
}
