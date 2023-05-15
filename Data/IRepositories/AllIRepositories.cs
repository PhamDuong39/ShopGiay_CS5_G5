using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepositories
{
    // Interface chap nhan moi class (Generic)
    // where TEntities : class la 1 rang buoc kieu generic
    // No dinhj nghia kieu TEntities phai la 1 class (Ko the la kieu gia tri int, float)
    internal interface AllIRepositories<TEntities> where TEntities : class
    {
        // Tao 1 DBSet de CRUD data
        DbSet<TEntities> Entities { get; set; }

        // Get all Object in DBSet
        Task<IEnumerable<TEntities>> GetAllAsync();

        // Get one Object in DBSet
        Task<TEntities> GetOneAsync(IKey key);

        bool AddOneAsync(TEntities entity); // Thêm 1
        bool AddManyAsync(IEnumerable<TEntities> entity); // Thêm nhiều
        bool DeleteOneAsync(TEntities entity); // Xóa 1
        bool DeleteManyAsync(IEnumerable<TEntities> entity); // Xóa nhiều
        bool UpdateOneAsync(TEntities entity); // Sửa 1
        bool UpdateManyAsync(IEnumerable<TEntities> entity); // Sửa nhiều

    }
}
