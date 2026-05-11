//using Dal;
using DalApi;
using DO;
using System;

namespace DalTest;

public static class Initialization
{
    private static IDal? s_dal;
    private static List<int> listP = new List<int>();
    private static void creatProducts(IProduct pi)
    {
        listP.Add(pi.Create(new Product(1000, "ריץ'", Category.CREAM, 5.5, 10)));
        listP.Add(pi.Create(new Product(2, "אוכמניות", Category.CREAM, 12, 20)));
        listP.Add(pi.Create(new Product(3, "סוכר גבישי", Category.DECORATION, 6, 30)));
        listP.Add(pi.Create(new Product(4, "סוכריות פנינה", Category.DECORATION, 6, 18)));
        listP.Add(pi.Create(new Product(5, "קרוקנט", Category.NUTS, 8, 15)));
        listP.Add(pi.Create(new Product(6, "פקאן", Category.NUTS, 9, 10)));
        pi.Create(new Product(7, "ג'לי", Category.POWDER, 3.5, 30));
        pi.Create(new Product(8, "אבקת אפייה", Category.POWDER, 2.5, 50));
        pi.Create(new Product(9, "שוקולד לבן", Category.CHOCOLATE, 8, 50));
        pi.Create(new Product(10, "צ'יפס שוקולד", Category.CHOCOLATE, 9, 50));

    }
    private static void createCustomers(ICustomer ci)
    {

        ci.Create(new Customer(1, "רבקי", "מרומי שדה", "123456789", true));
        ci.Create(new Customer(2, "גיטי", "קצות", "1357925", false));
        ci.Create(new Customer(3, "יהודית", "שאגת אריה", "431221111", false));
        ci.Create(new Customer(4, "טובי", "מסילת יוסף", "464575678", true));
        ci.Create(new Customer(16, "שולמית", "נתיבות המשפט", "78787878", false));
        ci.Create(new Customer(5, "דבורי", "רבי עקיבא", "57453243", false));
        ci.Create(new Customer(6, "תמר", "פתח תקווה", "235437548", false));
        ci.Create(new Customer(7, "בינה", "מסילת יוסף", "45636457", false));
        ci.Create(new Customer(8, "שוש", "רשב\"י", "7456634", false));
        ci.Create(new Customer(9, "ציפורה", "מרומי שדה", "6547568", false));
        ci.Create(new Customer(10, "יעל", "חזון דוד", "42556578", false));
        ci.Create(new Customer(11, "שמעון", "יטקובסקי 7", "6435342", false));
        ci.Create(new Customer(12, "דוד", "מסילת", "3534645", false));
        ci.Create(new Customer(13, "קובי", "מרומי שדה", "657658", false));
        ci.Create(new Customer(14, "ראובן", "רשב\"י", "74543", false));
        ci.Create(new Customer(15, "שוש", "אבני נזר", "534465768", false));
    }
    private static void createSales(ISale si)
    {

        si.Create(new Sale(1, listP[0], 2, 10, true, new DateTime(2025, 12, 31), new DateTime(2026, 12, 31)));
        si.Create(new Sale(2, listP[0], 3, 16, false, new DateTime(2026, 1, 1), new DateTime(2026, 1, 31)));
        si.Create(new Sale(3, listP[1], 2, 22, true, new DateTime(2015, 12, 31), new DateTime(2016, 12, 31)));
        si.Create(new Sale(4, listP[3], 5, 26, true, new DateTime(2015, 12, 31), new DateTime(2016, 12, 31)));
        si.Create(new Sale(5, listP[4], 1, 7, true, new DateTime(2015, 12, 31), new DateTime(2026, 12, 31)));
    }
    public static void initialize()
    {
        s_dal = DalApi.Factory.Get;
        creatProducts(s_dal.Product);
        createSales(s_dal.Sale);
        createCustomers(s_dal.Customer);
    }
}
