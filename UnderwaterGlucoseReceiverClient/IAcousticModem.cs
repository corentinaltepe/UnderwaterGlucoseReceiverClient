using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient
{
    public interface IAcousticModem
    {
        event EventHandler GlucoseDataReceivedEvent;

        bool IsConnected { get;}
        ObservableCollection<string> PortNames { get; }
        List<GlucoseSensorPacket> ReceivedPackets { get; }
        object ModemConfiguration { get; set; }

        void Connect(string portName);
        void Disconnect();
        void ConfigureModem(List<string> cmds);
        ObservableCollection<string> ScanPortNames();
    }
}
