using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDeveloperRepository : IGenericRepository<Developer>
    {
        IEnumerable<Developer> GetPopularDevelopers(int count);
        IEnumerable<Developer> GetDevelopersByName(string name);
        public Developer GetDevelopersByID(int id);
        public int Save();



    }
}
