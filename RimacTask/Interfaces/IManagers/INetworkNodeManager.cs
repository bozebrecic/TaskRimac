using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Interfaces.IManagers
{
    public interface INetworkNodeManager : IModelManager
    {
        public abstract void CreateEntity<T>(T entity) where T : class;
        public abstract T GetById<T>(int id) where T : class;
        public abstract void DeleteEntity<T>(T entity) where T : class;
    }
}
