using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient
{
    public interface IAcousticModem
    {
        bool IsConnected { get;}
        List<string> PortNames { get; }

        void Connect(string portName);
        void Disconnect();
        void ConfigureModem(List<string> cmds);
        List<string> ScanPortNames();
    }
}
