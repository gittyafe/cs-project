using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

internal class ProductImplementation:IProduct
{
    private readonly string fileSales = @"..\xml\products.xml";
    private readonly string fileConfig = @"..\xml\data-config.xml";

    private List<Product> Load()
    {
        List<Product> list;
        XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
        using (StreamReader sr = new StreamReader(fileProducts))
        {
            list = (List<Product>)serializer.Deserialize(sr);
        }
        return list.ToList();
    }

    private void Save(List<Product> list)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
        using (StreamWriter sw = new StreamWriter(fileProducts))
        {
            serializer.Serialize(sw, list);
        }
    }

    public int Create(DO.Product product)
    {
        List<Product> list = Load();
        if (list.FirstOrDefault(x=>x.Id== item.Id) != null)
        {
            throw new DalAlreadyExistException("there is already a product with id " + item.Id);
        }
        XElement productConfig = XElement.Load(fileConfig);
        int productNum = int.Parse(productConfig.Element("ProductNum").Value);

        Product product = item with { Id = productNum };
        productConfig.Element("ProductNum").SetValue(productNum+1);
        productConfig.Save(fileConfig);
        list.Add(product);
        Save(list);
        return item.Id;
    }

    public Product? Read(Func<Product, bool> filter)
    {
        List<Product> list = Load();
        var result = list?.FirstOrDefault(filter);
        if ( result == null)
        {
            throw new DalNotExistException("there is no product with the required condition");
        }
        return result;    }

    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        List<Product> list = Load();
        return list.Where(filter).ToList();  
    }

    public void Update(DO.Product product)
    {
        List<Product> list = Load();
        if (list.FirstOrDefault(x => x.Id == item.Id) == null)
        {
            throw new DalNotExistException("there no product with id " + item.Id);
        }
        var index = list.FindIndex(x => x.Id == item.Id);
        list[index] = item;
        Save(list);    }
        
    void ICrud<Product>.Delete(int id)
    {
        List<Product> list = Load();
        if (list.FirstOrDefault(x => x.Id == id) == null)
        {
            throw new DalNotExistException("there no product with id " + id);
        }
        list = list.Where(x => x.Id != id).ToList();
        Save(list);    }
}
