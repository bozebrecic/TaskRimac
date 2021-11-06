using RimacTask.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RimacTask.Models
{
    public class Signals : ISignals
    {
        public const string Remark = "SG_ ";

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public string Name { get; set; }
        public int BitStart { get; set; }
        public int Length { get; set; }

        public Messages Message { get; set; }
    }
}
