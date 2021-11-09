using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Interfaces.IManagers
{
    public interface INetworkNodeManager : IModelManager
    {
        /// <summary>
        /// Create entity of specific type
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="entity">Entity</param>
        public abstract void CreateEntity<T>(T entity) where T : class;

        /// <summary>
        /// Get record with id from database.
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="id">Id of entity.</param>
        /// <returns></returns>
        public abstract T GetById<T>(int id) where T : class;

        /// <summary>
        /// Delete entity from database.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="entity">Entity</param>
        public abstract void DeleteEntity<T>(T entity) where T : class;
    }
}
