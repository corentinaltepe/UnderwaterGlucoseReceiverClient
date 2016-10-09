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

        public int threshold;
        public int Threshold
        {
            get { return threshold; }

            set
            {
                if (value < ThresholdMin)
                    threshold = ThresholdMin;
                else if (value > ThresholdMax)
                    threshold = ThresholdMax;
                else
                    threshold = value;
            }
        }
        public int S
        { get; set; }
        public int R
        { get; set; }

        public string ThresholdText
        {
            get { return "T" + Threshold.ToString(); }
        }
        public string SText
        {
            get { return "S" + S.ToString(); }
        }
        public string RText
        {
            get { return "R" + R.ToString(); }
        }
        public List<string> Commands
        {
            get
            {
                List<string> lstr = new List<string>();
                lstr.Add(ThresholdText);
                lstr.Add(SText);
                lstr.Add(RText);
                return lstr;
            }
        }
        #endregion

        public SM1Configuration()
        {
            // Default values
            this.Threshold = 40;
            this.S = 4;
            this.R = 4;
        }
    }
}
