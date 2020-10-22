using LGAClient.Models;
using LGAClient.Repository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGAClient.Services
{
    public interface IService<T> 
    {
        void Insert(T entity);
        void Update(T entity);
        T FindById(int id);
        Task<IEnumerable<T>> ListAsync();
        Task<bool> DeleteEntityAsync(int id);
        bool VerifyEmail(string email);
    }
    public class Service<T> : IDisposable ,IService<T> where T : class
    {
        private readonly ICRUDRepository<T> _repo;
        private readonly ApplicationDbContext _db;
        public Service(ApplicationDbContext db)
        {
            _db = db;
            _repo = new CRUDRepository<T>(db);
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _repo.ListAsync();
        }
        public async Task<bool> DeleteEntityAsync(int id)
        {
           return  await _repo.DeleteAsync(id);
        }

        public void Insert(T entity)
        {
            _repo.Insert(entity);
        }

        public void Update(T entity)
        {
            _repo.Update(entity);
        }

        public T FindById(int id)
        {
           return  _repo.FindById(id);
        }

        public bool VerifyEmail(string email)
        {
            return  _db.Person.Any(x => x.Email == email);
        }

        public void Dispose()
        {
        }

       
    }



}
