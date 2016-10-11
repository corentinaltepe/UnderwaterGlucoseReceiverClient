using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UnderwaterGlucoseReceiverClient.ViewModel
{
    public class GlucoseClientApp : INotifyPropertyChanged
    {
        #region Parameters
        public IAcousticModem ModemInterface
        { get; set; }

        // IDialogService is used to display dialogs directly from the ViewModel
        private readonly IDialogService dialogService;

        // Content of the console to be displayed on the config Tab
        // Updated at every new incoming data from sensor, connection event, etc
        private string console;
        public string Console
        {
            get { return console; }
            set
            {
                console = value;
                OnPropertyChanged("Console");
            }
        }

        #endregion

        #region Constructors
        public GlucoseClientApp(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            // By default
            this.ModemInterface = new SAM1Modem();
            this.Console = "";
        }

        #endregion

        #region Function & Methods
        private void AddTextToConsole(string text)
        {
            this.Console += ConsoleTimeHeader() + text + Environment.NewLine;
        }
        private void AddNewPacketToConsole(GlucoseSensorPacket pckt)
        {
            Console += ConsoleTimeHeader() + pckt.Raw.ToString() + " ; "
                        + pckt.Filtered.ToString() + Environment.NewLine;
        }
        private string ConsoleTimeHeader()
        {
            return DateTime.Now.ToLongTimeString() + ": ";
        }
        

        #endregion


        #region Events
        // Notify the view that a property has changed (update the view)
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Event generated from the View
        public ICommand ConfigureButtonClicked
        { get { return new DelegateCommand(OnConfigureButtonClick, CanConfigureButtonClicked); } }

        private bool CanAlways(object context)
        {
            return true;
        }
        private bool CanConfigureButtonClicked(object context)
        {
            if (ModemInterface != null && ModemInterface.IsConnected)
                return true;
            return false;
        }
        private void OnConfigureButtonClick(object context)
        {
            AddTextToConsole("Configuring Modem");
            try
            {
                ModemInterface.ConfigureModem();
                AddTextToConsole("Configuration Finished");
            }
            catch
            {
                AddTextToConsole("Configuration Failed!");
            }
        }
        #endregion

    }
}
