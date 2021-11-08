﻿using RimacTask.Interfaces.ILogics;
using RimacTask.Manager;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Logic
{
    public abstract class ModelLogic : IModelLogic
    {
        public ModelLogic(ModelManager modelManager)
        {
            _ModelManager = modelManager;
        }

        protected ModelManager _ModelManager { get; set; }

        #region Abstract methods
        public abstract List<T> GetAll<T>() where T : class;

        #endregion
    }
}
