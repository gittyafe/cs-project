

namespace BlApi;

public interface IBl
{
    IOrder Order { get; }
    IProduct Product { get; }
    ICustomer Customer { get; }
    ISale Sale { get; }

}
