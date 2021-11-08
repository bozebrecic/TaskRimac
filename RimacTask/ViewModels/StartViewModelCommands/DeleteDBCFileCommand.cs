using Microsoft.Extensions.DependencyInjection;
using RimacTask.Logic;
using RimacTask.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RimacTask.ViewModels.StartViewModelCommands
{
    class DeleteDBCFileCommand : ICommand
    {
        public DeleteDBCFileCommand(StartViewModel startViewModel)
        {
            _StartViewModel = startViewModel;
            _NetworkNodeLogic = App._ServiceProvider.GetRequiredService<NetworkNodeLogic>();
        }

        private StartViewModel _StartViewModel;
        private NetworkNodeLogic _NetworkNodeLogic;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _NetworkNodeLogic.DeleteEntity<NetworkNodes>(_StartViewModel.SelectedDBCFile.Id);
            _StartViewModel.UILoadingDBCFiles();
        }
    }
}
