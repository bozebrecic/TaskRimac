using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using RimacTask.Logic;
using RimacTask.Manager;
using RimacTask.Models;
using RimacTask.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RimacTask.ViewModels.StartViewModelCommands
{
    class LoadDbcFileCommand : ICommand
    {
        public LoadDbcFileCommand(StartViewModel startViewModel)
        {
            _NetworkNodeManager = App._ServiceProvider.GetRequiredService<NetworkNodeManager>();
            _FileDialog = App._ServiceProvider.GetRequiredService<OpenFileDialog>();
            _StartViewModel = startViewModel;
        }

        #region Private fields

        private OpenFileDialog _FileDialog;
        private NetworkNodeManager _NetworkNodeManager;
        private StartViewModel _StartViewModel;
        #endregion

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (_FileDialog.ShowDialog() == true)
            {
                var file = _FileDialog.FileName;

                NetworkNodes networkNodes = _NetworkNodeManager.ParseDbcFile<NetworkNodes>(file);

                if (networkNodes != null)
                    await _NetworkNodeManager.CreateEntity<NetworkNodes>(networkNodes);

                Task.WaitAll();

                await _StartViewModel.UILoadDBCFiles();

                MessageBox.Show($"Successfully added data from file [{file}]");
            }
            else
                MessageBox.Show("Could not find a file");
        }
    }
}
