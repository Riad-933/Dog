using Core.Models;
using Core.RepositoryAbstracts;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.RepositoryConcrets
{
    public class DogRepository : GenericRepository<Dog>, IDogRepository
    {
        public DogRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
