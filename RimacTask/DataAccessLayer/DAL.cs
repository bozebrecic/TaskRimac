using RimacTask.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimacTask.DataAccessLayer
{
    public abstract class DAL
    {
        public DAL(NetworkNodeDbContext networkNodeDbContext)
        {
            _NetworkNodeDbContext = networkNodeDbContext;
        }

        protected NetworkNodeDbContext _NetworkNodeDbContext { get; set; }

        /// <summary>
        /// Method just call DbContext.SaveChanges()
        /// </summary>
        /// <returns></returns>
        public int UpdateDatabase() => _NetworkNodeDbContext.SaveChanges();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<int> UpdateDatabaseAsnc() => _NetworkNodeDbContext.SaveChangesAsync();

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void DeleteEntity<T>(T entity) where T : class => _NetworkNodeDbContext.Remove<T>(entity);

        /// <summary>
        /// Get all records
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetAll<T>() where T : class => _NetworkNodeDbContext.Set<T>().ToList();

        #region Abtsract methods

        public abstract void CreateEntity<T>(T entity) where T : class;

        public abstract T GetById<T>(int id) where T : class;

        #endregion
    }
}
