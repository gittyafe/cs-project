using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

internal class ProductImplementation:IProduct
{
    public int Create(DO.Product product)
    {
        throw new NotImplementedException();
    }

    public Product? Read(Func<Product, bool> filter)
    {
        throw new NotImplementedException();
    }

    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(DO.Product product)
    {
        throw new NotImplementedException();
    }

    void ICrud<Product>.Delete(int id)
    {
        throw new NotImplementedException();
    }
}
