using DO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace BO;
internal static class Tools
{
    static string ToStringProperty<T>(T obj)
    {
        string result = "";
        Type type = obj.GetType();
        foreach (var prop in type.GetProperties())
        {
            Type propType = prop.PropertyType;
            var value = prop.GetValue(obj);
            if (value == null)
            {
                result += $"{prop.Name}: null, ";
            }
            else if (value is IEnumerable collection && value is not string)
            {
                result += $"{prop.Name}: [";
                foreach (var item in collection)
                    result += ToStringProperty(item);
                result += "], ";
            }
            else if (!propType.IsPrimitive && propType != typeof(string))
            {
                result += $"{prop.Name}: {ToStringProperty(value)}, ";
            }
            else
            {
                result += $"{prop.Name}: {value}, ";
            }
        }
       return result;
    }

    //convertion functions - from BO to DO and vice vresa:

    // המרה מ-DO ל-BO
    public static BO.Sale ToBO(this DO.Sale sale) =>
        new BO.Sale(
            sale.Id,
            sale.ProductId,
            sale.QuantityRequired,
            sale.TotalPrice,
            sale.IsOnlyClub,
            sale.StartSale,
            sale.EndSale
        );

    // המרה מ-BO ל-DO
    public static DO.Sale ToDO(this BO.Sale sale) =>
        new DO.Sale(
            sale.Id,
            sale.ProductId,
            sale.QuantityRequired,
            sale.TotalPrice,
            sale.IsOnlyClub,
            sale.StartSale,
            sale.EndSale
        );

    // המרה מ-DO ל-BO
    public static BO.Customer ToBO(this DO.Customer customer) =>
        new BO.Customer(
            customer.Id,
            customer.Name,
            customer.Address,
            customer.Phone
        );

    // המרה מ-BO ל-DO
    public static DO.Customer ToDO(this BO.Customer customer) =>
        new DO.Customer(
            customer.Id,
            customer.Name,
            customer.Address,
            customer.Phone
        );

    // המרה מ-DO ל-BO
    public static BO.Product ToBO(this DO.Product product) {
        List<BO.Sale> SaleInProduct = new List<BO.Sale>();
        return new BO.Product(
            product.Id,
            product.Name,
            product.Category,
            product.Price,
            product.QuantityInStack,
            SaleInProduct

        );
    }

    // המרה מ-BO ל-DO
    public static DO.Product ToDO(this BO.Product product) =>
        new DO.Product(
            product.Id,
            product.Name,
            product.Category,
            product.Price,
            product.QuantityInStack
        );
}
}




