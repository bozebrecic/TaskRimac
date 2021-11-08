using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using RimacTask.Logic;
using RimacTask.Models;
using RimacTask.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace RimacTask.ViewModels.StartViewModelCommands
{
    class LoadDbcFileCommand : ICommand
    {
        public LoadDbcFileCommand(StartViewModel startViewModel)
        {
            _NetworkNodeLogic = App._ServiceProvider.GetRequiredService<NetworkNodeLogic>();
            _FileDialog = App._ServiceProvider.GetRequiredService<OpenFileDialog>();
            _StartViewModel = startViewModel;
        }

        #region Private fields

        private OpenFileDialog _FileDialog;
        private NetworkNodeLogic _NetworkNodeLogic;
        private StartViewModel _StartViewModel;
        #endregion
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //_StartWindow.LoadedDBCFiles.Items.Add("test");
            if (_FileDialog.ShowDialog() == true)
            {
                var file = _FileDialog.FileName;
                NetworkNodes nn = new NetworkNodes();
                nn = _NetworkNodeLogic.ParseDbcFile<NetworkNodes>(file);
                MessageBox.Show(file);
                _StartViewModel.LoadDBCFiles();
            }
            else
                MessageBox.Show("Could not find a file");
        }
    }
}
