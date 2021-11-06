using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Models
{
    public class NetworkNodes
    {
        public string Name { get; set; }
        public List<Messages> Messages { get; set; } = new List<Messages>();
    }
}
