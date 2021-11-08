using RimacTask.DbContexts;
using RimacTask.Interfaces.IDALs;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RimacTask.DataAccessLayer
{
    public class MessagesDataDAL : DAL, IMessagesDataDAL
    {
        public MessagesDataDAL(NetworkNodeDbContext networkNodeDbContext) : base(networkNodeDbContext) { }

        public override List<T> GetAll<T>()
        {
            List<Messages> messages = _NetworkNodeDbContext.Set<Messages>().ToList();

            return (List<T>)Convert.ChangeType(messages, typeof(List<Messages>));
        }
    }
}
