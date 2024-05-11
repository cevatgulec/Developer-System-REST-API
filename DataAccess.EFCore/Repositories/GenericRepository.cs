using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace DataAccess.EFCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public string Add(T entity)
        {
            _context.Set<T>().Add(entity);

            return ("You added new developer");
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        //public async Task UpdateAsync(T entity)
        //{
        //    _context.Update(entity);
        //    await _context.SaveChangesAsync();
        //}

        public void UpdateDev(T entity)
        {
            
            _context.Set<T>().Update(entity);
        }


        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetByName(string name)
        {
            return _context.Set<T>().Find(name);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        //public async Task DeleteAsync(int id)
        //{
        //    var entity = await GetAsync(id);

        //    if (entity is null)
        //    {
        //        throw new Exception();
        //    }
        //}

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
            }

            //public async Task<bool> Exists(int id)
            //{
            //    var entity = await GetAsync(id);
            //    return entity != null;
            //}

            //public async Task<T> GetAsync(int? id)
            //{
            //    if (id is null)
            //    {
            //        return null;
            //    }

            //    return await _context.Set<T>().FindAsync(id);
            //}

            public Task<IEnumerable<T>> FindAsync(string name)
        {
            throw new NotImplementedException();
        }

        
    }
}
