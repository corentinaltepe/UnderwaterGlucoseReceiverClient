using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderwaterGlucoseReceiverClient 
{
    public class SAM1ConfigThreshold : INotifyPropertyChanged
    {

        public static int ThresholdMax = 99;
        public static int ThresholdMin = 01;

        private int val;
        public int Value
        {
            get { return val; }

            set
            {
                if (value < ThresholdMin)
                    val = ThresholdMin;
                else if (value > ThresholdMax)
                    val = ThresholdMax;
                else
                    val = value;

                OnPropertyChanged("Value");
            }
        }
        public string Text
        {
            get
            {
                string str = "T";
                if (Value < 10) str += "0";
                return str + Value.ToString();
            }
        }

        public SAM1ConfigThreshold(int i)
        {
            this.Value = i;
        }

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


    }
}
