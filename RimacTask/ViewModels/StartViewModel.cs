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
    public class StartViewModel : INotifyPropertyChanged
    {
        public StartViewModel()
        {
            _LoadDbcFileCommand = new LoadDbcFileCommand(this);
            _DeleteDBCFIleCommand = new DeleteDBCFileCommand(this);
            _NetworkNodeLogic = App._ServiceProvider.GetRequiredService<NetworkNodeLogic>();
            _MessageLogic = App._ServiceProvider.GetRequiredService<MessageLogic>();
            UILoadingDBCFiles();
        }

        #region Private fields

        private ICommand _LoadDbcFileCommand;
        private ICommand _DeleteDBCFIleCommand;
        private NetworkNodeLogic _NetworkNodeLogic;
        private NetworkNodes _SelectedDBCFile;
        private MessageLogic _MessageLogic;
        private ObservableCollection<NetworkNodes> _DBCFiles;
        private string _AllRecords;

        #endregion

        #region ICommand

        public ICommand LoadDbcFileCommand
        {
            get { return _LoadDbcFileCommand; }
            set { _LoadDbcFileCommand = value; }
        }
        public ICommand DeleteDBCFileCommand
        {
            get { return _DeleteDBCFIleCommand; }
            set { _DeleteDBCFIleCommand = value; }
        }

        #endregion

        #region Public properties
        public ObservableCollection<NetworkNodes> DBCFiles 
        {
            get { return _DBCFiles; }
            set { _DBCFiles = value; OnPropertyChanged("DBCFiles"); }
        }
        public NetworkNodes SelectedDBCFile 
        {
            get { return _SelectedDBCFile; }
            set { _SelectedDBCFile = value; OnPropertyChanged("SelectedDBCFile");}
        }
        public string AllRecords 
        { 
            get { return _AllRecords; }
            set { _AllRecords = value; OnPropertyChanged("AllRecords"); }
        }

        #endregion

        public void UILoadingDBCFiles()
        {
            List<NetworkNodes> dbcFiles = _NetworkNodeLogic.GetAll<NetworkNodes>();
            List<Messages> messages = _MessageLogic.GetAll<Messages>();
            //List<Signals> signals = _NetworkNodeLogic.GetAll<Signals>();

            _DBCFiles = new ObservableCollection<NetworkNodes>();
            _AllRecords = "";

            foreach (NetworkNodes networkNode in dbcFiles)
            {
                _DBCFiles.Add(new NetworkNodes() { Id = networkNode.Id, Name = networkNode.Name });
                _AllRecords += networkNode.ToString();
            }

            OnPropertyChanged("DBCFiles");
            OnPropertyChanged("AllRecords");
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
