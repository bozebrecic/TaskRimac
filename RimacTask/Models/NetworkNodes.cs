using RimacTask.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RimacTask.Models
{
    public class NetworkNodes : INetworkNodes
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Messages> Messages { get; set; } = new List<Messages>();

    }
}
