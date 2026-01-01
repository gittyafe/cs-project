using Dal;
using DalApi;
using DO;
using System;

namespace DalTest;

public static class Initialization
{
    private static IDal? s_dal;

    private static void creatProducts(IProduct pi)
    {
        pi.Create(new Product(1, "Rich", Category.CREAM, 5.5, 10));
        pi.Create(new Product(2, "Blueberry", Category.CREAM, 12, 20));
        pi.Create(new Product(3, "Crystal Sugar", Category.DECORATION, 6, 30));
        pi.Create(new Product(4, "pearl candys", Category.DECORATION, 6, 18));
        pi.Create(new Product(5, "Crocnet", Category.NUTS, 8, 15));
        pi.Create(new Product(6, "Pecans", Category.NUTS, 9, 10));
        pi.Create(new Product(7, "Jelly", Category.POWDER, 3.5, 30));
        pi.Create(new Product(8, "Baking Powder", Category.POWDER, 2.5, 50));
        pi.Create(new Product(9, "White chocolate", Category.CHOCOLATE, 8, 50));
        pi.Create(new Product(10, "Chocolate chips", Category.CHOCOLATE, 9, 50));

    }
    private static void createCustomers(ICustomer ci)
    {
        ci.Create(new Customer(1, "Rivki", "Meromei Sade", "123456789"));
        ci.Create(new Customer(2, "Gitty", "Ktsot ", "1357925"));
        ci.Create(new Customer(3, "Yehudit", "Shaagat arie", "431221111"));
        ci.Create(new Customer(4, "Tovi", "Mesilat yosef", "464575678"));
        ci.Create(new Customer(4, "Shulamit", "Netivot hamishpat", "78787878"));
        ci.Create(new Customer(5, "Dvory", "Rabi akiva", "57453243"));
        ci.Create(new Customer(6, "Tamar", "Petah Tikva", "235437548"));
        ci.Create(new Customer(7, "Bina", "Mesilat yosef", "45636457"));
        ci.Create(new Customer(8, "Shosh", "Rashbi", "7456634"));
        ci.Create(new Customer(9, "Tsipora", "Meromei Sade", "6547568"));
        ci.Create(new Customer(10, "Yael", "Chazon david", "42556578"));
        ci.Create(new Customer(11, "Shimon", "Yatkovski 7", "6435342"));
        ci.Create(new Customer(12, "David", "Mesilat", "3534645"));
        ci.Create(new Customer(13, "Kobi", "Meromei Sade", "657658"));
        ci.Create(new Customer(14, "Reuven", "Rashbi", "74543"));
        ci.Create(new Customer(15, "Shosh", "Avney nezer", "534465768"));
    }
    private static void createSales(ISale si)
    {
        si.Create(new Sale(1, 1, 12, 43.8, true, new DateTime(2025, 12, 31), new DateTime(2026, 12, 31)));
        si.Create(new Sale(2, 2, 12, 44, false, new DateTime(2026, 1, 1), new DateTime(2026, 1, 31)));
        si.Create(new Sale(3, 3, 2, 2, true, new DateTime(2015, 12, 31), new DateTime(2016, 12, 31)));
        si.Create(new Sale(4, 4, 1, 98.8, true, new DateTime(2015, 12, 31), new DateTime(2016, 12, 31)));
        si.Create(new Sale(5, 5, 3, 123, true, new DateTime(2015, 12, 31), new DateTime(2026, 12, 31)));
    }
    public static void initialize(IDal dal)
    {
        s_dal = dal;
        createSales(s_dal.Sale);
        createCustomers(s_dal.Customer);
        creatProducts(s_dal.Product);
    }
}
