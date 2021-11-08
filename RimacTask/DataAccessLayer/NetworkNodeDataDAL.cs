using RimacTask.DbContexts;
using RimacTask.Interfaces.IDALs;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RimacTask.DataAccessLayer
{
    public class NetworkNodeDataDAL : DAL, INetworkNodeDataDAL
    {
        public NetworkNodeDataDAL(NetworkNodeDbContext networkNodeDbContext) : base(networkNodeDbContext) { }

        public override void CreateEntity<T>(T entity)
        {
            NetworkNodes networkNode = (NetworkNodes)Convert.ChangeType(entity, typeof(NetworkNodes));

            _NetworkNodeDbContext.NetworkNodeData.Add(networkNode);
        }

        public override void DeleteEntity<T>(T entity)
        {
            NetworkNodes networkNode = (NetworkNodes)Convert.ChangeType(entity, typeof(NetworkNodes));

            _NetworkNodeDbContext.Remove<NetworkNodes>(networkNode);
        }

        public override List<T> GetAll<T>()
        {
            List<NetworkNodes> networkNodes = _NetworkNodeDbContext.Set<NetworkNodes>().ToList();

            return (List<T>)Convert.ChangeType(networkNodes, typeof(List<NetworkNodes>));
        }

        public override T GetById<T>(int id)
        {
            NetworkNodes networkNode = _NetworkNodeDbContext.NetworkNodeData.Find(id);

            return (T)Convert.ChangeType(networkNode, typeof(NetworkNodes));
        }


    }
}
