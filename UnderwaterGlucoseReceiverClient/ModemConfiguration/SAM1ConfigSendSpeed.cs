using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient.ModemConfiguration
{
    public class SAM1ConfigSendSpeed : SAM1ConfigSpeed
    {
        public static int SMax = 6;
        public static int SMin = 4;

        public SAM1ConfigSendSpeed(int i) : base(i)
        {
            this.ValueMin = SMin;
            this.ValueMax = SMax;
            this.DisplayLetter = "S";
            this.Value = i;
        }
    }
}
