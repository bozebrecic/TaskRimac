using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RimacTask.Interfaces.IDALs
{
    interface IDAL
    {
        /// <summary>
        /// Method just call DbContext.SaveChanges()
        /// </summary>
        /// <returns></returns>
        public int UpdateDatabase();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<int> UpdateDatabaseAsync();

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public abstract void DeleteEntity<T>(T entity) where T : class;

        /// <summary>
        /// Get all records
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract List<T> GetAll<T>() where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public abstract void CreateEntity<T>(T entity) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract T GetById<T>(int id) where T : class;
    }
}
