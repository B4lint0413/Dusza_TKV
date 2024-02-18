using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib
{
    public abstract class ClassList<T>
    {
        protected readonly List<T> items;

        protected ClassList(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }
        protected ClassList()
        {
            this.items = new List<T>();
        }

        public override string ToString() => string.Join("\n", items);

        protected abstract ClassList<T> AddItem(T item);
        public static ClassList<T> operator +(ClassList<T> classList, T item)
        {
            return classList.AddItem(item);
        }

        public IEnumerable<T> Items => items;
        public abstract T this[string index]
        {
            get;
            set;
        }
    }
}
