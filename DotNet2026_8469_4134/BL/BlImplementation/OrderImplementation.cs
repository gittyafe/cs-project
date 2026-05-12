using BlApi;
using BO;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlImplementation
{
    internal class OrderImplementation : IOrder
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        // ================= ADD PRODUCT =================
        public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int id, int quantity)
        {
            var existing = order.ProductsInOrder
                .FirstOrDefault(x => x.ProductId == id);

            DO.Product doProduct = _dal.Product.Read(x => x.Id == id);

            if (doProduct.QuantityInStack < quantity)
                throw new BO.BlNotEnoughInStackException(
                    $"רק {doProduct.QuantityInStack} נשאר במלאי");

            BO.ProductInOrder p;

            if (existing != null)
            {
                if (doProduct.QuantityInStack < existing.AmountInOrder + quantity)
                    throw new BO.BlNotEnoughInStackException("אין מספיק מלאי");

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

                order.ProductsInOrder.Add(p);
            }

            // 🔥 חשוב: קודם מבצעים חיפוש מבצעים לפי מועדון
            SearchSaleForProduct(p, order.IsClub);

            // ואז מחשבים מחיר
            CalcTotalPriceForProduct(p);

            CalcTotalPrice(order);

            return p.ListSaleInProduct;
        }

        // ================= TOTAL ORDER =================
        public void CalcTotalPrice(BO.Order order)
        {
            order.FinalPrice = order.ProductsInOrder.Sum(p => p.TotalPrice);
        }

        // ================= FINALIZE ORDER =================
        public void DoOrder(BO.Order order)
        {
            foreach (var p in order.ProductsInOrder)
            {
                DO.Product product = _dal.Product.Read(x => x.Id == p.ProductId);

                if (product.QuantityInStack < p.AmountInOrder)
                    throw new BO.BlNotEnoughInStackException("Not enough stock");

                _dal.Product.Update(
                    product with
                    {
                        QuantityInStack = product.QuantityInStack - p.AmountInOrder
                    }
                );
            }
        }

        // ================= CALCULATE PRODUCT PRICE =================
        public void CalcTotalPriceForProduct(BO.ProductInOrder product)
        {
            double total = 0;
            int count = product.AmountInOrder;

            var usedSales = new List<SaleInProduct>();

            foreach (var sale in product.ListSaleInProduct
                .OrderBy(s => s.Price / (double)s.AmountForSale))
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

        // ================= FIND SALES =================
        public void SearchSaleForProduct(BO.ProductInOrder product, bool isClub)
        {
            var sales = _dal.Sale.ReadAll(s => s.ProductId == product.ProductId)
                .Where(s =>
                    s.StartSale <= DateTime.Now &&
                    s.EndSale >= DateTime.Now);

            // 🔥 רק אם לא מועדון - מסננים מבצעי מועדון
            if (!isClub)
            {
                sales = sales.Where(s => !s.IsOnlyClub);
            }

            product.ListSaleInProduct = sales
                .Select(s => new BO.SaleInProduct
                {
                    SaleId = s.Id,
                    AmountForSale = s.QuantityRequired,
                    Price = s.TotalPrice,
                    IsOnlyClub = s.IsOnlyClub
                })
                .ToList();
        }
    }
}