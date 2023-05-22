using Data.ShopContext;
using Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AllRepositories<KEntities> : AllIRepositories<KEntities> where KEntities : class
    {
        private AppDbContext DbContext;

        // Tao 1 DBSet de truy cap, Thao tac voi cac tap hop doi tuong KEntities  trong CSDL. 
        // Day la 1 Attribute duoc khoi tao trong repos
        public DbSet<KEntities> Entities;


        // Day la 1 trien khai cua thuoc tinh Entities duoc dinh nghia trong Interface  

        DbSet<KEntities> AllIRepositories<KEntities>.Entities { get; set; }
        public AllRepositories()
        {
            
        }

        public AllRepositories(AppDbContext DbContext, DbSet<KEntities> dbset)
        {
            this.DbContext = DbContext;
            this.Entities = dbset;
        }

        public bool AddManyAsync(IEnumerable<KEntities> entity)
        {
            try
            {
                Entities.AddRange(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddOneAsync(KEntities entity)
        {
            try
            {
                Entities.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeleteManyAsync(IEnumerable<KEntities> entity)
        {
            try
            {
                Entities.RemoveRange(entity); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteOneAsync(KEntities entity)
        {
            try
            {
                Entities.Remove(entity); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // async, await => thuc hien cac hoat dong bat dong bo trong cac method

        // async : cho phep method thuc hien cac tac vu (TASK) khong dong bo ma khong chan luong chinh. 
        // Luong chinh co the tiep tuc thuc thi cac tac vu khac trong khi cac TASK dang chay

        // await : doi 1 TASK hoan thanh truoc khi tiep tuc thuc thi cac cau lenh tiep trong method.
        // Khi gap Await , luong chinh se tam dung va cho doi TASK ket thuc.

        // => Cai thien hieu suat, kha nang phan hoi = cach cho phep luong chinh hoat dong tiep tuc ma khong bi chan 
        // Khi cho doi cac TASK hoan thanh.
        public async Task<IEnumerable<KEntities>> GetAllAsync()
        {
            
            return await Entities.ToListAsync(); //  Lấy tất cả ra từ DBSet
        }

        public async Task<KEntities> GetOneAsync(IKey key)
        {
            return await Entities.FindAsync(key); // Dùng find để tìm
        }

        public bool UpdateManyAsync(IEnumerable<KEntities> entity)
        {
            try
            {
                Entities.UpdateRange(entity); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateOneAsync(KEntities entity)
        {
            try
            {
                Entities.Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
