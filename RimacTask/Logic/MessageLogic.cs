using RimacTask.Interfaces.ILogics;
using RimacTask.Interfaces.IManagers;
using RimacTask.Manager;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace RimacTask.Logic
{
    public class MessageLogic : ModelLogic, IMessageLogic
    {
        public MessageLogic() 
        {
            
        }
        /// <summary>
        /// Parse record line with message syntax to get message id and message name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="line">Line from dbc file.</param>
        /// <returns></returns>
        public T ParseMessage<T>(string line) where T : class
        {
            Messages messageRecord = new Messages();

            try
            {
                if (!String.IsNullOrWhiteSpace(line) && line.Contains(":"))
                {
                    // BO_ 199 WheelInfoIEEE: 8 ABS
                    string[] vs = line.Split(':');
                    messageRecord.Name = (vs.Length > 1 ? vs[1].Trim() : String.Empty).Split(" ")[1];

                    string[] haux = vs[0].Split(' ');
                    if (int.TryParse(haux[1], out int id))
                    {
                        messageRecord.MesssageId = id;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to parse message! [Error]: {ex.Message}!");
            }

            return (T)Convert.ChangeType(messageRecord, typeof(Messages));
        }
    }
}
