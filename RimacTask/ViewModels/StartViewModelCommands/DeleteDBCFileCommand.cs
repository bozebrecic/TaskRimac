using Microsoft.Extensions.DependencyInjection;
using RimacTask.Logic;
using RimacTask.Manager;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RimacTask.ViewModels.StartViewModelCommands
{
    class DeleteDBCFileCommand : ICommand
    {
        public DeleteDBCFileCommand(StartViewModel startViewModel)
        {
            _StartViewModel = startViewModel;
            _NetworkNodeManager = App._ServiceProvider.GetRequiredService<NetworkNodeManager>();
        }

        private StartViewModel _StartViewModel;
        private NetworkNodeManager _NetworkNodeManager;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (_StartViewModel.SelectedDBCFile != null && _StartViewModel.SelectedDBCFile.Id > -1)
            {
                await _NetworkNodeManager.DeleteEntity<NetworkNodes>(_StartViewModel.SelectedDBCFile.Id);

                Task.WaitAll();

                await _StartViewModel.UILoadDBCFiles();

                MessageBox.Show($"Successfully deleted record !");
            }
            else
            {
                MessageBox.Show("Select dbc file !");
            }
        }
    }
}
