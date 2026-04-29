using BlApi;
using BO;
using DalTest;
using DO;
using System.Reflection;
using Tools;

namespace BlTest;
class Program
{
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get;

    static void Main(string[] args)
    {
        try
        {
            Initialization.initialize();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        int CustomerId = getCustomerId();
        bool isClub = true;
        try
        {
            s_bl.Customer.Read(x => x.Id == CustomerId);
        }
        catch (BlNotExistException ex)
        {
            isClub = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            isClub = false;
        }
        Order currentOrder = new BO.Order()
        {
            IsClub = isClub,
            ProductsInOrder = new List<BO.ProductInOrder>(),
            FinalPrice = 0
        };
        while (true)
        {
            try
            {
                Console.WriteLine("to add a product - 1, to do the order - 2");
                int c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.WriteLine("insert product id ");
                        int pid = int.Parse(Console.ReadLine());
                        Console.WriteLine("insert amount ");
                        int amount = int.Parse(Console.ReadLine());
                        s_bl.Order.AddProductToOrder(currentOrder, pid, amount);
                        break;
                    case 2:
                        s_bl.Order.DoOrder(currentOrder);
                        Console.WriteLine($"total price: {currentOrder.FinalPrice} ");
                        Console.WriteLine("list of products in your order: ");
                        for (int i = 0; i < currentOrder.ProductsInOrder.Count; i++)
                            Console.WriteLine(currentOrder.ProductsInOrder[i]);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
    private static int getCustomerId()
    {
        Console.WriteLine("insert the customer id");
        int id = int.Parse(Console.ReadLine());
        return id;
    }

}
