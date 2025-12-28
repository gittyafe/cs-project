

namespace DalApi
{
    internal interface IDal
    {
        ICustomer Customer { get; }
        IProduct Product { get; }
        ISale Sale { get; }
    
    }
}
