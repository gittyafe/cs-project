using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

public class NotExistException : Exception
{
    public NotExistException() : base("there is no such item")
    {
    }
}

public class AlreadyExistException : Exception
{
    public AlreadyExistException() : base("there is already such item")
    {
    }
}