using RimacTask.DataAccessLayer;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Manager
{
    public class NetworkNodeManager : ModelManager
    {
        public NetworkNodeManager(NetworkNodeDataDAL networkNodeDataDAL) : base(networkNodeDataDAL) { }
        public override void CreateEntity<T>(T entity)
        {
            NetworkNodes networkNode = (NetworkNodes)Convert.ChangeType(entity, typeof(NetworkNodes));

            _DAL.CreateEntity(networkNode);
        }

        public override void DeleteEntity<T>(T entity)
        {
            NetworkNodes networkNode = (NetworkNodes)Convert.ChangeType(entity, typeof(NetworkNodes));

            _DAL.DeleteEntity<NetworkNodes>(networkNode);
        }

        public override T GetById<T>(int id)
        {
            NetworkNodes networkNode = _DAL.GetById<NetworkNodes>(id);

            return (T)Convert.ChangeType(networkNode, typeof(NetworkNodes));
        }
    }
}
