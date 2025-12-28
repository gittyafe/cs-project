using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DO;

public record Sale(
    int Id,
    int ProductId,
    int QuantityRequired,
    double TotalPrice,
    bool IsOnlyClub,
    DateTime StartSale,
    DateTime EndSale)
{

    //static int _nextId = 1;
    //int Id = _nextId++;

    public Sale() : this(0,-1, 0, 0, false, DateTime.Now, DateTime.Now)
    {

    }

}
