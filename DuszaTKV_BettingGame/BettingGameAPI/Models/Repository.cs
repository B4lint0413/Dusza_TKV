using DuszaTKVGameLib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BettingGameAPI.Models
{
    public class Repository<T> where T : class, IIdentified
    {
        private DbSet<T> values;
        public IEnumerable<T> Values => values.AsNoTracking().ToList();

        public Repository(DbSet<T> set)
        {
            values = set;
        }

        public void Add(T value)
        {
            var context = values.Add(value);
            context.Context.SaveChanges();
        }

        public void Update(T value)
        {
            var context = values.Update(value);
            context.Context.SaveChanges();
        }

        public void Remove(T value)
        {
            var context = values.Remove(value);
            context.Context.SaveChanges();
        }

        public T? this[int id]
        {
            get
            {
                return Values.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
