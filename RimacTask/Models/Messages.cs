using RimacTask.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RimacTask.Models
{
    public class Messages : IMessages
    {
        public const string Remark = "BO_ ";

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int TempId { get; set; }
        public int MesssageId { get; set; }
        public string Name { get; set; }
        public List<Signals> Signals { get; set; } = new List<Signals>();
        public NetworkNodes NetworkNode { get; set; }
    }
}
