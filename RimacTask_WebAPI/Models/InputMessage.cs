using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RimacTask_WebAPI.Models
{
    public class InputMessage
    {
        public int MesssageId { get; set; }
        public string Name { get; set; }
        public List<InputSignal> Signals { get; set; }
    }
}
