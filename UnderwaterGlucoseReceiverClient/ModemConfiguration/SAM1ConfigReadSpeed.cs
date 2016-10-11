using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient.ModemConfiguration
{
    public class SAM1ConfigReadSpeed : SAM1ConfigSpeed
    {
        public static int RMax = 6;
        public static int RMin = 4;
        
        public SAM1ConfigReadSpeed(int i) : base(i)
        {
            this.ValueMin = RMin;
            this.ValueMax = RMax;
            this.DisplayLetter = "R";
            this.Value = i;
        }
    }
}
