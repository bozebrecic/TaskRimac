using RimacTask.Interfaces.ILogics;
using RimacTask.Manager;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Logic
{
    public class SignalLogic : ModelLogic, ISignalLogic
    {
        public SignalLogic(SignalManager signalManager) : base(signalManager)
        {
            _SignalManager = signalManager;
        }

        private SignalManager _SignalManager;

        public override List<T> GetAll<T>()
        {
            List<Signals> signals = _SignalManager.GetAll<Signals>();

            return (List<T>)Convert.ChangeType(signals, typeof(List<Signals>));
        }
    }
}
