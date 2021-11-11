using RimacTask.DataAccessLayer;
using RimacTask.Interfaces.IManagers;
using RimacTask.Logic;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RimacTask.Manager
{
    public class NetworkNodeManager : ModelManager, INetworkNodeManager
    {
        public NetworkNodeManager(NetworkNodeDataDAL networkNodeDataDAL, NetworkNodeLogic networkNodeLogic) : base(networkNodeDataDAL) 
        {
            _NetworkNodeDataDAL = networkNodeDataDAL;
            _NetworkNodeLogic = networkNodeLogic;
        }

        private NetworkNodeDataDAL _NetworkNodeDataDAL;
        private NetworkNodeLogic _NetworkNodeLogic;

        public async Task CreateEntity<T>(T entity) where T : class
        {
            NetworkNodes networkNode = (NetworkNodes)Convert.ChangeType(entity, typeof(NetworkNodes));

            _NetworkNodeDataDAL.CreateEntity(networkNode);

            Task taskUpdateDatabase = UpdateDatabaseAsync();
            await taskUpdateDatabase;
        }

        public async Task DeleteEntity<T>(int id) where T : class
        {
            NetworkNodes networkNode = GetById<NetworkNodes>(id);

            _NetworkNodeDataDAL.DeleteEntity<NetworkNodes>(networkNode);

            Task taskUpdateDatabase = UpdateDatabaseAsync();
            await taskUpdateDatabase;
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

        public T ParseDbcFile<T>(string filePath) where T : class
        {
            NetworkNodes networkNode = _NetworkNodeLogic.ParseDbcFile<NetworkNodes>(filePath);

            return (T)Convert.ChangeType(networkNode, typeof(NetworkNodes));
        }
    }
}
