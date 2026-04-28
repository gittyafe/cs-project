using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Dal;

internal class ProductImplementation : IProduct
{
    private readonly string fileProducts = @"..\xml\products.xml";
    private readonly string fileConfig = @"..\xml\data-config.xml";

    private List<Product> Load()
    {
        if (!File.Exists(fileProducts)) return new List<Product>();
        
        XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
        using (StreamReader sr = new StreamReader(fileProducts))
        {
            return (List<Product>)serializer.Deserialize(sr) ?? new List<Product>();
        }
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
        
        XElement config = XElement.Load(fileConfig);
        int nextId = int.Parse(config.Element("ProductNum").Value);

        Product newProduct = product with { Id = nextId };
        
        config.Element("ProductNum").SetValue(nextId + 1);
        config.Save(fileConfig);

        list.Add(newProduct);
        Save(list);
        return nextId;
    }

    public Product? Read(Func<Product, bool> filter)
    {
        List<Product> list = Load();
        var result = list.FirstOrDefault(filter);
        if (result == null)
        {
            throw new Exception("Product does not exist with the required condition");
        }
        return result;
    }

    public IEnumerable<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        List<Product> list = Load();
        if (filter == null) return list;
        return list.Where(filter);
    }

    public void Update(DO.Product product)
    {
        List<Product> list = Load();
        int index = list.FindIndex(x => x.Id == product.Id);
        
        if (index == -1)
        {
            throw new Exception($"Product with ID {product.Id} not found");
        }
        
        list[index] = product;
        Save(list);
    }

    public void Delete(int id)
    {
        List<Product> list = Load();
        var product = list.FirstOrDefault(x => x.Id == id);
        
        if (product == null)
        {
            throw new Exception($"Product with ID {id} not found");
        }
        
        list.Remove(product);
        Save(list);
    }
}
