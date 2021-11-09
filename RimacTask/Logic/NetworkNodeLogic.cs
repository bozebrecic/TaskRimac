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
        public NetworkNodeLogic(NetworkNodeManager networkNodeManager) : base(networkNodeManager)
        {
            _NetworkNodeManager = networkNodeManager;
        }

        private NetworkNodeManager _NetworkNodeManager;

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
        public void ParseDbcFile(string filePath)
        {
            LoadFile(filePath);

            NetworkNode.Name = Path.GetFileNameWithoutExtension(filePath);

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
                            NetworkNode.Messages.Add(GetMessage<Messages>(line));
                        }
                        //if line in record starts with signal remark "SG_ " its message type
                        else if (line.Trim().StartsWith(Signals.Remark))
                        {
                            //Signal add to last added message in network node (message has corresponding signals
                            NetworkNode.Messages.LastOrDefault().Signals.Add(GetSignal<Signals>(line));
                        }
                    }
                }
            }

            _NetworkNodeManager.CreateEntity(NetworkNode);
             UpdateDatabase();

        }

        /// <summary>
        /// Get list of records of specific type from database.
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <returns></returns>
        public override List<T> GetAll<T>()
        {
            List<NetworkNodes> networkNodes = _NetworkNodeManager.GetAll<NetworkNodes>();

            return (List<T>)Convert.ChangeType(networkNodes, typeof(List<NetworkNodes>));
        }

        /// <summary>
        /// Parse record line with signal syntax to get signal name, bit start and length.
        /// </summary>
        /// <typeparam name="T">Type of signal</typeparam>
        /// <param name="line">Line from dbc file.</param>
        /// <returns></returns>
        public T GetSignal<T>(string line) where T : class
        {
            Signal = new Signals();

            try
            {
                if (!String.IsNullOrWhiteSpace(line) && line.Contains(":"))
                {
                    //SG_ WheelSpeedRR : 48|16@1+ (0.02,0) [0|1300] "1/min"  GearBox
                    string[] aux = line.Trim().Split(':');
                    string[] values = aux[1].Trim().Split(' ');
                    Signal.Name = aux[0].Trim().Split(' ')[1];
                    string[] signalRecieve = (values.Length > 0 ? values[0] : String.Empty).Split("|");

                    Signal.BitStart = int.Parse(signalRecieve[0]);
                    if (signalRecieve[1].IndexOf("@") != -1)
                    {
                        var length = signalRecieve[1].Remove(signalRecieve[1].IndexOf("@"));
                        Signal.Length = int.Parse(length);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to parse signal! [Error]: {ex.Message}!");
            }

            return (T)Convert.ChangeType(Signal, typeof(Signals));
        }

        /// <summary>
        /// Parse record line with message syntax to get message id and message name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="line">Line from dbc file.</param>
        /// <returns></returns>
        public T GetMessage<T>(string line) where T : class
        {
            Message = new Messages();

            try
            {
                if (!String.IsNullOrWhiteSpace(line) && line.Contains(":"))
                {
                    //BO_ 199 WheelInfoIEEE: 8 ABS
                    string[] vs = line.Split(':');
                    Message.Name = (vs.Length > 1 ? vs[1].Trim() : String.Empty).Split(" ")[1];

                    string[] haux = vs[0].Split(' ');
                    if (int.TryParse(haux[1], out int id))
                    {
                        Message.MesssageId = id;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to parse message! [Error]: {ex.Message}!");
            }

            return (T)Convert.ChangeType(Message, typeof(Messages));
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

        /// <summary>
        /// Delete entity from database with given Id of entity.
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="id">Id of network node</param>
        public void DeleteEntity<T>(int id) where T : class
        {
            NetworkNodes networkNode = _NetworkNodeManager.GetById<NetworkNodes>(id);
            _NetworkNodeManager.DeleteEntity<NetworkNodes>(networkNode);
            UpdateDatabase();
        }

        /// <summary>
        /// Update database.
        /// </summary>
        public void UpdateDatabase()
        {
            _NetworkNodeManager.UpdateDatabase();
        }
    }
}