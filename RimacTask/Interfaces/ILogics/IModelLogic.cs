using System;
using System.Collections.Generic;
using System.Text;

namespace RimacTask.Interfaces.ILogics
{
    interface IModelLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public abstract void ParseDbcFile<T>(string filePath) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract List<T> GetAll<T>() where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public abstract void DeleteEntity<T>(int id) where T : class;
    }
}
