using RimacTask.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RimacTask.Models
{
    public class Messages : IMessages
    {
        public const string Remark = "BO_ ";
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Signals> Signals { get; set; } = new List<Signals>();
        public NetworkNodes NetworkNode { get; set; }
    }
}
