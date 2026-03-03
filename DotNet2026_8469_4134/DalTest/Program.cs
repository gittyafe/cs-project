//using Dal;
using DalApi;
using DalTest;
using Do;
using DO;
using System;
using System.Reflection;
using Tools;

public class Program
{
    private static IDal s_dal = DalApi.Factory.Get;

    public static void Main(string[]args)
    {
        main_menu();
        LogManager.cleanOldLog();
    }
    private static void main_menu()
    {
        try
        {
            Initialization.initialize();
        }
        catch (DalNotExistException e)
        {
            Console.WriteLine(e.Message);
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Initialization failed: {e.Message}");
        }
        catch (DalAlreadyExistException e)
        {
            Console.WriteLine(e.Message);
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Initialization failed: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Initialization failed: {e.Message}");
        }
        int num1 = 0;
        try
        {
            do
            {
                Console.WriteLine("insert 1 to customers, 2 to products, 3 to sales, 4 to clean logs, 5 to exit");
                num1 = int.Parse(Console.ReadLine());
                switch (num1)
                {
                    case 1: customersUser(s_dal.Customer); break;
                    case 2: productsUser(s_dal.Product); break;
                    case 3: salesUser(s_dal.Sale); break;
                    case 4:
                        Console.WriteLine("Cleaning old logs...");
                        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start cleanOldLog");
                        LogManager.cleanOldLog();
                        Console.WriteLine("Log cleaning finished.");
                        LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Finished cleanOldLog");
                        break;
                    case 5: break;
                    default: Console.WriteLine("illegal num"); break;
                }
            } while (num1 != 5);
        }
        catch (DalNotExistException e)
        {
            Console.WriteLine(e.Message);
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Menu loop error: {e.Message}");
        }
        catch (DalAlreadyExistException e)
        {
            Console.WriteLine(e.Message);
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Menu loop error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            LogManager.writeLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Menu loop error: {e.Message}");
        }
    }

    private static void salesUser(ICrud<Sale> s)
    {
        int menuNum = menuCrud();

        switch (menuNum)
        {
            case 1:
                s.Create(getUserSale());
                break;

            case 2:
                List<Sale> sales = s.ReadAll();
                foreach(var i in sales)
                    Console.WriteLine(i);
                break;

            case 3:
                int id = getId();
                Console.WriteLine(s.Read(x=>x.Id == id));
                break;

            case 4:
                id = getId();
                s.Update(getUserSale(id));
                break;

            case 5:
                s.Delete(getId());
                break;

            default:
                Console.WriteLine("illegal number");
                break;
        }
    }
    private static void productsUser(ICrud<Product> p)
    {
        int menuNum = menuCrud();

        switch (menuNum)
        {
            case 1:
                p.Create(getUserProduct());
                break;

            case 2:
                List<Product> prods = p.ReadAll();
                foreach (var i in prods)
                    Console.WriteLine(i);
                break ;

            case 3:
                int id = getId();
                Console.WriteLine(p.Read(x => x.Id == id));
                break;

            case 4:
                id = getId();
                p.Update(getUserProduct(id));
                break;

            case 5:
                p.Delete(getId());
                break;

            default:
                Console.WriteLine("illegal number");
                break;

        }

    }
    private static void customersUser(ICrud<Customer> c)
    {
        int menuNum = menuCrud();

        switch (menuNum)
        {
            case 1:
                c.Create(getUserCustomer());
                break;

            case 2:
                List<Customer> prods = c.ReadAll();
                foreach (var i in prods)
                    Console.WriteLine(i);
                break;

            case 3:
                int id = getId();
                Console.WriteLine(c.Read(x => x.Id == id));
                break;

            case 4:
                id = getId();
                c.Update(getUserCustomer(id));
                break;

            case 5:
                c.Delete(getId());
                break;
        
                default:
                Console.WriteLine("illegal number");
                break;
        }
    }
    private static int menuCrud()
    {
        Console.WriteLine("insert 1 to create, 2 to read all, 3 to read, 4 to update, 5 to delete");
        int num = int.Parse(Console.ReadLine());
        return num;
    }
    private static int getId()
    {
        Console.WriteLine("insert id");
        int id = int.Parse(Console.ReadLine());
        return id;
    }

    private static Product getUserProduct(int id = 0)
    {
        Console.WriteLine("insert name, category - 1 for Chocklate and so on..., price, quantity");
        string name = Console.ReadLine();
        int category = int.Parse(Console.ReadLine());
        double price = double.Parse(Console.ReadLine());
        int quantityInStack = int.Parse(Console.ReadLine());
        Product newProduct = new Product() { Id = id, Name = name, Price = price, Category = (Category)category, QuantityInStack = quantityInStack };
        return newProduct;  
    }
    private static Customer getUserCustomer(int id = 0)
    {
        Console.WriteLine("insert id, name, address,phone");
        id = int.Parse(Console.ReadLine());
        string name = Console.ReadLine();
        string address = Console.ReadLine();
        string phone = Console.ReadLine();

        Customer newCustomer = new Customer() { Id = id, Name = name, Address = address, Phone = phone };
        return newCustomer; 
    }
    private static Sale getUserSale(int id=0)
    {
        Console.WriteLine("insert productId, quantityRequired , totalPrice, isOnlyClub,startSale,endSale . date - format 12/12/1090");
        int productId = int.Parse(Console.ReadLine());
        int quantityRequired = int.Parse(Console.ReadLine());
        double totalPrice = double.Parse(Console.ReadLine());
        bool isOnlyClub = bool.Parse(Console.ReadLine());
        DateTime startSale = DateTime.Parse(Console.ReadLine());
        DateTime endSale = DateTime.Parse(Console.ReadLine());

        Sale newSale = new Sale() { Id=id,ProductId = productId, QuantityRequired = quantityRequired, TotalPrice = totalPrice, IsOnlyClub = isOnlyClub, StartSale = startSale, EndSale = endSale };
        return newSale;
    }

    }
