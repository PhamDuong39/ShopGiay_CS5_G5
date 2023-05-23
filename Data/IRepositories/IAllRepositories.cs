using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepositories
{
    public interface IAllRepositories<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public bool Create(T item);
        public bool Update(T item);
        public bool Delete(T item);
        public bool DeleteMany(List<T> items);
        public T GetItem(Guid id);
    }
}
