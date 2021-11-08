using Microsoft.Extensions.DependencyInjection;
using RimacTask.Logic;
using RimacTask.Models;
using RimacTask.ViewModels.StartViewModelCommands;
using RimacTask.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace RimacTask.ViewModels
{
    public class StartViewModel
    {
        public StartViewModel()
        {
            _LoadDbcFileCommand = new LoadDbcFileCommand(this);
            _ParseDbcFileLogic = App._ServiceProvider.GetRequiredService<ParseDbcFileLogic>();
            LoadDBCFiles();
        }

        #region Private fields

        private ICommand _LoadDbcFileCommand;
        private ParseDbcFileLogic _ParseDbcFileLogic;
        private NetworkNodes _SelectedDBCFile;
        #endregion

        #region Icommand
        public ICommand LoadDbcFileCommand
        {
            get { return _LoadDbcFileCommand; }
            set { _LoadDbcFileCommand = value; }
        }
        #endregion

        public ObservableCollection<NetworkNodes> DBCFiles { get; set; }

        public NetworkNodes SelectedDBCFile 
        { 
            get { return _SelectedDBCFile; } 
            set 
            {
                _SelectedDBCFile = value;
                OnPropertyChanged("SelectedDBCFile"); 
            } 
        }
        private void LoadDBCFiles()
        {
            List<NetworkNodes> dbcFiles = _ParseDbcFileLogic.GetAll();
            DBCFiles = new ObservableCollection<NetworkNodes>();
            //_StartWindow.LoadedDBCFiles.Items.Clear();

            foreach (NetworkNodes networkNode in dbcFiles)
                DBCFiles.Add(new NetworkNodes() { Id= networkNode.Id,Name =networkNode.Name});
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
