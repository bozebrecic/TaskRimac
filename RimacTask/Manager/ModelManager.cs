using RimacTask.DataAccessLayer;
using RimacTask.Interfaces.IManagers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RimacTask.Manager
{
    public abstract class ModelManager : IModelManager
    {
        public ModelManager(DAL dataAccessLayer)
        {
            _DAL = dataAccessLayer;
        }

        protected DAL _DAL { get; set; }

        public int UpdateDatabase() => _DAL.UpdateDatabase();

        public Task<int> UpdateDatabaseAsync() => _DAL.UpdateDatabaseAsync();



        #region Abstract methods
        public abstract List<T> GetAll<T>() where T : class;

        #endregion
    }
}
