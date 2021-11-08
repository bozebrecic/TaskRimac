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
        /// Get all records
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract List<T> GetAll<T>() where T : class;
    }
}
