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
            _ParseDbcFileLogic = App._ServiceProvider.GetRequiredService<ParseDbcFileLogic>();
            _FileDialog = App._ServiceProvider.GetRequiredService<OpenFileDialog>();
            _StartViewModel = startViewModel;
            LoadFiles();
            //_StartWindow = App._ServiceProvider.GetRequiredService<StartWindow>();
        }

        #region Private fields

        private OpenFileDialog _FileDialog;
        private ParseDbcFileLogic _ParseDbcFileLogic;
        private StartViewModel _StartViewModel;
        //private StartWindow _StartWindow;
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
                nn = _ParseDbcFileLogic.ParseDbcFile(file);
                MessageBox.Show(file);
            }
            else
                MessageBox.Show("Could not find a file");
        }

        private void LoadFiles()
        {
            List<NetworkNodes> networkNodes = _ParseDbcFileLogic.GetAll();
        }
    }
}
