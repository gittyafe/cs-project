
using System.Linq;

namespace BlImplementation;

internal class CustomerImplementation : BlApi.ICustomer
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public int Create(BO.Customer customer)
    {
        try
        {
            DO.Customer doCustomer = BO.Tools.ToDO(customer);
            return _dal.Customer.Create(doCustomer);
        }
        catch (DO.DalAlreadyExistException ex)
        {
            throw new BO.BlAlreadyExistsException("Customer already exists", ex);
        }
    }
    
    public List<BO.Customer> ReadAll(Func<BO.Customer, bool> filter)
    {
        try
        {
            var customers = _dal.Customer.ReadAll(x=>true);
            var boCustomers = from customer in customers
                          let bs = BO.Tools.ToBO(customer)
                          where filter(bs)
                          select bs;
            return boCustomers.ToList();

        }
        catch (DO.DalException ex)
        {
            throw new BO.BlException("Error reading customers", ex);
        }
    }
    public BO.Customer Read(Func<BO.Customer, bool> filter)
    {
        try
        {
            var customer = _dal.Customer.ReadAll(x => true).Select(s=> BO.Tools.ToBO(s)).FirstOrDefault(filter);
            return customer;
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BlNotExistException("Error reading customers", ex);
        }
    }
    public void Update(BO.Customer item)
    {
        try
        {
            var customer = BO.Tools.ToDO(item);
            _dal.Customer.Update(customer);
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BlNotExistException("Error updating customers", ex);
        }
    }
    public void Delete(int id)
    {
        try
        { 
            _dal.Customer.Delete(id);
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BlNotExistException("Error deleting customers", ex);
        }
    }
}
