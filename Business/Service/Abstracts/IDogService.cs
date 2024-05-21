using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Abstracts
{
    public interface IDogService
    {
        Task AddDog(Dog dog);
        void DeleteDog(int id);
        void UpdateDog(int id, Dog newDog);
        Dog GetDog(Func<Dog, bool>? predicate = null);
        List<Dog> GetAllDogs(Func<Dog, bool>? predicate = null);
    }
}
