using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient.ModemConfiguration
{
    public class SAM1ConfigThreshold : SAM1ConfigSpeed
    {
        public static int ThresholdMax = 99;
        public static int ThresholdMin = 01;

        // Redefinition of Text for Threshold (T01 instead of T1)
        public new string Text
        {
            get
            {
                string str = DisplayLetter;
                if (Value < 10) str += "0";
                return str + Value.ToString();
            }
        }

        public SAM1ConfigThreshold(int i):base(i)
        {
            this.ValueMin = ThresholdMin;
            this.ValueMax = ThresholdMax;
            this.DisplayLetter = "T";
            this.Value = i;
        }
    }
}
