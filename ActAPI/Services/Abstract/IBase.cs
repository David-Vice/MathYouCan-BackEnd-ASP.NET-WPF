namespace ActAPI.Services.Abstract
{
    public interface IBase<T>
    {
        Task<T?> Get(int id);
        Task<IEnumerable<T?>> GetAll();
        Task Add(T obj);
        Task Delete(T obj);
        Task<T> Update(T obj);
    }
}
