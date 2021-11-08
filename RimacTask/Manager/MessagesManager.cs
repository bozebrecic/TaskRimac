using RimacTask.DataAccessLayer;
using RimacTask.Interfaces.IDALs;
using RimacTask.Interfaces.IManagers;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Manager
{
    public class MessagesManager : ModelManager, IMessagesManager
    {
        public MessagesManager(MessagesDataDAL messagesDataDAL) : base(messagesDataDAL)
        {
            _MessagesDataDAL = messagesDataDAL;
        }

        private MessagesDataDAL _MessagesDataDAL;

        public override List<T> GetAll<T>()
        {
            List<Messages> messages = _DAL.GetAll<Messages>();

            return (List<T>)Convert.ChangeType(messages, typeof(List<Messages>));
        }

    }
}
