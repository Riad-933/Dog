using Business.Exceptions;
using Business.Extension;
using Business.Service.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Concrets
{
    public class DogService : IDogService
    {

        private readonly IDogRepository _DogRepository;
        private readonly IWebHostEnvironment _env;

        public DogService(IDogRepository DogRepository, IWebHostEnvironment env)
        {
            _DogRepository = DogRepository;
            _env = env;
        }

        public async Task AddDog(Dog Dog)
        {
            if (Dog.ImageFile == null)
                throw new FileNullReferanceException("File bos ola bilmez!");

            Dog.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\Dogs", Dog.ImageFile);

            await _DogRepository.AddAsync(Dog);
            await _DogRepository.CommitAsync();
        }

        public void DeleteDog(int id)
        {
            var existDog = _DogRepository.Get(x => x.Id == id);
            if (existDog == null) throw new EntityNotFoundException("Dog tapilmadi");

            if (existDog.ImageFile != null)
            {
                Helper.DeleteFile(_env.WebRootPath, @"uploads\Dogs", existDog.ImageUrl);
            }

            _DogRepository.Delete(existDog);
            _DogRepository.Commit();

        }

        public List<Dog> GetAllDogs(Func<Dog, bool>? predicate = null)
        {
            return _DogRepository.GetAll(predicate);
        }

        public Dog GetDog(Func<Dog, bool>? predicate = null)
        {
            return _DogRepository.Get(predicate);
        }

        public void UpdateDog(int id, Dog newDog)
        {
            var oldDog = _DogRepository.Get(x => x.Id == id);
            if (oldDog == null) throw new EntityNotFoundException("Dog tapilmadi!");

            if (oldDog.ImageFile != null)
            {

                Helper.DeleteFile(_env.WebRootPath, @"uploads\Dogs", oldDog.ImageUrl);

                oldDog.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\Dogs", newDog.ImageFile);

            }
            else
            {
                oldDog.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\Dogs", newDog.ImageFile);
            }

            oldDog.Title = newDog.Title;
            oldDog.Description = newDog.Description;
            oldDog.RedirectUrl = newDog.RedirectUrl;

            _DogRepository.Commit();
        }
    }
}
