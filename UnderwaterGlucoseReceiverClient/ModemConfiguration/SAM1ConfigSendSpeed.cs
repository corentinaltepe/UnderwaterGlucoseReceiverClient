using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient.ModemConfiguration
{
    public class SAM1ConfigSendSpeed : SAM1ConfigSpeed
    {
        public static int RMax = 6;
        public static int RMin = 4;

        public SAM1ConfigSendSpeed(int i) : base(i)
        {
            this.ValueMin = RMin;
            this.ValueMax = RMax;
            this.DisplayLetter = "S";
            this.Value = i;
        }
    }
}
