
using BlApi;
using BO;
using DalApi;
using System.Reflection.Metadata;

namespace BlImplementation
{
    internal class OrderImplementation : IOrder
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int id, int quantity)
        {
            return null;
        }
        
        public void CalcTotalPrice(BO.Order order)
        {

        }
        public void DoOrder(BO.Order order)
        {

        }
        public void CalcTotalPriceForProduct(BO.ProductInOrder product)
        {
            double total = 0;
            List<SaleInProduct> usedSales = new List<SaleInProduct>();
            int count = product.AmountInOrder;
            foreach (var sale in product.ListSaleInProduct)
            {
                if (count < sale.AmountForSale)
                    continue;
                int times = (int)Math.Floor(count / (double)sale.AmountForSale);
                total += (times * sale.Price);
                count -= times * sale.AmountForSale;
                usedSales.Add(sale);
                if (count == 0)
                    break;

            }
            total += (count * product.BasePrice);
            product.TotalPrice = total;
            product.ListSaleInProduct = usedSales.ToList();
        }
        public void SearchSaleForProduct(BO.ProductInOrder product, bool isFavorite)
        {
            try
            {
                var sales = _dal.Sale.ReadAll(s => s.ProductId == product.ProductId)
                .Where(s => s.StartSale <= DateTime.Now && s.EndSale >= DateTime.Now && product.AmountInOrder >= s.QuantityRequired);
                if (!isFavorite)
                {
                    sales = sales.Where(s => s?.IsOnlyClub == false);
                }
                sales.OrderBy(s => s.TotalPrice / s.QuantityRequired);
                var result = sales.Select(s => new BO.SaleInProduct
                {
                    SaleId = s.Id,
                    AmountForSale = s.QuantityRequired,
                    Price = s.TotalPrice,
                    IsOnlyClub = s.IsOnlyClub
                });

                product.ListSaleInProduct = result.ToList();
            }
            catch (DO.DalException ex)
            {
                throw new BO.BlException("Error reading products", ex);
            }
        }
    }
}
