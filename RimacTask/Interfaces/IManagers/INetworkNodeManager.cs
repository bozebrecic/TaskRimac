using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RimacTask.Interfaces.IManagers
{
    public interface INetworkNodeManager : IModelManager
    {
        /// <summary>
        /// Create entity of specific type
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="entity">Entity</param>
        public abstract Task CreateEntity<T>(T entity) where T : class;

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
        public abstract Task DeleteEntity<T>(int id) where T : class;

        /// <summary>
        /// Parse all messages and correspondig signals from dbc file (network node).
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="filePath">Path</param>
        /// <returns></returns>
        public abstract T ParseDbcFile<T>(string filePath) where T : class;
    }
}
