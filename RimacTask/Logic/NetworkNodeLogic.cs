using RimacTask.Interfaces.ILogics;
using RimacTask.Manager;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace RimacTask.Logic
{
    public class NetworkNodeLogic : ModelLogic, INetworkNodeLogic
    {
        public NetworkNodeLogic(SignalLogic signalLogic, MessageLogic messageLogic)
        {
            _MessageLogic = messageLogic;
            _SignalLogic = signalLogic;
        }

        private SignalLogic _SignalLogic;
        private MessageLogic _MessageLogic;

        #region Public properties

        public NetworkNodes NetworkNode { get; set; } = new NetworkNodes();
        public Messages Message { get; set; }
        public Signals Signal { get; set; }
        public string FileContent { get; set; }

        #endregion

        /// <summary>
        /// Parse all messages and correspondig signals from dbc file (network node).
        /// DBC message & signal syntax.
        /// https://www.csselectronics.com/pages/can-dbc-file-database-intro 
        /// </summary>
        /// <param name="filePath"></param>
        public T ParseDbcFile<T>(string filePath) where T : class
        {
            LoadFile(filePath);
            if (Path.GetExtension(filePath).ToLower() != ".dbc")
            {
                MessageBox.Show("File must be DBC file (*.dbc)!");
            }
            else
            {
                NetworkNode.Name = Path.GetFileNameWithoutExtension(filePath);

                try
                {
                    if (!string.IsNullOrEmpty(FileContent))
                    {
                        string[] lines = FileContent.Replace("\r", "").Split('\n');

                        foreach (string line in lines)
                        {
                            if (!String.IsNullOrWhiteSpace(line.Trim()))
                            {
                                //if line in record starts with message remark "BO_ " its message type
                                if (line.Trim().StartsWith(Messages.Remark))
                                {
                                    //Message
                                    NetworkNode.Messages.Add(_MessageLogic.ParseMessage<Messages>(line));
                                }
                                //if line in record starts with signal remark "SG_ " its message type
                                else if (line.Trim().StartsWith(Signals.Remark))
                                {
                                    //Signal add to last added message in network node (message has corresponding signals
                                    NetworkNode.Messages.LastOrDefault().Signals.Add(_SignalLogic.ParseSignal<Signals>(line));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Problem with parsing DBC file! Error: [{ex.Message}]");
                }
            }
            if(NetworkNode.Messages.Count == 0)
            {
                throw new Exception("No valid records!");
            }
            return (T)Convert.ChangeType(NetworkNode, typeof(NetworkNodes));

        }

        /// <summary>
        /// Read file data line by line.
        /// </summary>
        /// <param name="filePath"></param>
        public void LoadFile(string filePath)
        {
            string[] linesInFile = File.ReadAllLines(filePath);

            FileContent = "";
            foreach (string line in linesInFile)
                FileContent += line + "\r\n";
        }
    }
}