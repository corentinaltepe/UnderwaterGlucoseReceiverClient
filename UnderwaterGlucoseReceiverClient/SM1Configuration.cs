using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient
{
    public class SM1Configuration
    {
        #region Parameters
        public static int ThresholdMax = 99;
        public static int ThresholdMin = 35;

        int thresholdValue;
        int ThresholdValue
        {
            get { return thresholdValue; }

            set
            {
                if (value < ThresholdMin)
                    thresholdValue = ThresholdMin;
                else if (value > ThresholdMax)
                    thresholdValue = ThresholdMax;
                else
                    thresholdValue = value;
            }
        }
        int SValue
        { get; set; }
        int RValue
        { get; set; }

        string ThresholdText
        {
            get { return "T" + ThresholdValue.ToString(); }
        }
        string SText
        {
            get { return "S" + SValue.ToString(); }
        }
        string RText
        {
            get { return "R" + RValue.ToString(); }
        }

        #endregion

        public SM1Configuration()
        {
            // Default values
            this.ThresholdValue = 40;
            this.SValue = 4;
            this.RValue = 4;
        }
    }
}
