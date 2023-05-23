namespace Data.Repositories;

using Data.IRepositories;
using Data.ShopContext;

using Microsoft.EntityFrameworkCore;

public class AllRepositories1<T> : IAllRepositories<T>
    where T : class
{
    private readonly AppDbContext DbContext;

    private readonly DbSet<T> dbset;

    public AllRepositories1()
    {
    }

    public AllRepositories1(AppDbContext dbContext, DbSet<T> dbset)
    {
        this.DbContext = dbContext;
        this.dbset = dbset;
    }

    public bool Create(T item)
    {
        try
        {
            this.dbset.Add(item);
            this.DbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Delete(T item)
    {
        try
        {
            this.dbset.Remove(item);
            this.DbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteMany(List<T> items)
    {
        try
        {
            this.dbset.RemoveRange(items);
            this.DbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public IEnumerable<T> GetAll()
    {
        return this.dbset.ToList();
    }

    public T GetItem(Guid id)
    {
        return this.dbset.Find(id);
    }

    // public async Task<T> GetOne(Guid id)
    // {
    // try
    // {
    // return T;
    // }
    // catch (Exception)
    // {

    // throw;
    // }
    // }
    public bool Update(T item)
    {
        try
        {
            this.dbset.Update(item);
            this.DbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}