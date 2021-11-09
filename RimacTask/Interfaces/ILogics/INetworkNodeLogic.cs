using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Interfaces.ILogics
{
    interface INetworkNodeLogic : IModelLogic
    {
        public abstract T GetSignal<T>(string line) where T : class;
        public abstract T GetMessage<T>(string line) where T : class;
        public abstract void LoadFile(string filePath);
        public abstract void DeleteEntity<T>(int id) where T : class;
        public abstract void ParseDbcFile(string filePath);
        public abstract void UpdateDatabase();
    }
}
