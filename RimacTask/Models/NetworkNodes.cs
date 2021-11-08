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

        public override string ToString()
        {
            string allRecords = "[File]: " + Name +"\n";

            foreach(Messages message in Messages)
            {
                allRecords += "\n[Message]: " + message.Name + "\n";

                foreach(Signals signal in message.Signals)
                {
                    allRecords += $"[Signal]: {signal.Name} [BitStart | Length]: {signal.BitStart} | {signal.Length}\n";
                }
            }
            allRecords += "\n";

            return allRecords;
        }

    }
}
