using RimacTask.DbContexts;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RimacTask.DataAccessLayer
{
    public class MessagesDataDAL : DAL
    {
        public MessagesDataDAL(NetworkNodeDbContext networkNodeDbContext) : base(networkNodeDbContext) { }

        public override void CreateEntity<T>(T entity)
        {
            Messages messages = (Messages)Convert.ChangeType(entity, typeof(Messages));

            _NetworkNodeDbContext.MessagesData.Add(messages);
        }

        public override T GetById<T>(int id)
        {
            //Messages networkNodes = _NetworkNodeDbContext.NetworkNodeData.Find(id);

            //return (T)Convert.ChangeType(networkNodes, typeof(NetworkNodes));
            throw new NotImplementedException();
        }
    }
}
