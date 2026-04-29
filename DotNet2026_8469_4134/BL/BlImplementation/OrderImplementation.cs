
using BlApi;
using BO;
using static BO.Tools;
using DalApi;
using DO;
using System.Reflection.Metadata;

namespace BlImplementation
{
    internal class OrderImplementation : IOrder
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int id, int quantity)
        {
            BO.ProductInOrder p=new ProductInOrder();
            bool flag = false;
            foreach (var pr in order.ProductsInOrder)
            {
                if(pr.ProductId == id)
                {
                    flag = true;
                    p = pr;
                    DO.Product doProduct = _dal.Product.Read(x => x.Id == id);
                    if (doProduct.QuantityInStack < quantity + p.AmountInOrder)
                        throw new BO.BlNotEnoughInStackException($"There are only {doProduct.QuantityInStack} items from product {id}.");
                    else
                        p.AmountInOrder = quantity;
                }
            }
            if (!flag)
            {
                DO.Product doProduct = _dal.Product.Read(x => x.Id == id);
                if (doProduct.QuantityInStack < quantity)
                    throw new BO.BlNotEnoughInStackException($"There are only {doProduct.QuantityInStack} items from product {id}.");
                else
                {
                    p = new ProductInOrder() { ProductId=id, ProductName= doProduct.Name, BasePrice = doProduct.Price, ListSaleInProduct=new List<SaleInProduct>(), AmountInOrder = quantity };
                    
                }
            }
            SearchSaleForProduct(p, order.IsClub);
            CalcTotalPriceForProduct(p);
            order.ProductsInOrder.Add(p);
            CalcTotalPrice(order);
            return p.ListSaleInProduct;
        }


        public void CalcTotalPrice(BO.Order order)
        {
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
                int amount = doproduct.QuantityInStack;
                DO.Product updatedProd = doproduct with { QuantityInStack = amount-p.AmountInOrder };
                _dal.Product.Update(updatedProd);
            }
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
