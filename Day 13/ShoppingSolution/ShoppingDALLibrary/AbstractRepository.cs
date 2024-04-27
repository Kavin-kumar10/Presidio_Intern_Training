using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionHandling;

namespace ShoppingDALLibrary
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        public List<T> items = new List<T>();
        public async Task<T> Add(T item)
        {
            if (items.Contains(item)) throw new DuplicateItemFoundException();
            items.Add(item);
            return item;
        }
        public async Task<ICollection<T>> GetAll()
        {
            if(items.Count == 0) throw new ItemNotFoundException();
            //items.Sort();
            return items;
        }

        public abstract Task<T> Delete(K key);


        public abstract Task<T> GetByKey(K key);

        public abstract Task<T> Update(T item);

    }
}
