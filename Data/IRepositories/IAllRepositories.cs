namespace Data.IRepositories;

public interface IAllRepositories<T>
{
    public bool CreateItem(T item);

    public bool CreateMany(List<T> items);

    public bool DeleteItem(T item);

    public bool DeleteMany(List<T> items);

    public IEnumerable<T> GetAll();

    public T GetItem(Guid id);

    public bool UpdateItem(T item);

    public bool UpdateMany(List<T> items);
}