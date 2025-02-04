using DuszaTKVGameLib.Interfaces;

namespace BettingGameAPI.Models
{
    public class Repository<T> where T : IIdentified
    {
        private List<T> values { get; set; }
        public IEnumerable<T> Values => values;

        public Repository()
        {
            values = new List<T>();
        }

        public void Add(T value)
        {
            values.Add(value);
        }

        public void Update(T value)
        {
            values[values.IndexOf(value)] = value;
        }

        public void Remove(T value)
        {
            values.Remove(value);
        }

        public T? this[int id]
        {
            get
            {
                return values.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
