using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient
{
    public class SAM1Configuration
    {
        #region Parameters
        public static int ThresholdMax = 99;
        public static int ThresholdMin = 01;

        public static int SMin = 4;
        public static int SMax = 6;

        public static int RMin = 4;
        public static int RMax = 6;


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

        public string ThresholdText
        {
            get
            {
                return ToThresholdText(this.Threshold);
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
                lstr.Add(ThresholdText);
                lstr.Add(SText);
                lstr.Add(RText);
                return lstr;
            }
        }
        
        public static List<string> ValidTTexts
        {
            get
            {
                List<string> ls = new List<string>();
                for(int i = ThresholdMin; i <= ThresholdMax; i++)
                    ls.Add(ToThresholdText(i));

                return ls;
            }
        }
        #endregion

        public SAM1Configuration()
        {
            // Default values
            this.Threshold = 40;
            this.S = 4;
            this.R = 4;
        }

        #region Methods & Function
        private static string ToThresholdText(int thresholdValue)
        {
            string str = "T";
            if (thresholdValue < 10) str += "0";
            return str + thresholdValue.ToString();
        }
        #endregion
    }
}
