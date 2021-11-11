using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Interfaces.ILogics
{
    interface INetworkNodeLogic : IModelLogic
    {
        public abstract void LoadFile(string filePath);
        public abstract T ParseDbcFile<T>(string filePath) where T : class;
    }
}
