namespace PizzahutApiApplication.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        public Task<T> Get(K id);
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(K id);
        public Task<IEnumerable<T>> Get();
    }
}
