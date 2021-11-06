using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Logic
{
    public abstract class ModelLogic
    {
        public ModelLogic()
        {

        }

        //public abstract void SaveToDatabase();

        public abstract NetworkNodes ParseDbcFile(string filePath);
    }
}
