using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using RimacTask.Logic;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace RimacTask.ViewModels.StartViewModelCommands
{
    class LoadDbcFileCommand : ICommand
    {
        public LoadDbcFileCommand()
        {
            _ParseDbcFileLogic = App._ServiceProvider.GetRequiredService<ParseDbcFileLogic>();
            _FileDialog = App._ServiceProvider.GetRequiredService<OpenFileDialog>();
        }

        #region Private fields

        private OpenFileDialog _FileDialog;
        private ParseDbcFileLogic _ParseDbcFileLogic;

        #endregion
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_FileDialog.ShowDialog() == true)
            {
                var file = _FileDialog.FileName;
                NetworkNodes nn = new NetworkNodes();
                nn = _ParseDbcFileLogic.ParseDbcFile(file);
                MessageBox.Show(file);
            }
            else
                MessageBox.Show("Could not find a file");
        }
    }
}
