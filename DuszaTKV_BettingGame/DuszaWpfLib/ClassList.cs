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
        public abstract ClassList<T> AddItem(T item);
        public IEnumerable<T> Items => items.Select(x => x);
        public abstract T this[string index]
        {
            get;
            set;
        }
    }
}
