using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RimacTask.Interfaces.IManagers
{
    public interface IModelManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int UpdateDatabase();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<int> UpdateDatabaseAsync();
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract List<T> GetAll<T>() where T : class;
    }
}
