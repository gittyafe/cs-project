using BO;

namespace BlApi;

public interface ICustomer:ICrud<Customer>
{
    bool IsExistCustomer(Customer customer);

}

