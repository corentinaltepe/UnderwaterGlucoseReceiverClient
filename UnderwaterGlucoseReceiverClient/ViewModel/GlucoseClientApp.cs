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
        public IAcousticModem ModemInterface
        { get; set; }

        // Content of the console to be displayed on the config Tab
        // Updated at every new incoming data from sensor, connection event, etc
        private string console;


        public string Console
        {
            get { return console; }
            set { console = value; }
        }

        public GlucoseClientApp()
        {
            // By default
            this.ModemInterface = new SM1Modem();
            this.Console = "";
        }

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
        public ICommand ComPortComboboxSelectionChanged
        { get { return new DelegateCommand(OnComPortComboboxSelectionChanged, CanComPortComboboxSelectionChange); } }

        private bool CanAlways(object context)
        {
            return true;
        }
        private bool CanComPortComboboxSelectionChange(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }
        private void OnComPortComboboxSelectionChanged(object context)
        {
            
        }
        #endregion

    }
}
