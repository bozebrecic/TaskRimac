using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Interfaces
{
    public interface INetworkNodes
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract string ToString();
    }
}
