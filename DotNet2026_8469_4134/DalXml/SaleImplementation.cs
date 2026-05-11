using DalApi;
using DalXml;
using DO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Dal;

internal class SaleImplementation:ISale
{
    private readonly string fileSales = @"..\xml\sales.xml";
    private readonly string fileConfig = @"..\xml\data-config.xml";

    private List<Sale> Load()
    {
        // אם הקובץ לא קיים - צור קובץ ריק עם root מתאים
        if (!System.IO.File.Exists(fileSales))
        {
            System.IO.File.WriteAllText(fileSales, "<?xml version=\"1.0\" encoding=\"utf-8\"?><ArrayOfSale />");
        }

        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
            using (StreamReader sr = new StreamReader(fileSales))
            {
                var result = (List<Sale>)serializer.Deserialize(sr);
                return result?.ToList() ?? new List<Sale>();
            }
        }
        catch (Exception)
        {
            // אם הדסיריאליזציה נכשלה (קובץ שבור/פורמט שונה), ננסה לקרוא ידנית בעזרת XDocument
            try
            {
                var doc = XDocument.Load(fileSales);
                var list = doc.Descendants("Sale").Select(s => new Sale(
                    Id: int.Parse(s.Element("Id")?.Value ?? "0"),
                    ProductId: int.Parse(s.Element("ProductId")?.Value ?? "-1"),
                    QuantityRequired: int.Parse(s.Element("QuantityRequired")?.Value ?? "0"),
                    TotalPrice: double.Parse(s.Element("TotalPrice")?.Value ?? "0"),
                    IsOnlyClub: bool.Parse(s.Element("IsOnlyClub")?.Value ?? "false"),
                    StartSale: DateTime.Parse(s.Element("StartSale")?.Value ?? DateTime.Now.ToString()),
                    EndSale: DateTime.Parse(s.Element("EndSale")?.Value ?? DateTime.Now.ToString())
                )).ToList();

                return list;
            }
            catch (Exception)
            {
                // אם גם זה נכשל, החזר רשימה ריקה במקום לחרוג
                return new List<Sale>();
            }
        }
    }

    private void Save(List<Sale> list)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
        using (StreamWriter sw = new StreamWriter(fileSales))
        {
            serializer.Serialize(sw, list);
        }
    }

    public int Create(Sale item)
    {
        List<Sale> list = Load();
      
        XElement saleConfig = XElement.Load(fileConfig);
        int saleNum = int.Parse(saleConfig.Element("SaleNum").Value);

        Sale sale = item with { Id = saleNum };
        saleConfig.Element("SaleNum").SetValue(saleNum + 1);
        saleConfig.Save(fileConfig);
        list.Add(sale);
        Save(list);
        return item.Id;
    }
    public Sale Read(Func<Sale, bool> filter)
    {
        List<Sale> list = Load();
        var result = list?.FirstOrDefault(filter);
        if ( result == null)
        {
            throw new DalNotExistException("there is no sale with the required condition");
        }
        return result;
    }
    public List<Sale> ReadAll(Func<Sale, bool> filter)
    {
        List<Sale> list = Load();
        return list.Where(filter).ToList();
    }
    public void Update(Sale item)
    {
        List<Sale> list = Load();
        if (list.FirstOrDefault(x => x.Id == item.Id) == null)
        {
            throw new DalNotExistException("there no sale with id " + item.Id);
        }
        var index = list.FindIndex(x => x.Id == item.Id);
        list[index] = item;
        Save(list);
    }
    public void Delete(int id)
    {
        List<Sale> list = Load();
        if (list.FirstOrDefault(x => x.Id == id) == null)
        {
            throw new DalNotExistException("there no sale with id " + id);
        }
        list = list.Where(x => x.Id != id).ToList();
        Save(list);
    }
}
