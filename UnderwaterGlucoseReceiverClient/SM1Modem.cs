using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Collections.ObjectModel;

namespace UnderwaterGlucoseReceiverClient
{
    class SM1Modem : IAcousticModem
    {
        private static int SM1BAUD = 4800;              // SM-1 baud is fixed to 4800
        private static int RECEIVEDBYTETHRESHOLD = 4;   // Number of bytes to be received before triggering a received event

        #region Parameters
        static SerialPort _serialPort;
        
        public bool IsConnected
        {
            get
            {
                if (_serialPort == null || _serialPort.GetType() != typeof(SerialPort))
                    return false;

                return _serialPort.IsOpen;
            }
        }

        private ObservableCollection<string> portNames;
        public ObservableCollection<string> PortNames
        {
            get
            {
                return portNames;
            }
            set
            {
                portNames = value;

                // Select the first item by default
                if (SelectedPortName == null || SelectedPortName == "" || !portNames.Contains(SelectedPortName))
                    SelectedPortName = portNames.First();
            }
        }
        private string _selectedPortName;
        public string SelectedPortName
        {
            get { return _selectedPortName; }
            set
            {
                // A new COM Port was selected
                _selectedPortName = value;
            }
        }


        private List<GlucoseSensorPacket> receivedPackets;

        public event EventHandler GlucoseDataReceivedEvent;

        public List<GlucoseSensorPacket> ReceivedPackets
        {
            get { return receivedPackets; }
        }
        public GlucoseSensorPacket readNextPacket
        {
            get
            {
                if (receivedPackets == null || receivedPackets.Count() == 0)
                    return null;
                GlucoseSensorPacket pckt = receivedPackets.First();
                receivedPackets.RemoveAt(0);

                return pckt;
            }
        }

        private SM1Configuration modemConfiguration;
        public object ModemConfiguration
        {
            get
            {
                return modemConfiguration;
            }

            set
            {
                modemConfiguration = (SM1Configuration)value;
            }
        }

        #endregion

        #region Constructors
        public SM1Modem()
        {
            this.receivedPackets = new List<GlucoseSensorPacket>();
            this.ModemConfiguration = new SM1Configuration();

            // Obtain the list of ports available
            this.ScanPortNames();
        }

        #endregion

        #region Methods & Functions

        public void ConfigureModem(List<string> cmds)
        {
            if (!this.IsConnected)
                return;

            // Suspend event during configuration
            _serialPort.DataReceived -= _serialPort_DataReceived;

            _serialPort.Write("#");
            Thread.Sleep(500);
            _serialPort.Write("#");
            Thread.Sleep(500);
            _serialPort.Write("#");
            Thread.Sleep(500);

            _serialPort.WriteLine("T40");
            Thread.Sleep(500);
            _serialPort.WriteLine("S4");
            Thread.Sleep(500);
            _serialPort.WriteLine("R4");
            Thread.Sleep(500);

            _serialPort.Write("D");
            
            _serialPort.DataReceived += _serialPort_DataReceived;
        }

        public void Connect(string portName)
        {
            // If serial port already connected, disconnect first
            if (_serialPort != null && this.IsConnected)
                this.Disconnect();

            // Reset the serial port to a new instance
            _serialPort = new SerialPort();
            _serialPort.PortName = portName;
            _serialPort.BaudRate = SM1BAUD;

            // Timeouts of 500 ms
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
            
            _serialPort.ReceivedBytesThreshold = RECEIVEDBYTETHRESHOLD;

            _serialPort.DataReceived += _serialPort_DataReceived;

            _serialPort.Open();
        }

        private GlucoseSensorPacket readGlucoseSensorPacket(byte[] data)
        {
            // First 2 bytes are RAW
            byte[] bRaw = new byte[2];
            Array.Copy(data, bRaw, 2);
            float raw = GlucoseSensorPacket.dex_num_decoder(bRaw);

            // Second 2 bytes are Filtered
            Array.Copy(data, 2, bRaw, 0, 2);
            float filtered = GlucoseSensorPacket.dex_num_decoder(bRaw);

            return new GlucoseSensorPacket(raw, filtered);
        }

        public void Disconnect()
        {
            // de-register event
            _serialPort.DataReceived -= _serialPort_DataReceived;

            _serialPort.Close();
        }

        public ObservableCollection<string> ScanPortNames()
        {
            List<string> ls = SerialPort.GetPortNames().OfType<string>().ToList();

            ObservableCollection<string> obLs = new ObservableCollection<string>();
            foreach (string st in ls)
                obLs.Add(st);

            PortNames = obLs;
            return PortNames;
        }

        #endregion

        #region Events

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (_serialPort.BytesToRead >= 4)
            {
                byte[] receivedData = new byte[4];
                _serialPort.Read(receivedData, 0, 4);

                receivedPackets.Add(readGlucoseSensorPacket(receivedData));
                OnGlucoseDataReceived(this, e);
            }
        }

        private void OnGlucoseDataReceived(object sender, EventArgs e)
        {
            EventHandler dataReceived = GlucoseDataReceivedEvent;
            if (dataReceived != null)
                dataReceived(this, e);
        }
        
        #endregion


    }
}
