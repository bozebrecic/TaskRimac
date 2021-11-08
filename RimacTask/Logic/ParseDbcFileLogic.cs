using RimacTask.Manager;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RimacTask.Logic
{
    public class ParseDbcFileLogic : ModelLogic
    {
        public ParseDbcFileLogic(NetworkNodeManager networkNodeManager) : base(networkNodeManager)
        {

        }
        #region Public properties

        public NetworkNodes NetworkNode { get; set; } = new NetworkNodes();
        public Messages Message { get; set; }
        public Signals Signal { get; set; }
        public string FileContent { get; set; }

        #endregion

        public override NetworkNodes ParseDbcFile(string filePath)
        {
            LoadFile(filePath);

            NetworkNode = new NetworkNodes();

            NetworkNode.Name = Path.GetFileNameWithoutExtension(filePath);

            if (!string.IsNullOrEmpty(FileContent))
            {
                string[] lines = FileContent.Replace("\r", "").Split('\n');

                foreach (string line in lines)
                {
                    if (!String.IsNullOrWhiteSpace(line.Trim()))
                    {
                        if (line.Trim().StartsWith(Messages.Remark))
                        {
                            //Message
                            NetworkNode.Messages.Add(GetMessage(line));
                        }
                        else if (line.Trim().StartsWith(Signals.Remark))
                        {
                            //Signal
                            NetworkNode.Messages.LastOrDefault().Signals.Add(GetSignal(line));
                        }
                        else
                        {
                            //unidentified line
                        }
                    }
                }
            }
            _ModelManager.CreateEntity<NetworkNodes>(NetworkNode);
            _ModelManager.UpdateDatabase();

            List<NetworkNodes> networkNodes = _ModelManager.GetAll<NetworkNodes>();

            _ModelManager.DeleteEntity<NetworkNodes>(NetworkNode);
            _ModelManager.UpdateDatabase();

            return NetworkNode;
        }

        private void LoadFile(string filePath)
        {
            string[] linesInFile = File.ReadAllLines(filePath);

            FileContent = "";
            foreach (string line in linesInFile)
                FileContent += line + "\r\n";
        }

        private Messages GetMessage(string line)
        {
            Message = new Messages();

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
            return Message;
        }

        private Signals GetSignal(string line)
        {
            Signal = new Signals();

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
            return Signal;
        }

        public override List<NetworkNodes> GetAll()
        {
            return _ModelManager.GetAll<NetworkNodes>();
        }
    }
}
