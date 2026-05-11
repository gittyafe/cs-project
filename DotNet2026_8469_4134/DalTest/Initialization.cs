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
        ci.Create(new Customer(1, "רבקי", "מרומי שדה", "123456789"));
        ci.Create(new Customer(2, "גיטי", "קצות", "1357925"));
        ci.Create(new Customer(3, "יהודית", "שאגת אריה", "431221111"));
        ci.Create(new Customer(4, "טובי", "מסילת יוסף", "464575678"));
        ci.Create(new Customer(16, "שולמית", "נתיבות המשפט", "78787878"));
        ci.Create(new Customer(5, "דבורי", "רבי עקיבא", "57453243"));
        ci.Create(new Customer(6, "תמר", "פתח תקווה", "235437548"));
        ci.Create(new Customer(7, "בינה", "מסילת יוסף", "45636457"));
        ci.Create(new Customer(8, "שוש", "רשב\"י", "7456634"));
        ci.Create(new Customer(9, "ציפורה", "מרומי שדה", "6547568"));
        ci.Create(new Customer(10, "יעל", "חזון דוד", "42556578"));
        ci.Create(new Customer(11, "שמעון", "יטקובסקי 7", "6435342"));
        ci.Create(new Customer(12, "דוד", "מסילת", "3534645"));
        ci.Create(new Customer(13, "קובי", "מרומי שדה", "657658"));
        ci.Create(new Customer(14, "ראובן", "רשב\"י", "74543"));
        ci.Create(new Customer(15, "שוש", "אבני נזר", "534465768"));
    }
    private static void createSales(ISale si)
    {

        si.Create(new Sale(1, listP[0], 12, 43.8, true, new DateTime(2025, 12, 31), new DateTime(2026, 12, 31)));
        si.Create(new Sale(2, listP[1], 12, 44, false, new DateTime(2026, 1, 1), new DateTime(2026, 1, 31)));
        si.Create(new Sale(3, listP[2], 2, 2, true, new DateTime(2015, 12, 31), new DateTime(2016, 12, 31)));
        si.Create(new Sale(4, listP[3], 1, 98.8, true, new DateTime(2015, 12, 31), new DateTime(2016, 12, 31)));
        si.Create(new Sale(5, listP[4], 3, 123, true, new DateTime(2015, 12, 31), new DateTime(2026, 12, 31)));
    }
    public static void initialize()
    {
        s_dal = DalApi.Factory.Get;
        creatProducts(s_dal.Product);
        createSales(s_dal.Sale);
        createCustomers(s_dal.Customer);
    }
}
