using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal class Entities<T> where T : ICrud<T>
    {
        public Entities() { }

    }
}
