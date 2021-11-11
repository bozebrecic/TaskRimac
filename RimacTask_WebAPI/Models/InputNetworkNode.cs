using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RimacTask_WebAPI.Models
{
    public class InputNetworkNode
    {
        public string Name { get; set; }
        public List<InputMessage> Messages { get; set; }
    }
}
