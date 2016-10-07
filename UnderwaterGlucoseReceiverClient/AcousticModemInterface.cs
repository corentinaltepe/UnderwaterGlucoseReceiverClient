using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient
{
    interface AcousticModemInterface
    {
        void Connect();
        void Disconnect();
        void ConfigureModem(List<string> cmds);
    }
}
