using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RimacTask.Interfaces.IManagers
{
    public interface IModelManager
    {
        /// <summary>
        /// Update database.
        /// </summary>
        /// <returns></returns>
        public int UpdateDatabase();

        /// <summary>
        /// Update database async.
        /// </summary>
        /// <returns></returns>
        public Task<int> UpdateDatabaseAsync();
        
        /// <summary>
        /// Get all records of specific type from database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract List<T> GetAll<T>() where T : class;
    }
}
