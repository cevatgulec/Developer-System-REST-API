using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        T GetByName(string name);
        //Task<TResult> GetAsync<TResult>(int? id);
        //Task DeleteAsync(int id);
        //Task<bool> Exists(int id);
        //Task UpdateAsync(T entity);
        //Task UpdateAsync<TSource>(int id, TSource source) where TSource : IGenericRepository<T>;
        Task<T> GetAsync(int? id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> FindAsync(string name);
        public void UpdateDev(T entity);
        string Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        //public void UpdateDev(T entity);
    }
}
