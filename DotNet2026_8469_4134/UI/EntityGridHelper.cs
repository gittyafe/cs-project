using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    /// <summary>
    /// Helper to create a BindingSource from an IEnumerable<T> by wrapping it
    /// in a BindingList<T>. Reused by the entity manager forms to avoid
    /// duplicating binding logic.
    /// </summary>
    public static class EntityGridHelper
    {
        public static BindingSource CreateBindingSource<T>(IEnumerable<T> items)
        {
            var list = items?.ToList() ?? new List<T>();
            var bl = new BindingList<T>(list);
            return new BindingSource { DataSource = bl };
        }
    }
}
