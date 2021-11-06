using RimacTask.DbContexts;
using System;
using System.Collections.Generic;
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

        private NetworkNodeDbContext _NetworkNodeDbContext;

        /// <summary>
        /// Method just call DbContext.SaveChanges()
        /// </summary>
        /// <returns></returns>
        public int UpdateDatabase() => _NetworkNodeDbContext.SaveChanges();

        /// <summary>
        /// Method just call DbContext.SaveChangesAsync()
        /// </summary>
        /// <returns></returns>
        public Task<int> UpdateDatabaseAsync() => _NetworkNodeDbContext.SaveChangesAsync();

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void DeleteEntity<T>(T entity) where T : class => _NetworkNodeDbContext.Remove<T>(entity);

        #region Abtsract methods

        public abstract void CreateEntity<T>(T entity) where T : class;

        public abstract T GetByName<T>(string networkNodeName) where T : class;

        #endregion
    }
}
