using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RimacTask_WebAPI.Models
{
    public class InputSignal
    {
        public string Name { get; set; }
        public int BitStart { get; set; }
        public int Length { get; set; }
    }
}
