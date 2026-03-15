
using System.Linq;

namespace BlImplementation;

internal class SaleImplementation : BlApi.ISale
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public int Create(BO.Sale sale)
    {
        try
        {
            DO.Sale doSale = BO.Tools.ToDO(sale);
            return _dal.Sale.Create(doSale);
        }
        catch (DO.DalAlreadyExistException ex)
        {
            throw new BO.BlAlreadyExistsException("Sale already exists", ex);
        }
    }
    
    public List<BO.Sale> ReadAll(Func<BO.Sale, bool> filter)
    {
        try
        {
            var sales = _dal.Sale.ReadAll(x=>true);
            var boSales = from sale in sales
                          let bs = BO.Tools.ToBO(sale)
                          where filter(bs)
                          select bs;
            return boSales.ToList();

        }
        catch (DO.DalException ex)
        {
            throw new BO.BlException("Error reading sales", ex);
        }
    }
    public BO.Sale Read(Func<BO.Sale, bool> filter)
    {
        try
        {
            var sale = _dal.Sale.ReadAll(x => true).Select(s=> BO.Tools.ToBO(s)).FirstOrDefault(filter);
            return sale;
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BlNotExistException("Error reading sales", ex);
        }
    }
    public void Update(BO.Sale item)
    {
        try
        {
            var sale = BO.Tools.ToDO(item);
            _dal.Sale.Update(sale);
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BlNotExistException("Error updating sales", ex);
        }
    }
    public void Delete(int id)
    {
        try
        { 
            _dal.Sale.Delete(id);
        }
        catch (DO.DalNotExistException ex)
        {
            throw new BO.BlNotExistException("Error deleting sales", ex);
        }
    }
}
