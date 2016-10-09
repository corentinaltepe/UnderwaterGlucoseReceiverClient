using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient
{
    public class GlucoseClientApp
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

        #endregion

    }
}
