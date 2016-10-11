using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderwaterGlucoseReceiverClient.ModemConfiguration;

namespace UnderwaterGlucoseReceiverClient
{
    public class SAM1Configuration
    {
        #region Parameters
        public static int SMin = 4;
        public static int SMax = 6;

        public static int RMin = 4;
        public static int RMax = 6;

        // Selected Threshold
        public SAM1ConfigThreshold Threshold
        { get; set; }

        // List of Thresholds available
        public List<SAM1ConfigThreshold> ListOfThresholds
        { get; set; }

        private int s;
        public int S
        {
            get { return s; }

            set
            {
                if (value < SMin)
                    s = SMin;
                else if (value > SMax)
                    s = SMax;
                else
                    s = value;
            }
        }
        private int r;
        public int R
        {
            get { return r; }

            set
            {
                if (value < RMin)
                    r = RMin;
                else if (value > RMax)
                    r = RMax;
                else
                    r = value;
            }
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
                lstr.Add(Threshold.Text);
                lstr.Add(SText);
                lstr.Add(RText);
                return lstr;
            }
        }
        
        #endregion

        public SAM1Configuration()
        {
            this.ListOfThresholds = new List<SAM1ConfigThreshold>();
            for (int i = SAM1ConfigThreshold.ThresholdMin; i <= SAM1ConfigThreshold.ThresholdMax; i++)
            {
                this.ListOfThresholds.Add(new SAM1ConfigThreshold(i));
            }

            // Default values
            Threshold = ListOfThresholds[39]; // T40
            this.S = 4;
            this.R = 4;
        }

        #region Methods & Function
        

        #endregion
    }
}
