using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace UnderwaterGlucoseReceiverClient
{
    class SM1Modem : IAcousticModem
    {
        private static int SM1BAUD = 4800;              // SM-1 baud is fixed to 4800
        private static int RECEIVEDBYTETHRESHOLD = 4;   // Number of bytes to be received before triggering a received event

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

        private List<string> portNames;
        public List<string> PortNames
        {
            get
            {
                return portNames;
            }
        }

        private List<GlucoseSensorPacket> receivedPackets;
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

        public void ConfigureModem(List<string> cmds)
        {
            throw new NotImplementedException();
        }

        public void Connect(string portName)
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = portName;
            _serialPort.BaudRate = SM1BAUD;

            // Timeouts of 500 ms
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
            
            _serialPort.ReceivedBytesThreshold = RECEIVEDBYTETHRESHOLD;
        }

        public void Disconnect()
        {
            _serialPort.Close();
        }

        public List<string> ScanPortNames()
        {
            portNames = SerialPort.GetPortNames().OfType<string>().ToList();
            return PortNames;
        }

    }
}
