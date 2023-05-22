namespace Data.Repositories;

using Data.IRepositories;
using Data.ShopContext;

using Microsoft.EntityFrameworkCore;

public class AllRepositories<T> : IAllRepositories<T>
    where T : class
{
    private readonly AppDbContext _context;

    private readonly DbSet<T> _dbSet;

    public AllRepositories()
    {
    }

    public AllRepositories(AppDbContext context, DbSet<T> dbSet)
    {
        this._context = context;
        this._dbSet = dbSet;
    }

    public bool CreateItem(T item)
    {
        try
        {
            this._dbSet.Add(item);
            this._context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public bool CreateMany(List<T> items)
    {
        try
        {
            this._dbSet.AddRange(items);
            this._context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public bool DeleteItem(T item)
    {
        try
        {
            this._dbSet.Remove(item);
            this._context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public bool DeleteMany(List<T> items)
    {
        try
        {
            this._dbSet.RemoveRange(items);
            this._context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public IEnumerable<T> GetAll()
    {
        return this._dbSet.ToList();
    }

    public T GetItem(Guid id)
    {
        return this._dbSet.Find(id);
    }

    public bool UpdateItem(T item)
    {
        try
        {
            this._dbSet.Update(item);
            this._context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public bool UpdateMany(List<T> items)
    {
        try
        {
            this._dbSet.UpdateRange(items);
            this._context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}