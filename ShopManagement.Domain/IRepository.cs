using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain
{
    public interface IRepository<T , TKey> where T : class
    {
        T Get(TKey id);
        List<T> Get();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
      
        void DeleteAll(IEnumerable<T> entities);
       
        bool Exist(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
