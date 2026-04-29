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
        Initialization.initialize();
        int CustomerId = getCustomerId();
        bool isClub = true; //to change it to be true only if he is registered!!!!!!!!!!!!!!!!!!!
        Order currentOrder = new BO.Order()
        {
            IsClub = isClub,
            ProductsInOrder = new List<BO.ProductInOrder>(),
            FinalPrice = 0
        };
        while (true)
        {
            Console.WriteLine("to add a product - 1, to do the order");
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
    }
    private static int getCustomerId()
    {
        Console.WriteLine("insert the customer id");
        int id = int.Parse(Console.ReadLine());
        return id;
    }

    //    private static void main_menu()
    //    {
    //        try
    //        {
    //            Initialization.initialize();
    //        }
    //        catch (BlNotExistException e)
    //        {
    //            Console.WriteLine(e.Message);
    //            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Initialization failed: {e.Message}");
    //        }
    //        catch (BlAlreadyExistException e)
    //        {
    //            Console.WriteLine(e.Message);
    //            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Initialization failed: {e.Message}");
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Initialization failed: {e.Message}");
    //        }
    //        int num1 = 0;
    //        try
    //        {
    //            do
    //            {
    //                Console.WriteLine("insert 1 to customers, 2 to products, 3 to sales, 4 to orders, 5 to clean logs, 6 to exit");
    //                num1 = int.Parse(Console.ReadLine());
    //                switch (num1)
    //                {
    //                    case 1: customersUser(s_bl.Customer); break;
    //                    case 2: productsUser(s_bl.Product); break;
    //                    case 3: salesUser(s_bl.Sale); break;
    //                    case 4: orderUser(s_bl.Order); break;
    //                    case 5:
    //                        Console.WriteLine("Cleaning old logs...");
    //                        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start cleanOldLog");
    //                        LogManager.cleanOldLog();
    //                        Console.WriteLine("Log cleaning finished.");
    //                        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Finished cleanOldLog");
    //                        break;
    //                    case 6: break;
    //                    default: Console.WriteLine("illegal num"); break;
    //                }
    //            } while (num1 != 6);
    //        }
    //        catch (BlNotExistException e)
    //        {
    //            Console.WriteLine(e.Message);
    //            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Menu loop error: {e.Message}");
    //        }
    //        catch (BlAlreadyExistException e)
    //        {
    //            Console.WriteLine(e.Message);
    //            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Menu loop error: {e.Message}");
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Menu loop error: {e.Message}");
    //        }
    //    }



    //    private static void orderUser(IOrder o)
    //    {
    //        Console.WriteLine("1 – create new order");
    //        Console.WriteLine("2 – add product to order");
    //        Console.WriteLine("3 – calculate total price");
    //        Console.WriteLine("4 – do order");

    //        int choice = int.Parse(Console.ReadLine());
    //        switch (choice)
    //        {
    //            case 1:
    //                currentOrder = new BO.Order()
    //                {
    //                    IsPreferredCustomer = getPreferred(),
    //                    ProductsInOrder = new List<BO.ProductInOrder>(),
    //                    FinalPrice = 0
    //                };
    //                Console.WriteLine("Order created.");
    //                break;

    //            case 2:
    //                //int prodId = getId();
    //                //int amount = getAmount();
    //                //var sales = o.AddProductToOrder(currentOrder, prodId, amount);
    //                //Console.WriteLine("Sales applied:");
    //                //foreach (var s in sales) Console.WriteLine(s);
    //                break;

    //            case 3:
    //                //o.CalcTotalPrice(currentOrder);
    //                //Console.WriteLine($"Total price: {currentOrder.FinalPrice}");
    //                break;

    //            case 4:
    //                //o.DoOrder(currentOrder);
    //                //Console.WriteLine("Order completed.");
    //                break;

    //            default:
    //                Console.WriteLine("invalid choise");
    //                break;
    //        }
    //    }

    //    private static void salesUser(ISale s)
    //    {
    //        int menuNum = menuCrud();

    //        switch (menuNum)
    //        {
    //            case 1:
    //                s.Create(getUserSale());
    //                break;

    //            case 2:
    //                List<Sale> sales = s.ReadAll(x => true);
    //                foreach (var i in sales)
    //                    Console.WriteLine(i);
    //                break;

    //            case 3:
    //                int id = getId();
    //                Console.WriteLine(s.Read(x => x.Id == id));
    //                break;

    //            case 4:
    //                id = getId();
    //                s.Update(getUserSale(id));
    //                break;

    //            case 5:
    //                s.Delete(getId());
    //                break;

    //            default:
    //                Console.WriteLine("illegal number");
    //                break;
    //        }
    //    }
    //    private static void productsUser(IProduct p)
    //    {
    //        int menuNum = menuCrud();

    //        switch (menuNum)
    //        {
    //            case 1:
    //                p.Create(getUserProduct());
    //                break;

    //            case 2:
    //                List<Product> prods = p.ReadAll(x => true);
    //                foreach (var i in prods)
    //                    Console.WriteLine(i);
    //                break;

    //            case 3:
    //                int id = getId();
    //                Console.WriteLine(p.Read(x => x.Id == id));
    //                break;

    //            case 4:
    //                id = getId();
    //                p.Update(getUserProduct(id));
    //                break;

    //            case 5:
    //                p.Delete(getId());
    //                break;

    //            default:
    //                Console.WriteLine("illegal number");
    //                break;

    //        }
    //    }
    //    private static void customersUser(ICustomer c)
    //    {
    //        int menuNum = menuCrud();

    //        switch (menuNum)
    //        {
    //            case 1:
    //                c.Create(getUserCustomer());
    //                break;

    //            case 2:
    //                List<Customer> prods = c.ReadAll(x => true);
    //                foreach (var i in prods)
    //                    Console.WriteLine(i);
    //                break;

    //            case 3:
    //                int id = getId();
    //                Console.WriteLine(c.Read(x => x.Id == id));
    //                break;

    //            case 4:
    //                id = getId();
    //                c.Update(getUserCustomer(id));
    //                break;

    //            case 5:
    //                c.Delete(getId());
    //                break;

    //            default:
    //                Console.WriteLine("illegal number");
    //                break;
    //        }
    //    }
    //    private static int menuCrud()
    //    {
    //        Console.WriteLine("insert 1 to create, 2 to read all, 3 to read, 4 to update, 5 to delete");
    //        int num = int.Parse(Console.ReadLine());
    //        return num;
    //    }
    private static int getId()
    {
        Console.WriteLine("insert id");
        int id = int.Parse(Console.ReadLine());
        return id;
    }


    //    private static Product getUserProduct(int id = 0)
    //    {
    //        Console.WriteLine("insert name, category - 1 for Chocklate and so on..., price, quantity");
    //        string name = Console.ReadLine();
    //        int category = int.Parse(Console.ReadLine());
    //        double price = double.Parse(Console.ReadLine());
    //        int quantityInStack = int.Parse(Console.ReadLine());
    //        Product newProduct = new Product() { Id = id, Name = name, Price = price, Category = (Category)category, QuantityInStack = quantityInStack };
    //        return newProduct;
    //    }
    //    private static Customer getUserCustomer(int id = 0)
    //    {
    //        Console.WriteLine("insert id, name, address,phone");
    //        id = int.Parse(Console.ReadLine());
    //        string name = Console.ReadLine();
    //        string address = Console.ReadLine();
    //        string phone = Console.ReadLine();

    //        Customer newCustomer = new Customer() { Id = id, Name = name, Address = address, Phone = phone };
    //        return newCustomer;
    //    }
    //    private static Sale getUserSale(int id = 0)
    //    {
    //        Console.WriteLine("insert productId, quantityRequired , totalPrice, isOnlyClub,startSale,endSale . date - format 12/12/1090");
    //        int productId = int.Parse(Console.ReadLine());
    //        int quantityRequired = int.Parse(Console.ReadLine());
    //        double totalPrice = double.Parse(Console.ReadLine());
    //        bool isOnlyClub = bool.Parse(Console.ReadLine());
    //        DateTime startSale = DateTime.Parse(Console.ReadLine());
    //        DateTime endSale = DateTime.Parse(Console.ReadLine());

    //        Sale newSale = new Sale() { Id = id, ProductId = productId, QuantityRequired = quantityRequired, TotalPrice = totalPrice, IsOnlyClub = isOnlyClub, StartSale = startSale, EndSale = endSale };
    //        return newSale;
    //}
}
