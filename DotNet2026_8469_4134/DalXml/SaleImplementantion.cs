using DalApi;
using DalXml;
using Do;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tools;

namespace Dal
{
    internal class SaleImplementantion:ISale
    {
        private readonly string fileSales = "sales";
        public int Create(Sale item)
        {
            XElement salesXml = XElement.Load(fileSales);
            salesXml.Element("ArrayOfSale").Add


            return
        }
        public Sale Read(Func<Sale, bool> filter)
        {
           return
        }
        public List<Sale> ReadAll(Func<Sale, bool> filter)
        {
            return
        }
        public void Update(Sale item)
        {
           return
        }
        public void Delete(int id)
        {
          return
        }
    }
}
