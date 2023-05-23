using Data.IRepositories;
using Data.ShopContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AllRepositories1<T> : IAllRepositories<T> where T : class
    {
        AppDbContext DbContext;
        DbSet<T> dbset;

        public AllRepositories1()
        {
            
        }

        public AllRepositories1(AppDbContext dbContext, DbSet<T> dbset)
        {
            DbContext = dbContext;
            this.dbset = dbset;
        }

        public bool Create(T item)
        {
            try
            {
                dbset.Add(item);
                 DbContext.SaveChanges();
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
                dbset.Remove(item);
                 DbContext.SaveChanges();
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
                dbset.RemoveRange(items);
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public T GetItem(Guid id)
        {
            return this.dbset.Find(id); 
        }

        public IEnumerable<T> GetAll()
        {
            return  dbset.ToList();
        }

        //public async Task<T> GetOne(Guid id)
        //{
        //    try
        //    {
        //        return T;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public bool Update(T item)
        {
            try
            {
                dbset.Update(item);
                 DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
