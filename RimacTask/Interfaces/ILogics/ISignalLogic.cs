using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Interfaces.ILogics
{
    interface ISignalLogic : IModelLogic
    {
        public abstract T ParseSignal<T>(string line) where T : class;
    }
}
