using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
    {
        private readonly DbSet<Developer> developers;
        private readonly ApplicationContext _context;
        public DeveloperRepository(ApplicationContext context) : base(context)
        {
            
            developers = context.Set<Developer>();
            _context = context;
        }
        public IEnumerable<Developer> GetPopularDevelopers(int count)
        {
            return developers.OrderByDescending(d => d.Followers).Take(count).ToList();
        }

        public IEnumerable<Developer> GetDevelopersByName(string name)
        {
            return developers.Where(d => d.Name == name).ToList();
        }

        public IEnumerable<Developer> GetDevelopersByIDD(int id)

        {
            return developers.Where(d => d.Id == id).ToList();
        }

        public Developer GetDevelopersByID(int id)

        {
            return developers.Where(d => d.Id == id).FirstOrDefault();
        }
        public int Save()
       {
            return _context.SaveChanges();
        }
    }
}
