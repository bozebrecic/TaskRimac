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

        protected DAL _DAL { get; set; }

        public int UpdateDatabase() => _DAL.UpdateDatabase();

        public Task<int> UpdateDatabaseAsync() => _DAL.UpdateDatabaseAsnc();

        public List<T> GetAll<T>() where T : class => _DAL.GetAll<T>();

        #region Abstract methods

        public abstract void CreateEntity<T>(T entity) where T : class;

        public abstract T GetById<T>(int id) where T : class;

        public abstract void DeleteEntity<T>(T entity) where T : class;

        #endregion
    }
}
