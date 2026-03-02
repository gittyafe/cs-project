using DalApi;
using System.ComponentModel;

namespace Dal;
internal sealed class DalList : IDal
{
    private readonly static DalList instance = new DalList();
    public static DalList Instance => instance;
    public ISale Sale => new SaleImplementation();
    public IProduct Product => new ProductImplementation();
    public ICustomer Customer => new CustomerImplementation();

    private DalList() { }


}

