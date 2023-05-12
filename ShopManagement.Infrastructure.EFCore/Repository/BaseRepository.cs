using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class BaseRepository<T, TKey> : IRepository<T, TKey> where T : class
    {
        private readonly DbContext context;

        public BaseRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(T entity)
        {
            context.Add(entity);
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
        }

        public void DeleteAll(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Any(expression);
        }

        public T Get(TKey id)
        {
            return context.Find<T>(id);
        }

        public List<T> Get()
        {
            return context.Set<T>().ToList();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

    

    }
    
}
