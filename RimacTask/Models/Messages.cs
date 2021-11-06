using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Models
{
    public class Messages
    {
        public const string Remark = "BO_ ";
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Signals> Signals { get; set; } = new List<Signals>();
    }
}
