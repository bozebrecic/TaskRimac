using RimacTask.ViewModels.StartViewModelCommands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RimacTask.ViewModels
{
    public class StartViewModel
    {
        public StartViewModel()
        {
            _LoadDbcFileCommand = new LoadDbcFileCommand();
        }

        #region Private fields

        private ICommand _LoadDbcFileCommand;

        #endregion

        #region Icommand
        public ICommand LoadDbcFileCommand
        {
            get { return _LoadDbcFileCommand; }
            set { _LoadDbcFileCommand = value; }
        }
        #endregion
    }
}
