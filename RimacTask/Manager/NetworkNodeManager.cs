using RimacTask.DataAccessLayer;
using RimacTask.Interfaces.IManagers;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Manager
{
    public class NetworkNodeManager : ModelManager, INetworkNodeManager
    {
        public NetworkNodeManager(NetworkNodeDataDAL networkNodeDataDAL) : base(networkNodeDataDAL) 
        {
            _NetworkNodeDataDAL = networkNodeDataDAL;
        }

        private NetworkNodeDataDAL _NetworkNodeDataDAL;

        public void CreateEntity<T>(T entity) where T : class
        {
            NetworkNodes networkNode = (NetworkNodes)Convert.ChangeType(entity, typeof(NetworkNodes));

            _NetworkNodeDataDAL.CreateEntity(networkNode);
        }

        public void DeleteEntity<T>(T entity) where T : class
        {
            NetworkNodes networkNode = (NetworkNodes)Convert.ChangeType(entity, typeof(NetworkNodes));

            _NetworkNodeDataDAL.DeleteEntity<NetworkNodes>(networkNode);
        }

        public override List<T> GetAll<T>()
        {
            List<NetworkNodes> networkNodes = _NetworkNodeDataDAL.GetAll<NetworkNodes>();

            return (List<T>)Convert.ChangeType(networkNodes, typeof(List<NetworkNodes>));
        }

        public T GetById<T>(int id) where T : class
        {
            NetworkNodes networkNode = _NetworkNodeDataDAL.GetById<NetworkNodes>(id);

            return (T)Convert.ChangeType(networkNode, typeof(NetworkNodes));
        }
    }
}
