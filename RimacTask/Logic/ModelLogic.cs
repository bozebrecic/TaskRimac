using RimacTask.Manager;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Logic
{
    public abstract class ModelLogic
    {
        public ModelLogic(ModelManager modelManager)
        {
            _ModelManager = modelManager;
        }

        protected ModelManager _ModelManager { get; set; }

        //public abstract void SaveToDatabase();

        public abstract NetworkNodes ParseDbcFile(string filePath);

        public abstract List<NetworkNodes> GetAll();
    }
}
