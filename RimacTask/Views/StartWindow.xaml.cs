using RimacTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RimacTask.Views
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {

        }
        public StartWindow(StartViewModel startViewModel)
        {
            InitializeComponent();
            this.DataContext = startViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get data from somewhere and fill in my local ArrayList    
            LoadedDBCFiles.Items.Add("Test");
        }
    }
}
