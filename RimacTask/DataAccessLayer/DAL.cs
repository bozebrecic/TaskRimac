using RimacTask.DbContexts;
using RimacTask.Interfaces.IDALs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimacTask.DataAccessLayer
{
    public abstract class DAL : IDAL
    {
        public DAL(NetworkNodeDbContext networkNodeDbContext)
        {
            _NetworkNodeDbContext = networkNodeDbContext;
        }

        protected NetworkNodeDbContext _NetworkNodeDbContext { get; set; }

        public int UpdateDatabase() => _NetworkNodeDbContext.SaveChanges();

        public Task<int> UpdateDatabaseAsync() => _NetworkNodeDbContext.SaveChangesAsync();


        #region Abtsract methods
        public abstract List<T> GetAll<T>() where T : class; 

        #endregion
    }
}
