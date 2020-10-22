using LGAClient.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGAClient.Repository
{
    public interface IRepository<T> 
    {
        void Insert(T entity);
        void Update(T entity);
        T FindById(int id);
        Task<IEnumerable<T>> ListAsync();
        Task<bool> DeleteAsync(int id);
    }

    public interface ICRUDRepository<T> : IRepository<T> 
    {
    }

    public class CRUDRepository<TEntity> : ICRUDRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<TEntity> _dbSet;
       
        public CRUDRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = this._db.Set<TEntity>();
        }

        public TEntity FindById(int id)
        {
           return _dbSet.Find(id);
        }

       
        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public void Insert(TEntity entity)
        {
            this._dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this._dbSet.Update(entity);
            _db.SaveChanges();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete == null)
            {
                return false;
            }
            _dbSet.Remove(entityToDelete);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
