using RimacTask.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RimacTask.Manager
{
    public abstract class ModelManager
    {
        public ModelManager(DAL dataAccessLayer)
        {
            _DAL = dataAccessLayer;
        }

        private DAL _DAL;

        public int UpdateDatabase() => _DAL.UpdateDatabase();

        public Task<int> UpdateDatabaseAsync() => _DAL.UpdateDatabaseAsync();

        #region Abstract methods

        public abstract void CreateEntity<T>(T entity) where T : class;

        public abstract T GetByName<T>(string networkNodeName) where T : class;

        #endregion
    }
}
