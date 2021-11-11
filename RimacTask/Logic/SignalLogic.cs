using RimacTask.Interfaces.ILogics;
using RimacTask.Manager;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace RimacTask.Logic
{
    public class SignalLogic : ModelLogic, ISignalLogic
    {
        public SignalLogic()
        {
            
        }

        /// <summary>
        /// Parse record line with signal syntax to get signal name, bit start and length.
        /// </summary>
        /// <typeparam name="T">Type of signal</typeparam>
        /// <param name="line">Line from dbc file.</param>
        /// <returns></returns>
        public T ParseSignal<T>(string line) where T : class
        {
            Signals signalRecord = new Signals();

            try
            {
                if (!String.IsNullOrWhiteSpace(line) && line.Contains(":"))
                {
                    //SG_ WheelSpeedRR : 48|16@1+ (0.02,0) [0|1300] "1/min"  GearBox
                    string[] aux = line.Trim().Split(':');
                    string[] values = aux[1].Trim().Split(' ');
                    signalRecord.Name = aux[0].Trim().Split(' ')[1];
                    string[] signalRecieve = (values.Length > 0 ? values[0] : String.Empty).Split("|");

                    signalRecord.BitStart = int.Parse(signalRecieve[0]);
                    if (signalRecieve[1].IndexOf("@") != -1)
                    {
                        var length = signalRecieve[1].Remove(signalRecieve[1].IndexOf("@"));
                        signalRecord.Length = int.Parse(length);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to parse signal! [Error]: {ex.Message}!");
            }

            return (T)Convert.ChangeType(signalRecord, typeof(Signals));
        }
    }
}
