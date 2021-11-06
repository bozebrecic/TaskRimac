using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Interfaces
{
    public interface ISignals
    {
        public string Name { get; set; }
        public int BitStart { get; set; }
        public int Length { get; set; }
    }
}
