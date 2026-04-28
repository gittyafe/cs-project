

using System.Xml.Linq;

namespace DalXml;

internal static class Config
{           

    private static readonly string  filePath = "data-config";

    public static int ProductNum { get { return NextLibrary("ProductNum"); } }
    public static int SaleNum { get { return NextLibrary("SaleNum"); } }
    public static int NextLibrary(string str)
    {
        XElement configXml = XElement.Load(filePath);
        var temp = configXml.Element(str).Elements().FirstOrDefault();
        int requiredNum = int.Parse(temp.Value);
        configXml.Element(str).Elements().FirstOrDefault().SetValue(requiredNum + 1);
        configXml.Save(filePath);
        return requiredNum;
    }
}


        
