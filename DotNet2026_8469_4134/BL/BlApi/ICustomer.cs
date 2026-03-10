
namespace BlApi;

public interface ICustomer:ICrud<BO.Customer>
{
    bool IsExistCustomer(BO.Customer customer);

}

