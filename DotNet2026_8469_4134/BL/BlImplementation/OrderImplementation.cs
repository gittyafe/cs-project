using BlApi;
using BO;
using static BO.Tools;
using DalApi;
using DO;
using System.Linq;

namespace BlImplementation
{
    internal class OrderImplementation : IOrder
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int id, int quantity)
        {
            BO.ProductInOrder p;

            var existing = order.ProductsInOrder
                .FirstOrDefault(x => x.ProductId == id);

            DO.Product doProduct = _dal.Product.Read(x => x.Id == id);

            if (doProduct.QuantityInStack < quantity)
                    throw new BO.BlNotEnoughInStackException(
                    $"There are only {doProduct.QuantityInStack} items from product {id}.");

            if (existing != null)
            {
                if (doProduct.QuantityInStack < existing.AmountInOrder + quantity)
                    throw new BO.BlNotEnoughInStackException(
                        $"There are only {doProduct.QuantityInStack} items from product {id}.");

                existing.AmountInOrder += quantity;

                p = existing;
            }
            else
            {
                p = new ProductInOrder(
                    doProduct.Id,
                    doProduct.Name,
                    doProduct.Price,
                    quantity,
                    new List<SaleInProduct>()
                );
            }

            SearchSaleForProduct(p, order.IsClub);
            CalcTotalPriceForProduct(p);

            if (existing == null)
                order.ProductsInOrder.Add(p);

            CalcTotalPrice(order);

            return p.ListSaleInProduct;
        }

        public void CalcTotalPrice(BO.Order order)
        {
            order.FinalPrice = 0;

            foreach (var p in order.ProductsInOrder)
            {
                order.FinalPrice += p.TotalPrice;
            }
        }

        public void DoOrder(BO.Order order)
        {
            foreach (var p in order.ProductsInOrder)
            {
                DO.Product doproduct = _dal.Product.Read(x => x.Id == p.ProductId);

                if (doproduct.QuantityInStack < p.AmountInOrder)
                    throw new BO.BlNotEnoughInStackException(
                        $"Not enough stock for product {p.ProductId}");

                _dal.Product.Update(
                    doproduct with
                    {
                        QuantityInStack = doproduct.QuantityInStack - p.AmountInOrder
                    }
                );
            }
        }

        public void CalcTotalPriceForProduct(BO.ProductInOrder product)
        {
            double total = 0;
            List<SaleInProduct> usedSales = new List<SaleInProduct>();
            int count = product.AmountInOrder;

            foreach (var sale in product.ListSaleInProduct
                .OrderBy(s => s.Price / s.AmountForSale))
            {
                if (count < sale.AmountForSale)
                    continue;

                int times = count / sale.AmountForSale;

                total += times * sale.Price;
                count -= times * sale.AmountForSale;

                usedSales.Add(sale);

                if (count == 0)
                    break;
            }

            total += count * product.BasePrice;

            product.TotalPrice = total;
            product.ListSaleInProduct = usedSales;
        }

        public void SearchSaleForProduct(BO.ProductInOrder product, bool isFavorite)
        {
            try
            {
                var sales = _dal.Sale.ReadAll(s => s.ProductId == product.ProductId)
                    .Where(s =>
                        s.StartSale <= DateTime.Now &&
                        s.EndSale >= DateTime.Now &&
                        product.AmountInOrder >= s.QuantityRequired);

                if (!isFavorite)
                {
                    sales = sales.Where(s => s.IsOnlyClub == false);
                }

                sales = sales.OrderBy(s => s.TotalPrice / s.QuantityRequired);

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
                throw new BO.BlException("Error reading sales", ex);
            }
        }
    }
}