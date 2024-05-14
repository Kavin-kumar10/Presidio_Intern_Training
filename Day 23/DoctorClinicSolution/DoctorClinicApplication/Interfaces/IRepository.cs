namespace DoctorClinicApplication.Interface
{
    public interface IRepository<K,T> where T : class
    {
        Task<T> Get(K key);
        Task<IEnumerable<T>> Get();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
