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
        // SM-1 baud is fixed to 4800
        private static int SM1BAUD = 4800;

        static SerialPort _serialPort;

        private bool isConnected = false;
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
                portNames;
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
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public List<string> ScanPortNames()
        {
            portNames = SerialPort.GetPortNames().OfType<string>().ToList();
            return PortNames;
        }
    }
}
