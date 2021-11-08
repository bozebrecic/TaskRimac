using RimacTask.Interfaces.IDALs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Interfaces.IDALs
{
    interface INetworkNodeDataDAL : IDAL
    {
        public abstract void CreateEntity<T>(T entity) where T : class;
        public abstract T GetById<T>(int id) where T : class;
        public abstract void DeleteEntity<T>(T entity) where T : class;
    }
}
