using Dal;
using DalApi;
using System.Diagnostics;

namespace Dal;

internal sealed class DalXml:IDal
{
    private readonly static DalXml instance = new DalXml();
    public static DalXml Instance => instance;

    public ISale Sale => new SaleImplementation();
    public IProduct Product => new ProductImplementation();
    public ICustomer Customer => new CustomerImplementation();

    private DalXml() { }

}
