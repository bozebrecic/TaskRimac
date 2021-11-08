using RimacTask.DbContexts;
using RimacTask.Interfaces.IDALs;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RimacTask.DataAccessLayer
{
    public class SignalDataDAL : DAL, ISignalDataDAL
    {
        public SignalDataDAL(NetworkNodeDbContext networkNodeDbContext) : base(networkNodeDbContext) { }
        public override List<T> GetAll<T>()
        {
            List<Signals> signals = _NetworkNodeDbContext.Set<Signals>().ToList();

            return (List<T>)Convert.ChangeType(signals, typeof(List<Signals>));
        }
    }
}
