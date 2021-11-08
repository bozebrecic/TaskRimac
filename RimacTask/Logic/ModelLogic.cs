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

        public abstract T ParseDbcFile<T>(string filePath) where T : class;

        public abstract List<T> GetAll<T>() where T : class;

        public abstract void DeleteEntity<T>(int id) where T : class;
    }
}
