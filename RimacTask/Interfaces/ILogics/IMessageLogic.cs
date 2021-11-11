using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Interfaces.ILogics
{
    interface IMessageLogic : IModelLogic
    {
        public abstract T ParseMessage<T>(string line) where T : class;
    }
}
