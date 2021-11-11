using RimacTask.DataAccessLayer;
using RimacTask.Interfaces.IManagers;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RimacTask.Manager
{
    public class SignalManager : ModelManager, ISignalManager
    {
        public SignalManager(SignalDataDAL signalDataDAL) : base(signalDataDAL) 
        {
            _SignalDataDAL = signalDataDAL;
        }

        private SignalDataDAL _SignalDataDAL;

        public override List<T> GetAll<T>()
        {
            List<Signals> signals = _SignalDataDAL.GetAll<Signals>();

            return (List<T>)Convert.ChangeType(signals, typeof(List<Signals>));
        }
    }
}
