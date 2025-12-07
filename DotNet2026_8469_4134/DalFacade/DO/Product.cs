using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Product(
        int Id, 
        string Name, 
        Category Category, 
        double Price, 
        int QuantityInStack)
    {
        public Product() : this(-1, "", Category.CHOCOLATE, 0, 0)
        {

        }

    }
}
