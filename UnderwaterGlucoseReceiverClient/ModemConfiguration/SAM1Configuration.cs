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

        // Selected Config Values
        public SAM1ConfigThreshold Threshold
        { get; set; }
        public SAM1ConfigSendSpeed S
        { get; set; }
        public SAM1ConfigReadSpeed R
        { get; set; }

        // List of Values available
        public List<SAM1ConfigThreshold> ListOfThresholds
        { get; set; }
        public List<SAM1ConfigReadSpeed> ListOfRs
        { get; set; }
        public List<SAM1ConfigSendSpeed> ListOfSs
        { get; set; }
        
        public List<string> Commands
        {
            get
            {
                List<string> lstr = new List<string>();
                lstr.Add(Threshold.Text);
                lstr.Add(S.Text);
                lstr.Add(R.Text);
                return lstr;
            }
        }
        
        #endregion

        public SAM1Configuration()
        {
            this.ListOfThresholds = new List<SAM1ConfigThreshold>();
            for (int i = SAM1ConfigThreshold.ThresholdMin; i <= SAM1ConfigThreshold.ThresholdMax; i++)
                this.ListOfThresholds.Add(new SAM1ConfigThreshold(i));

            this.ListOfRs = new List<SAM1ConfigReadSpeed>();
            for (int i = SAM1ConfigReadSpeed.RMin; i <= SAM1ConfigReadSpeed.RMax; i++)
                this.ListOfRs.Add(new SAM1ConfigReadSpeed(i));

            this.ListOfSs = new List<SAM1ConfigSendSpeed>();
            for (int i = SAM1ConfigSendSpeed.SMin; i <= SAM1ConfigSendSpeed.SMax; i++)
                this.ListOfSs.Add(new SAM1ConfigSendSpeed(i));


            // Default values
            this.Threshold = ListOfThresholds[39]; // T40
            this.S = ListOfSs[0];
            this.R = ListOfRs[0];
        }

        #region Methods & Function
        

        #endregion
    }
}
