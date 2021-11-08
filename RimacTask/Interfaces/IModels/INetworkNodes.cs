using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Interfaces.IModels
{
    public interface INetworkNodes
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract string ToString();
    }
}
