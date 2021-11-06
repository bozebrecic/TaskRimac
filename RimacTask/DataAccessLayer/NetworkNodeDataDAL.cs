using RimacTask.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.DataAccessLayer
{
    public class NetworkNodeDataDAL : DAL
    {
        public NetworkNodeDataDAL(NetworkNodeDbContext networkNodeDbContext) : base(networkNodeDbContext) { }

        public override void CreateEntity<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public override T GetByName<T>(string networkNodeName)
        {
            throw new NotImplementedException();
        }
    }
}
