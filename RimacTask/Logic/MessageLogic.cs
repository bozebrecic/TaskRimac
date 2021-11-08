using RimacTask.Interfaces.ILogics;
using RimacTask.Interfaces.IManagers;
using RimacTask.Manager;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Logic
{
    public class MessageLogic : ModelLogic, IMessageLogic
    {
        public MessageLogic(MessagesManager messagesManager) : base(messagesManager) 
        {
            _MessagesManager = messagesManager;
        }
        public override List<T> GetAll<T>()
        {
            List<Messages> networkNodes = _MessagesManager.GetAll<Messages>();

            return (List<T>)Convert.ChangeType(networkNodes, typeof(List<Messages>));
        }

        private MessagesManager _MessagesManager;
    }
}
