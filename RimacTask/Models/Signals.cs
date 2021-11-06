using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Models
{
    public class Signals
    {
        public const string Remark = "SG_ ";
        public string Name { get; set; }
        public int BitStart { get; set; }
        public int Length { get; set; }
    }
}
