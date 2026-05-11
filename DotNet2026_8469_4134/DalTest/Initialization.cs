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
        listP.Add(pi.Create(new Product(1000, "Rich", Category.CREAM, 5.5, 10)));
        listP.Add(pi.Create(new Product(2, "Blueberry", Category.CREAM, 12, 20)));
        listP.Add(pi.Create(new Product(3, "Crystal Sugar", Category.DECORATION, 6, 30)));
        listP.Add(pi.Create(new Product(4, "pearl candys", Category.DECORATION, 6, 18)));
        listP.Add(pi.Create(new Product(5, "Crocnet", Category.NUTS, 8, 15)));
        listP.Add(pi.Create(new Product(6, "Pecans", Category.NUTS, 9, 10)));
        pi.Create(new Product(7, "Jelly", Category.POWDER, 3.5, 30));
        pi.Create(new Product(8, "Baking Powder", Category.POWDER, 2.5, 50));
        pi.Create(new Product(9, "White chocolate", Category.CHOCOLATE, 8, 50));
        pi.Create(new Product(10, "Chocolate chips", Category.CHOCOLATE, 9, 50));

    }
    private static void createCustomers(ICustomer ci)
    {
        ci.Create(new Customer(1, "Rivki", "Meromei Sade", "123456789", true));
        ci.Create(new Customer(2, "Gitty", "Ktsot ", "1357925", false));
        ci.Create(new Customer(3, "Yehudit", "Shaagat arie", "431221111", false));
        ci.Create(new Customer(4, "Tovi", "Mesilat yosef", "464575678", true));
        ci.Create(new Customer(16, "Shulamit", "Netivot hamishpat", "78787878", false));
        ci.Create(new Customer(5, "Dvory", "Rabi Akiva", "57453243", false));
        ci.Create(new Customer(6, "Tamar", "Petah Tikva", "235437548", false));
        ci.Create(new Customer(7, "Bina", "Mesilat yosef", "45636457", false));
        ci.Create(new Customer(8, "Shosh", "Rashbi", "7456634", false));
        ci.Create(new Customer(9, "Tsipora", "Meromei Sade", "6547568", false));
        ci.Create(new Customer(10, "Yael", "Chazon david", "42556578", false));
        ci.Create(new Customer(11, "Shimon", "Yatkovski 7", "6435342", false));
        ci.Create(new Customer(12, "David", "Mesilat", "3534645", false));
        ci.Create(new Customer(13, "Kobi", "Meromei Sade", "657658", false));
        ci.Create(new Customer(14, "Reuven", "Rashbi", "74543", false));
        ci.Create(new Customer(15, "Shosh", "Avney nezer", "534465768", false));
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
