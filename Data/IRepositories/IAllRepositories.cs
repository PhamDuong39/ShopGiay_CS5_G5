namespace Data.IRepositories;

public interface IAllRepositories<T>
    where T : class
{
    public bool Create(T item);

    public bool Delete(T item);

    public bool DeleteMany(List<T> items);

    public IEnumerable<T> GetAll();

    public T GetItem(Guid id);

    public bool Update(T item);
}